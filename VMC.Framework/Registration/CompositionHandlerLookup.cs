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
            foreach (var handlerType in registry.GetHandlerTypes())
            {
                var handler = (IHandleCompositionRequest)Activator.CreateInstance(handlerType);


                if (handler.IsApplicableHandler(request))
                {
                    yield return handler;
                }
            }
        }
    }
}
