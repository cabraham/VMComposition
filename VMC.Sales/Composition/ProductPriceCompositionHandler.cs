using VMC.Framework.Composition;
using VMC.Sales.Data;

namespace VMC.Sales.Composition
{
    public class ProductPriceCompositionHandler : IHandleCompositionRequest
    {
        private readonly ProductRepository productRepository;
        private HashSet<string> compositionRequestTypes;

        public ProductPriceCompositionHandler(ProductRepository productRepository)
        {
            compositionRequestTypes = new HashSet<string>();
            compositionRequestTypes.Add("INeedToKnowProductPrice");
            this.productRepository = productRepository;
        }

        public Task<object> Handle(CompositionRequest request)
        {
            var product = productRepository.Get(int.Parse(request.Parameters["productId"]));
            return Task.FromResult((object)product.Price);

        }

        public bool IsApplicableHandler(CompositionRequest compositionRequest)
        {
            return compositionRequestTypes.Contains(compositionRequest.RequestType);
        }
    }
}
