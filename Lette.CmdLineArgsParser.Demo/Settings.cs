namespace Lette.CmdLineArgsParser.Demo
{
    public class Settings
    {
        public Settings()
        {
            Parallel = true;
            Filter = string.Empty;
            FilePath = null;
        }

        public bool Parallel { get; set; }
        public string Filter { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return string.Format("Parallel={0}, Filter='{1}', FilePath='{2}'", Parallel, Filter, FilePath);
        }
    }
}