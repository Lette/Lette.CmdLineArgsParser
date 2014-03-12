using System;

namespace Lette.CmdLineArgsParser
{
    public class ValueArgument<T> : ArgumentBase<T>
    {
        public string Value { get; private set; }

        private readonly Action<T, string> _action;

        public ValueArgument(string value, Action<T, string> action)
        {
            Value = value;
            _action = action;
        }

        public override void Invoke(T settings)
        {
            _action(settings, Value);
        }
    }
}