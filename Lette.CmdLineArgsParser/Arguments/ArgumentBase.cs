namespace Lette.CmdLineArgsParser
{
    public abstract class ArgumentBase<T>
    {
        public abstract void Invoke(T settings);
    }
}