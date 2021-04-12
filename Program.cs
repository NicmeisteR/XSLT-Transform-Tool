using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using CommandLine;

namespace transformTool
{
    class Program
    {

        static void Main(string[] args)
        {
            // This is here simply so I can add Emojis to the terminal. 🥳🎊🙃
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // CommandLine parser used to parse all of the different options and commands.
            CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                if (o.Transform)
                {
                    Console.WriteLine(
                        $"Data location: {o.FolderPath} 🚩 \n" +
                        $"To overwrite the data location use the -p flag.\n"
                    );
                    Transform_Tool(o.FolderPath);
                }
            });
        }

        public static void Transform_Tool(string DataPath)
        {
            // Get all files in the root directory containing the XSLT extension.
            string[] xsltFiles = Directory.GetFiles("./", "*.xslt");

            // Create a new XslCompiledTransform and load the compiled transformation.
            XslCompiledTransform xslt = new XslCompiledTransform();

            // Execute the transformation and output the results to a file.
            foreach (var file in xsltFiles)
            {
                // Initialize the XSLT transformation settings.
                xslt.Load(file, new XsltSettings { EnableDocumentFunction = true, EnableScript = true }, new XmlUrlResolver());

                // Configure the XML writer settings, necessary to trigger fragments like _templates etc.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.CloseOutput = false;

                // TODO: The below might be a bit overkill, and can be simplified.
                // Create the XmlWriter object and write some content.
                byte[] byteArray = Encoding.UTF8.GetBytes($"{DataPath}/data.xml");
                MemoryStream stream = new MemoryStream(byteArray);
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                var xmlw = XmlWriter.Create($"{file.Replace(".xslt", "")}.html", settings);
                var xslargs = new XsltArgumentList();
                xslargs.AddParam("fileName", "", $"{DataPath}/data.xml");
                xslt.Transform(text, xslargs, xmlw);
                xmlw.Flush();
                xmlw.Close();
                Console.WriteLine($"Transformed: {file} ✅");
            }
        }
    }
}
