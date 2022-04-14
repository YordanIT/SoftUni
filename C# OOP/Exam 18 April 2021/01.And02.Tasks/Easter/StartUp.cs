using Easter.Core;
using Easter.Core.Contracts;

namespace Easter
{

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
