using System;
using System.Collections.Generic;
using System.Linq;

namespace Lette.CmdLineArgsParser
{
    public class KeyValueArgumentRule<T> : ArgumentRuleBase<T>, IKeyArgumentRule
    {
        public string[] Arguments { get; private set; }
        public Action<T, string> Action { get; private set; }

        public KeyValueArgumentRule(string[] arguments, Action<T, string> action)
        {
            Arguments = arguments;
            Action = action;
        }

        public override ArgumentBase<T> CreateArgument(string head, Stack<string> tail)
        {
            if (!tail.Any())
            {
                throw new ArgumentException("Missing argument value.", head);
            }

            return new KeyValueArgument<T>(head, tail.Pop(), Action);
        }
    }
}