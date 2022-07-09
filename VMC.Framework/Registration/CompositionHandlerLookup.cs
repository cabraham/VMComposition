using VMC.Framework.Composition;

namespace VMC.Framework.Registration
{
    public class CompositionHandlerLookup
    {
        private readonly CompositionHandlerRegistry registry;

        public CompositionHandlerLookup(CompositionHandlerRegistry registry)
        {
            this.registry = registry;
        }
        

        public IEnumerable<IHandleCompositionRequest> GetHandlersForRequest(CompositionRequest request)
        {
            foreach (var handler in registry.GetHandlers())
            {
                if (handler.IsApplicableHandler(request))
                {
                    yield return handler;
                }
            }
        }
    }
}
