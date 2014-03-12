using System;

namespace Lette.CmdLineArgsParser.Demo
{
    internal class Program
    {
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ShowError(e);

            var parserProgram = new ParserProgram();
            parserProgram.Parse();
        }

        private static void ShowError(UnhandledExceptionEventArgs args)
        {
            var ex = args.ExceptionObject as Exception;
            ShowError(ex);
            Environment.Exit(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
        }

        private static void ShowError(Exception ex)
        {
            if (ex == null)
            {
                return;
            }

            Console.Out.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);

            ShowError(ex.InnerException);
        }
    }
}