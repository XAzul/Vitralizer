using System;

namespace Vitralizer
{
    static class Program
    {
        static void Main(string[] args)
        {
            using (Application app = new Application())
            {
                app.Run();
            }
        }
    }
}

