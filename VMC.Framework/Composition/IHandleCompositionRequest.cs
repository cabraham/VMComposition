namespace VMC.Framework.Composition
{
    public interface IHandleCompositionRequest
    {
        bool IsApplicableHandler(CompositionRequest compositionRequest);
        
        Task<object> Handle(CompositionRequest request);
    }
}
