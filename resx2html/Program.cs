using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

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
            Console.WriteLine("###########################################################################");
            Console.WriteLine("#              WELCOME TO RESX2HTML (.NET RESOURCE CONVERTER)             #");
            Console.WriteLine("#           This console program will convert resx file to HTML.          #");
            Console.WriteLine("#                                                                         #");
            Console.WriteLine("#          (C) 2005 - 2013 EasyCoding Team. All rights reserved.          #");
            Console.WriteLine("#             Original author: V1TSK (vitaly@easycoding.org).             #");
            Console.WriteLine("#                                                                         #");
            Console.WriteLine("#       Official site: http://www.easycoding.org/projects/resx2html       #");
            Console.WriteLine("#                       Part of SRC Repair project.                       #");
            Console.WriteLine("###########################################################################");
            Console.WriteLine();
        }

        static void DoConversion(string Source, string Dest)
        {
            try
            {
                using (StreamWriter CFile = new StreamWriter(Dest, false, Encoding.UTF8))
                {
                    CFile.WriteLine(Properties.Resources.HTMLHeader);
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
                                    CFile.WriteLine(String.Format(Properties.Resources.HTMLRow, ElID.GetAttribute("name"), ElID.GetElementsByTagName("value")[0].InnerText));
                                }
                            }
                            catch (Exception Ex) { CFile.WriteLine(String.Format(Properties.Resources.HTMLCommFormat, Ex.Message)); }
                        }
                        XMLFS.Close();
                    }
                    CFile.WriteLine(Properties.Resources.HTMLFooter);
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
                    DoConversion(Args[0], Args[1]);
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
