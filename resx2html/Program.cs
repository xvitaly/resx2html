using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

namespace resx2html
{
    class Program
    {
        static void ConfigureConsole(string Title, ConsoleColor Color)
        {
            Console.Title = Title;
            Console.ForegroundColor = Color;
        }

        static void ShowSplash()
        {
            try
            {
                using (Stream Strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("resx2html.Resources.WelcomeMsg.txt"))
                {
                    using (StreamReader Reader = new StreamReader(Strm))
                    {
                        Console.WriteLine(Reader.ReadToEnd());
                    }
                }
            }
            catch (Exception Ex) { Console.WriteLine(String.Format(Properties.Resources.ExcptMsg, Ex.Message)); }
        }

        static void PrepareConversion(string Source, string Dest)
        {
            string Header = Properties.Resources.HTMLHeader;
            string Body = Properties.Resources.HTMLRow;
            string Footer = Properties.Resources.HTMLFooter;
            DoConversion(Source, Dest, Header, Body, Footer);
        }

        static void DoConversion(string Source, string Dest, string Header, string RowTemplate, string Footer)
        {
            try
            {
                using (StreamWriter CFile = new StreamWriter(Dest, false, Encoding.UTF8))
                {
                    CFile.WriteLine(Header);
                    XmlDocument XMLD = new XmlDocument();
                    using (FileStream XMLFS = new FileStream(Source, FileMode.Open, FileAccess.Read))
                    {
                        XMLD.Load(XMLFS);
                        XmlNodeList XMLNList = XMLD.GetElementsByTagName("data");
                        for (int i = 0; i < XMLNList.Count; i++)
                        {
                            try
                            {
                                XmlElement ElID = (XmlElement)XMLD.GetElementsByTagName("data")[i];
                                if (String.IsNullOrWhiteSpace(ElID.GetAttribute("type")))
                                {
                                    CFile.WriteLine(String.Format(RowTemplate, ElID.GetAttribute("name"), ElID.GetElementsByTagName("value")[0].InnerText));
                                }
                            }
                            catch (Exception Ex) { CFile.WriteLine(String.Format(Properties.Resources.HTMLCommFormat, Ex.Message)); }
                        }
                        XMLFS.Close();
                    }
                    CFile.WriteLine(Footer);
                    CFile.Close();
                }
            }
            catch (Exception Ex) { Console.WriteLine(String.Format(Properties.Resources.ExcptMsg, Ex.Message)); }
        }
        
        static void Main(string[] Args)
        {
            ConfigureConsole(Properties.Resources.AppName, ConsoleColor.Green);
            ShowSplash();

            if (Args.Count() > 1)
            {
                if (File.Exists(Args[0]))
                {
                    Console.WriteLine(String.Format("Source file: {0}\nDestination file: {1}\n", Args[0], Args[1]));
                    Console.Write("Starting conversion...");
                    PrepareConversion(Args[0], Args[1]);
                    Console.WriteLine(" Done.\n\nGoodbye.");
                }
            }
            else { Console.WriteLine(Properties.Resources.WlxMsg); }

            #if DEBUG
            Console.ReadKey();
            #endif
        }
    }
}
