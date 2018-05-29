using System;
using System.Collections.Generic;

namespace Lette.CmdLineArgsParser
{
    public class KeyArgumentRule<T> : ArgumentRuleBase<T>, IKeyArgumentRule
    {
        public string[] Arguments { get; private set; }
        public Action<T> Action { get; private set; }

        public KeyArgumentRule(string[] arguments, Action<T> action)
        {
            Arguments = arguments;
            Action = action;
        }

        public override ArgumentBase<T> CreateArgument(string head, Stack<string> tail)
        {
            return new KeyArgument<T>(head, Action);
        }
    }
}