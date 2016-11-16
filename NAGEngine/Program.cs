#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace NAGEngine
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public class A
    {
        private bool b = false;
        public void AA()
        {
            if (b == false)
            Console.WriteLine("aaaaaaa");
            else Console.WriteLine("bbbbbbbbbb");
        }
        public void B()
        {
            b = true;
        }
    }
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
 /*           A tmp = new A();
            A tmp2 = null;
            tmp2 = tmp;
            tmp.AA();
            tmp2.AA();
            tmp.B();
            tmp.AA();
            tmp2.AA();*/
            using (var game = new InfirmaryInc())
                game.Run();
            
        }
    }
#endif
}
