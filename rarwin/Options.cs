using CommandLine;

namespace rarwin
{
    internal class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file to be processed.")]
        public IEnumerable<string>? Input { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output path.")]
        public IEnumerable<string>? Output { get; set; }
    }
}
