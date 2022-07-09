using VMC.Framework.Composition;
using VMC.Framework.Registration;

namespace VMC.Framework.Pipeline
{
    public class HandlerPipeline
    {
        private readonly CompositionHandlerLookup handlerLookup;

        public HandlerPipeline(CompositionHandlerLookup handlerLookup)
        {
            this.handlerLookup = handlerLookup;
        }

        public async Task Handle(CompositionRequest compositionRequest)
        {
            var handlers = handlerLookup.GetHandlersForRequest(compositionRequest);
            foreach (var handler in handlers)
            {
                // 1. get instance of handler



                // 2. invoke handler
            }

            throw new NotImplementedException();
        }
    }
}
