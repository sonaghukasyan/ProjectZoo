using System;

namespace ZooProject.FileLogger
{
    interface ILogger
    {
        void Info(string info);
        void Error(Exception ex);
        void Error(string err);
        void Warning(string warning);
    }
}
