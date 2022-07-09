using VMC.Framework.Composition;
using VMC.Inventory.Data;

namespace VMC.Inventory.Composition
{
    public class ProductInventoryCompositionHandler : IHandleCompositionRequest
    {
        private readonly ProductRepository productRepository;
        private HashSet<string> handlingRequestTypes;
        public ProductInventoryCompositionHandler(ProductRepository productRepository)
        {
            handlingRequestTypes = new HashSet<string>();
            handlingRequestTypes.Add("INeedToKnowIfProductIsAvailable");
            handlingRequestTypes.Add("INeedToKnowProductCount");
            this.productRepository = productRepository;
        }

        public Task<object> Handle(CompositionRequest request)
        {
            var product = productRepository.Get(int.Parse(request.Parameters["productId"]));
            return Task.FromResult((object)product.Count);
        }

        public bool IsApplicableHandler(CompositionRequest compositionRequest)
        {
            return handlingRequestTypes.Contains(compositionRequest.RequestType);
        }
    }
}
