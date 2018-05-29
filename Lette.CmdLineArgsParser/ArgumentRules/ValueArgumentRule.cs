using System;
using System.Collections.Generic;

namespace Lette.CmdLineArgsParser
{
    public class ValueArgumentRule<T> : ArgumentRuleBase<T>
    {
        public Action<T, string> Action { get; private set; }

        public ValueArgumentRule(Action<T, string> action)
        {
            Action = action;
        }

        public override ArgumentBase<T> CreateArgument(string head, Stack<string> tail)
        {
            return new ValueArgument<T>(head, Action);
        }
    }
}