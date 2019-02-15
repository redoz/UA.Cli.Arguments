﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UA.Cli.Arguments.Resources {
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
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UA.Cli.Arguments.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        ///   Looks up a localized string similar to Argument &apos;{0}&apos; does not distinguish between parameters: {1}.
        /// </summary>
        internal static string AmbigiousName {
            get {
                return ResourceManager.GetString("AmbigiousName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument &apos;{0}&apos; does not match any parameter..
        /// </summary>
        internal static string ArgumentNameMismatch {
            get {
                return ResourceManager.GetString("ArgumentNameMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument &apos;{0}&apos; does not match any positional parameter..
        /// </summary>
        internal static string ArgumentPositionMismatch {
            get {
                return ResourceManager.GetString("ArgumentPositionMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to apply argument &apos;{0}&apos; to parameter {1}.
        /// </summary>
        internal static string IncompatibleType {
            get {
                return ResourceManager.GetString("IncompatibleType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception of type {4} occured calling method {2}.{3} while processing argument &apos;{0}&apos; for parameter {1}: {5}.
        /// </summary>
        internal static string MethodInvocationFailed {
            get {
                return ResourceManager.GetString("MethodInvocationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command not found &apos;{0}&apos;..
        /// </summary>
        internal static string MissingCommand {
            get {
                return ResourceManager.GetString("MissingCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing requried paramter: &apos;{0}&apos;..
        /// </summary>
        internal static string MissingRequiredParameter {
            get {
                return ResourceManager.GetString("MissingRequiredParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter &apos;{0}&apos; requires a value but none was specified..
        /// </summary>
        internal static string MissingValue {
            get {
                return ResourceManager.GetString("MissingValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot bind parameter because parameter &apos;{0}&apos; is specified more than once. To provide multiple values to parameters that can accept multiple values, use the array syntax. For example, &quot;-parameter value1,value2,value3&quot; or &quot;-parameter @(value1,value2,value3)&quot;..
        /// </summary>
        internal static string MultipleBindings {
            get {
                return ResourceManager.GetString("MultipleBindings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception of type {3} occured creating instance of type {2} while processing argument &apos;{0}&apos; for parameter {1}: {4}.
        /// </summary>
        internal static string ObjectInitializationFailed {
            get {
                return ResourceManager.GetString("ObjectInitializationFailed", resourceCulture);
            }
        }
    }
}
