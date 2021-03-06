﻿/*
 * RESX2HTML - non-interactive .NET resource converter.
 * This product is a part of SRC Repair project.
 * 
 * Copyright 2011 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2013 EasyCoding Team.
 * 
 * License: GPL v3 (see COPYING file).
 * 
 * Official EasyCoding Team's blog: http://www.easycoding.org/
 * RESX2HTML's official site: http://www.easycoding.org/projects/resx2html
 *
*/
using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections.Generic;

namespace resx2html
{
    class Program
    {
        static void ConfigureConsole(string Title, ConsoleColor Color)
        {
            Console.Title = Title;
            Console.ForegroundColor = Color;
        }

        static void ShowSplash(string FileName)
        {
            using (Stream Strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(FileName))
            {
                using (StreamReader Reader = new StreamReader(Strm))
                {
                    Console.WriteLine(Reader.ReadToEnd());
                }
            }
        }

        static string FormatLine(string Line)
        {
            return Line.Replace("{LBR}", Environment.NewLine);
        }

        static void PrepareConversion(string Source, string Dest, string TemplateName)
        {
            List<String> Template = new List<string>();

            using (Stream Strm = Assembly.GetExecutingAssembly().GetManifestResourceStream(TemplateName))
            {
                using (StreamReader Reader = new StreamReader(Strm))
                {
                    while (Reader.Peek() >= 0)
                    {
                        Template.Add(FormatLine(Reader.ReadLine()));
                    }
                }
            }

            if (Template.Count >= 4) { DoConversion(Source, Dest, Template[0], Template[1], Template[3], Template[2]); } else { throw new ArgumentNullException(); }
        }

        static void DoConversion(string Source, string Dest, string Header, string RowTemplate, string Footer, string Commentary)
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
                        catch (Exception Ex) { CFile.WriteLine(String.Format(Commentary, Ex.Message)); }
                    }
                    XMLFS.Close();
                }
                CFile.WriteLine("{0}{1}", Environment.NewLine, Footer);
                CFile.Close();
            }
        }

        static string GetTemplateNameById(string Id)
        {
            string Result;
            switch (Id)
            {
                case "1": Result = Properties.Resources.TemplateGWikiFile;
                    break;
                case "2": Result = Properties.Resources.TemplateMarkdownFile;
                    break;
                case "3": Result = Properties.Resources.TemplateMediaWikiFile;
                    break;
                default: Result = Properties.Resources.TemplateHTMLFile;
                    break;
            }
            return Result;
        }
        
        static void Main(string[] Args)
        {
            ConfigureConsole(Properties.Resources.AppName, ConsoleColor.Green);

            try { ShowSplash(Properties.Resources.WelcomeFileName); } catch (Exception Ex) { Console.WriteLine(String.Format(Properties.Resources.ExcptMsg, Ex.Message)); }

            if (Args.Count() > 1)
            {
                if (File.Exists(Args[0]))
                {
                    Console.WriteLine(String.Format(Properties.Resources.WrkFlMsg, Args[0], Environment.NewLine, Args[1], Environment.NewLine));
                    Console.Write(Properties.Resources.StartFlMsg);
                    try
                    {
                        string TemplateFile = (Args.Count() > 2) ? GetTemplateNameById(Args[2]) : Properties.Resources.TemplateHTMLFile;
                        PrepareConversion(Args[0], Args[1], TemplateFile);
                    } catch (Exception Ex) { Console.WriteLine(String.Format(Properties.Resources.ExcptMsg, Ex.Message)); }
                    Console.WriteLine(Properties.Resources.EndFlMsg, " ", Environment.NewLine, Environment.NewLine);
                }
            }
            else { Console.WriteLine(Properties.Resources.WlxMsg); }

            #if DEBUG
            Console.ReadKey();
            #endif
        }
    }
}
