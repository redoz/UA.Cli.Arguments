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
    internal class Exceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Exceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UA.Cli.Arguments.Resources.Exceptions", typeof(Exceptions).Assembly);
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
        ///   Looks up a localized string similar to Coult not convert default value &apos;{0}&apos; of type {1} into target type {2}..
        /// </summary>
        internal static string FailedToConvertDefaultValue {
            get {
                return ResourceManager.GetString("FailedToConvertDefaultValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not convert default value &apos;{0}&apos; into {1}..
        /// </summary>
        internal static string FailedToParseDefaultValue {
            get {
                return ResourceManager.GetString("FailedToParseDefaultValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No implementation for interface found: {0}.
        /// </summary>
        internal static string FailedToResolveInterfaceType {
            get {
                return ResourceManager.GetString("FailedToResolveInterfaceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported array type: {0}. Associative arrays can only be assigned to arrays of KeyValuePair&lt;TKey, TValue&gt; or Tuple&lt;TKey, TValue&gt;..
        /// </summary>
        internal static string UnsupportedAssocParameterArrayType {
            get {
                return ResourceManager.GetString("UnsupportedAssocParameterArrayType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported array type: {0}. More than one public constructor taking two parameters found..
        /// </summary>
        internal static string UnsupportedAssocParameterArrayTypeAmbiguousConstructor {
            get {
                return ResourceManager.GetString("UnsupportedAssocParameterArrayTypeAmbiguousConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported array type: {0}. No public constructor taking two parameters found..
        /// </summary>
        internal static string UnsupportedAssocParameterArrayTypeNoConstructor {
            get {
                return ResourceManager.GetString("UnsupportedAssocParameterArrayTypeNoConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsupported parameter type {0}..
        /// </summary>
        internal static string UnsupportedParameterType {
            get {
                return ResourceManager.GetString("UnsupportedParameterType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No suitable &apos;Add&apos; method found on type {0}..
        /// </summary>
        internal static string UnsupportedParameterTypeNoAddMethod {
            get {
                return ResourceManager.GetString("UnsupportedParameterTypeNoAddMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No default constructor found on type {0}..
        /// </summary>
        internal static string UnsupportedParameterTypeNoDefaultConstructor {
            get {
                return ResourceManager.GetString("UnsupportedParameterTypeNoDefaultConstructor", resourceCulture);
            }
        }
    }
}

