﻿#pragma checksum "..\..\Child.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0F15947FC515C655AFDF10352A3D2CC3E5FE38B7DA0B5B94040A0E7090092F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// Child
    /// </summary>
    public partial class Child : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker childBirthDatePicker;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox childFistNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox childIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox momIdComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox specialBoyCheckBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Child.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox specialBoyDetailsTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/child.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Child.xaml"
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
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.childBirthDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.childFistNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.childIdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\Child.xaml"
            this.childIdTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.childIdTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 30 "..\..\Child.xaml"
            this.childIdTextBox.DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.childIdTextBox_DataContextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.momIdComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\Child.xaml"
            this.momIdComboBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.childIdTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.specialBoyCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.specialBoyDetailsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 40 "..\..\Child.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 45 "..\..\Child.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

