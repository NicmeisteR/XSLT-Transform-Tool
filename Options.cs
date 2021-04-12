using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace transformTool
{
    public class Options
    {
        [Option('p', "FolderPath", HelpText = "Define the path to the xml data, must be named data.xml", Default = "_data")]
        public string FolderPath { get; set; }

        [Option('a', "About", HelpText = "A new generation Transform Tool made by Nico.")]
        public string About { get; set; }

        [Option('t', "Transform", HelpText = "Command to transform XSLT")]
        public bool Transform { get; set; }
    }
}
