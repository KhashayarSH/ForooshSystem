﻿#pragma checksum "..\..\..\window\win.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BD5A3AA13874940FBBAB62CC9D3D3C4A1E480A4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Arash.PersianDateControls;
using Microsoft.Windows.Controls;
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
using foroosh.window;


namespace foroosh.window {
    
    
    /// <summary>
    /// Win_AddNewPrice
    /// </summary>
    public partial class Win_AddNewPrice : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_date;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_username;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_title;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ok;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_purch;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_sale;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_desc;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\window\win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker calendar;
        
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
            System.Uri resourceLocater = new System.Uri("/foroosh;component/window/win.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\window\win.xaml"
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
            
            #line 9 "..\..\..\window\win.xaml"
            ((foroosh.window.Win_AddNewPrice)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\window\win.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbl_date = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbl_username = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbl_title = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btn_ok = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\window\win.xaml"
            this.btn_ok.Click += new System.Windows.RoutedEventHandler(this.btn_ok_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\window\win.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txt_purch = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\window\win.xaml"
            this.txt_purch.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_purch_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txt_sale = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\window\win.xaml"
            this.txt_sale.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_sale_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_desc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.calendar = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

