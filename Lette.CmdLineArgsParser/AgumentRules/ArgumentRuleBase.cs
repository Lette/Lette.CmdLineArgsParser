using System.Collections.Generic;

namespace Lette.CmdLineArgsParser
{
    public abstract class ArgumentRuleBase<T>
    {
        public abstract ArgumentBase<T> CreateArgument(string head, Stack<string> tail);
    }
}