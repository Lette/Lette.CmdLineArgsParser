namespace Lette.CmdLineArgsParser
{
    public interface IArgumentsParser<T>
    {
        T Parse(ArgumentRuleList<T> rules, string[] arguments);
    }
}