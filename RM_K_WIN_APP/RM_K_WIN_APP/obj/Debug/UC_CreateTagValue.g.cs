#pragma checksum "..\..\UC_CreateTagValue.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8919BE7F04C8295160A490E15E1873B55F855D3C2685A04D2B2E08AD81327A74"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RM_K_WIN_APP;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RM_K_WIN_APP {
    
    
    /// <summary>
    /// UC_CreateTagValue
    /// </summary>
    public partial class UC_CreateTagValue : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmBxResourceName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmBxTagName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TagValuePanel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTagName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textTagVal;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tagValueUOM;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddTagValue;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\UC_CreateTagValue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RM_K_WIN_APP;component/uc_createtagvalue.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UC_CreateTagValue.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmBxResourceName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\UC_CreateTagValue.xaml"
            this.cmBxResourceName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmBxResourceName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmBxTagName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\UC_CreateTagValue.xaml"
            this.cmBxTagName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmBxTagName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TagValuePanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.labelTagName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.textTagVal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tagValueUOM = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnAddTagValue = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\UC_CreateTagValue.xaml"
            this.btnAddTagValue.Click += new System.Windows.RoutedEventHandler(this.btnAddTagValue_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnImport = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\UC_CreateTagValue.xaml"
            this.btnImport.Click += new System.Windows.RoutedEventHandler(this.btnImport_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

