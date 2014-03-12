using System;

namespace Lette.CmdLineArgsParser
{
    public class KeyArgument<T> : ArgumentBase<T>
    {
        public string Argument { get; private set; }

        private readonly Action<T> _action;

        public KeyArgument(string argument, Action<T> action)
        {
            Argument = argument;
            _action = action;
        }

        public override void Invoke(T settings)
        {
            _action(settings);
        }
    }
}