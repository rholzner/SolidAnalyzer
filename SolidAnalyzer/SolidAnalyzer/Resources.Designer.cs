﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolidAnalyzer {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SolidAnalyzer.Resources", typeof(Resources).GetTypeInfo().Assembly);
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
        ///   Looks up a localized string similar to Type names should be all uppercase..
        /// </summary>
        internal static string AnalyzerDescription {
            get {
                return ResourceManager.GetString("AnalyzerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type name &apos;{0}&apos; contains lowercase letters.
        /// </summary>
        internal static string AnalyzerMessageFormat {
            get {
                return ResourceManager.GetString("AnalyzerMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type name contains lowercase letters.
        /// </summary>
        internal static string AnalyzerTitle {
            get {
                return ResourceManager.GetString("AnalyzerTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking for null is viaualtion i OCP due to null is also an typ.
        /// </summary>
        internal static string Ocp0001Description {
            get {
                return ResourceManager.GetString("Ocp0001Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking for null is viaualtion i OCP due to null is also an typ.
        /// </summary>
        internal static string Ocp0001MessageFormat {
            get {
                return ResourceManager.GetString("Ocp0001MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code smell for OCP.
        /// </summary>
        internal static string Ocp0001Title {
            get {
                return ResourceManager.GetString("Ocp0001Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If you are using out parameter your method probebly has to many responsibilties.
        /// </summary>
        internal static string Srp0001Description {
            get {
                return ResourceManager.GetString("Srp0001Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter &apos;{0}&apos; uses out parameter not recomended in SRP.
        /// </summary>
        internal static string Srp0001MessageFormat {
            get {
                return ResourceManager.GetString("Srp0001MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter shoud not use out in SRP.
        /// </summary>
        internal static string Srp0001Title {
            get {
                return ResourceManager.GetString("Srp0001Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To keep methods simpel avoid nested if statments.
        /// </summary>
        internal static string Srp0002Description {
            get {
                return ResourceManager.GetString("Srp0002Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is an nested if statment. This code is in risk of breaking SRP.
        /// </summary>
        internal static string Srp0002MessageFormat {
            get {
                return ResourceManager.GetString("Srp0002MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nested if is a code smell for multiple responsibilities.
        /// </summary>
        internal static string Srp0002Title {
            get {
                return ResourceManager.GetString("Srp0002Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Switch statment inside if statment is an code smell for SRP.
        /// </summary>
        internal static string Srp0003Description {
            get {
                return ResourceManager.GetString("Srp0003Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Switch statment inside if statment is an code smell for SRP.
        /// </summary>
        internal static string Srp0003MessageFormat {
            get {
                return ResourceManager.GetString("Srp0003MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Switch statment inside if statment.
        /// </summary>
        internal static string Srp0003Title {
            get {
                return ResourceManager.GetString("Srp0003Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If in switch case is an code smell for SRP.
        /// </summary>
        internal static string Srp0004Description {
            get {
                return ResourceManager.GetString("Srp0004Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If in switch case in an code smell for SRP.
        /// </summary>
        internal static string Srp0004MessageFormat {
            get {
                return ResourceManager.GetString("Srp0004MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If in switch case.
        /// </summary>
        internal static string Srp0004Title {
            get {
                return ResourceManager.GetString("Srp0004Title", resourceCulture);
            }
        }
    }
}
