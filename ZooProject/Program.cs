using System;
using ZooProject.FileLogger;
using ZooProject.UI;

namespace ZooProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Logger logger = Logger.GetOrSetLogger();
            UIConsole console = new UIConsole();
            console.Start();
        }

    }
}
