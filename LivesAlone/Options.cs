using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivesAlone
{
    using CommandLine;
    public class Options
    {
        [Option('f', "folder", Required = false, HelpText = "Set the folder path.")]
        public string? FolderPath { get; set; }
    }
}
