namespace ToolsResearch
{
    using System;
    using System.Linq;
    using log4net;

    internal class DoSomething
    {
        internal DoSomething(ILog logger)
        {
            logger.Info("new DoSomething()");
        }
    }
}