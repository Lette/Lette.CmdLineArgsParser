using System;

namespace Lette.CmdLineArgsParser
{
    public class KeyValueArgument<T> : ArgumentBase<T>
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        private readonly Action<T, string> _action;

        public KeyValueArgument(string key, string value, Action<T, string> action)
        {
            Key = key;
            Value = value;
            _action = action;
        }

        public override void Invoke(T settings)
        {
            _action(settings, Value);
        }
    }
}