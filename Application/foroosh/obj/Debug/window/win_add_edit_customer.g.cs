﻿#pragma checksum "..\..\..\window\win_add_edit_customer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D077796030AADCFE75844B5C22BB5496E337616"
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
using RootLibrary.WPF.Localization;
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
    /// win_add_edit_customer
    /// </summary>
    public partial class win_add_edit_customer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_close;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_customerName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_telcustomer;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_customerAddress;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Ok;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_username;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\window\win_add_edit_customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_date;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\window\win_add_edit_customer.xaml"
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
            System.Uri resourceLocater = new System.Uri("/foroosh;component/window/win_add_edit_customer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\window\win_add_edit_customer.xaml"
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
            
            #line 9 "..\..\..\window\win_add_edit_customer.xaml"
            ((foroosh.window.win_add_edit_customer)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image_close = ((System.Windows.Controls.Image)(target));
            
            #line 13 "..\..\..\window\win_add_edit_customer.xaml"
            this.image_close.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.image_close_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_customerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_telcustomer = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\window\win_add_edit_customer.xaml"
            this.txt_telcustomer.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txt_telcustomer_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_customerAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_Ok = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\window\win_add_edit_customer.xaml"
            this.btn_Ok.Click += new System.Windows.RoutedEventHandler(this.btn_Ok_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\window\win_add_edit_customer.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbl_username = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbl_date = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.calendar = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

