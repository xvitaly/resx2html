﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace resx2html.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("resx2html.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non-interactive .NET resource converter.
        /// </summary>
        internal static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exception caught: {0}..
        /// </summary>
        internal static string ExcptMsg {
            get {
                return ResourceManager.GetString("ExcptMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!-- {0} --&gt;.
        /// </summary>
        internal static string HTMLCommFormat {
            get {
                return ResourceManager.GetString("HTMLCommFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;/table&gt;&lt;/div&gt;&lt;div align=\&quot;right\&quot;&gt;(c) EasyCoding Team&lt;/div&gt;&lt;/body&gt;.
        /// </summary>
        internal static string HTMLFooter {
            get {
                return ResourceManager.GetString("HTMLFooter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;&lt;head&gt;&lt;title&gt;Generated by resx2html&lt;/title&gt;&lt;/head&gt;&lt;body&gt;&lt;div&gt;&lt;table border=\&quot;1\&quot; width=\&quot;100%\&quot; id=\&quot;table1\&quot;&gt;&lt;tr&gt;&lt;td width=\&quot;25%\&quot;&gt;&lt;div align=\&quot;center\&quot;&gt;&lt;strong&gt;Option name&lt;/strong&gt;&lt;/div&gt;&lt;/td&gt;&lt;td width=\&quot;75%\&quot;&gt;&lt;div align=\&quot;center\&quot;&gt;&lt;strong&gt;Option description&lt;/strong&gt;&lt;/td&gt;&lt;/tr&gt;.
        /// </summary>
        internal static string HTMLHeader {
            get {
                return ResourceManager.GetString("HTMLHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;tr&gt;&lt;td&gt;{0}&lt;/td&gt;&lt;td&gt;{1}&lt;/td&gt;&lt;/tr&gt;.
        /// </summary>
        internal static string HTMLRow {
            get {
                return ResourceManager.GetString("HTMLRow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Syntax: resx2html &lt;RESX-file&gt; &lt;result.html&gt; &lt;output format&gt;.
        /// </summary>
        internal static string WlxMsg {
            get {
                return ResourceManager.GetString("WlxMsg", resourceCulture);
            }
        }
    }
}
