using System.Collections.Generic;
using System.Linq;

namespace Lette.CmdLineArgsParser
{
    public class ArgumentsParser<T> : IArgumentsParser<T> where T : new()
    {
        public T Parse(ArgumentRuleList<T> rules, string[] args = null)
        {
            if (args == null)
            {
                var env = new EnvironmentWrapper();
                args = env.GetCommandLineArgsWithoutExecutable();
            }

            var arguments = ParseArguments(args, rules);
            var settings = CreateSettings(arguments);

            return settings;
        }

        private IEnumerable<ArgumentBase<T>> ParseArguments(IEnumerable<string> args, ArgumentRuleList<T> rules)
        {
            var stack = new Stack<string>(args.Reverse());

            var arguments = new ArgumentList<T>();

            while (stack.Any())
            {
                var arg = stack.Pop();

                ArgumentRuleBase<T> rule = rules.GetRuleFor(arg);

                arguments.Add(rule.CreateArgument(arg, stack));
            }

            return arguments;
        }

        private T CreateSettings(IEnumerable<ArgumentBase<T>> arguments)
        {
            var settings = new T();

            foreach (var argument in arguments)
            {
                argument.Invoke(settings);
            }

            return settings;
        }
    }
}