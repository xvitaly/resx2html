﻿using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace resx2html
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###########################################################################");
            Console.WriteLine("#                WELCOME TO RESX2HTML (.NET RESOURCE CONVERTER)           #");
            Console.WriteLine("#             This console program will convert resx file to HTML.        #");
            Console.WriteLine("#                                                                         #");
            Console.WriteLine("#        (C) 2005 - 2013 EasyCoding Team. All rights reserved.            #");
            Console.WriteLine("#            Original author: V1TSK (vitaly@easycoding.org).              #");
            Console.WriteLine("#                                                                         #");
            Console.WriteLine("#     Official site: http://www.easycoding.org/projects/resx2html         #");
            Console.WriteLine("#                        Part of SRC Repair project.                      #");
            Console.WriteLine("###########################################################################");
            Console.WriteLine();
            if (args.Count() > 1)
            {
                if (File.Exists(args[0]))
                {
                    Console.WriteLine(String.Format("Source file: {0}\nDestination file: {1}\n", args[0], args[1]));
                    Console.Write("Starting conversion...");
                    using (StreamWriter CFile = new StreamWriter(args[1], false, Encoding.UTF8))
                    {
                        CFile.WriteLine("<html><head><title>Generated by resx2html</title></head><body><div><table border=\"1\" width=\"100%\" id=\"table1\"><tr><td width=\"25%\"><div align=\"center\"><strong>Option name</strong></div></td><td width=\"75%\"><div align=\"center\"><strong>Option description</strong></td></tr>");
                        try
                        {
                            XmlDocument XMLD = new XmlDocument();
                            using (FileStream XMLFS = new FileStream(args[0], FileMode.Open, FileAccess.Read))
                            {
                                XMLD.Load(XMLFS);
                                XmlNodeList XMLNList = XMLD.GetElementsByTagName("data");
                                for (int i = 0; i < XMLNList.Count; i++)
                                {
                                    XmlElement ElID = (XmlElement)XMLD.GetElementsByTagName("data")[i];
                                    CFile.WriteLine(String.Format("<tr><td>{0}</td><td>{1}</td></tr>", ElID.GetAttribute("name"), ElID.GetElementsByTagName("value")[0].InnerText));
                                }
                                XMLFS.Close();
                            }
                        }
                        catch (Exception Ex) { CFile.WriteLine(String.Format("<!-- {0} -->", Ex.Message)); }
                        CFile.WriteLine("</table></div><div align=\"right\">(c) EasyCoding Team</div></body>");
                        CFile.Close();
                        Console.WriteLine(" Done.\n\nGoodbye.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Syntax: resx2html <RESX-file> <result.html>");
            }
            #if DEBUG
            Console.ReadKey();
            #endif
        }
    }
}
