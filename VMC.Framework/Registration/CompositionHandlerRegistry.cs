using VMC.Framework.Composition;

namespace VMC.Framework.Registration
{
    public class CompositionHandlerRegistry
    {
        private readonly List<Type> handlerRegistry;

        public CompositionHandlerRegistry()
        {
            handlerRegistry = new List<Type>();
        }

        public void Add(Type handlerType)
        {
            handlerRegistry.Add(handlerType);
        }

        public IReadOnlyList<Type> GetHandlerTypes() => handlerRegistry.AsReadOnly();
    }
}
