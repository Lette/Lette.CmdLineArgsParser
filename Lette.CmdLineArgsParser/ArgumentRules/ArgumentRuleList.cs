using System;
using System.Collections.Generic;
using System.Linq;

namespace Lette.CmdLineArgsParser
{
    public class ArgumentRuleList<T> : List<ArgumentRuleBase<T>>
    {
        public new void Add(ArgumentRuleBase<T> rule)
        {
            if (rule is ValueArgumentRule<T> && this.Any(r => r is ValueArgumentRule<T>))
            {
                throw new ArgumentException("The list of argument rules can have at most one ValueArgumentRule.");
            }

            base.Add(rule);
        }

        public void Add(string[] arguments, Action<T, string> action)
        {
            Add(new KeyValueArgumentRule<T>(arguments, action));
        }

        public void Add(string[] arguments, Action<T> action)
        {
            Add(new KeyArgumentRule<T>(arguments, action));
        }

        public void Add(Action<T, string> action)
        {
            Add(new ValueArgumentRule<T>(action));
        }

        public ArgumentRuleBase<T> GetRuleFor(string argument)
        {
            var keyRules = GetKeyRules(argument);
            var valueRule = GetValueArgumentRule();

            if (keyRules.Count == 0 && valueRule == null)
            {
                throw new ArgumentException("Argument is an unrecognized parameter and no value argument rule (\"catch all\") has been specified.", argument);
            }

            if (keyRules.Count > 1)
            {
                throw new ArgumentException("Argument appears in multiple rules.", argument);
            }

            if (keyRules.Count == 1)
            {
                return keyRules[0];
            }

            return valueRule;
        }

        private List<ArgumentRuleBase<T>> GetKeyRules(string argument)
        {
            return this
                .OfType<IKeyArgumentRule>()
                .Where(r => r
                    .Arguments
                    .Select(a => a.ToLowerInvariant())
                    .Contains(argument.ToLowerInvariant()))
                .Cast<ArgumentRuleBase<T>>()
                .ToList();
        }

        private ArgumentRuleBase<T> GetValueArgumentRule()
        {
            return this
                .OfType<ValueArgumentRule<T>>()
                .SingleOrDefault();
        }
    }
}