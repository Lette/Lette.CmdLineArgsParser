using System;
using System.Linq;

namespace Lette.CmdLineArgsParser
{
    public class EnvironmentWrapper : IEnvironmentWrapper
    {
        public string[] GetCommandLineArgs()
        {
            return Environment.GetCommandLineArgs();
        }

        public string[] GetCommandLineArgsWithoutExecutable()
        {
            return Environment.GetCommandLineArgs().Skip(1).ToArray();
        }
    }
}