using VMC.Framework.Composition;

namespace VMC.Framework.Registration
{
    public class CompositionHandlerRegistry
    {
        private readonly List<IHandleCompositionRequest> handlerRegistry;

        public CompositionHandlerRegistry()
        {
            handlerRegistry = new List<IHandleCompositionRequest>();
        }

        public void Add(IHandleCompositionRequest handler)
        {
            handlerRegistry.Add(handler);
        }

        public IReadOnlyList<IHandleCompositionRequest> GetHandlers() => handlerRegistry;
    }
}
