namespace VMC.Framework.Composition
{
    public class Composer : IComposer
    {
        public int Get()
        {
            return 42;
        }
    }

    public interface IComposer
    {
        int Get();
    }
}
