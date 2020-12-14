using System;

namespace Lette.CmdLineArgsParser.Demo
{
    internal class ParserProgram
    {
        private static readonly ArgumentRuleList<Settings> _rules = new ArgumentRuleList<Settings>
            {
                { new[] { "-p+", "--para", "--parallel" }, s => s.Parallel = true },
                { new[] { "-p-", "--seq", "--sequential" }, s => s.Parallel = false },
                { new[] { "-f", "--filter" }, (s, p) => s.Filter = p },
                { new[] { "-r", "--run" }, (s, p) => s.FilePath = p },
                (s, p) => s.FilePath = p
            };

        internal void Parse()
        {
            var parser = new ArgumentsParser<Settings>();

            // Default to parsing the Environment.GetCommandLineArgs()...
            var settings = parser.Parse(_rules);
            Console.Out.WriteLine("1. {0}", settings);

            // ...or supply your own args to the parser.
            var args = new[] { "--Sequential", "-f", "filter", "--run", "run" };
            settings = parser.Parse(_rules, args);
            Console.Out.WriteLine("2. {0}", settings);

            Console.Out.WriteLine("Press the <Any> key.");
            Console.ReadKey();
        }
    }
}
