﻿#pragma checksum "..\..\..\window\win_inventory.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40D1185E619268D38E4E8126096E368BEA69CCC1"
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
    /// win_inventory
    /// </summary>
    public partial class win_inventory : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imge_close;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_inventory;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_newTrans;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_username;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker calendar_az;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker calendar_ta;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_search;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_productname;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\window\win_inventory.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_type;
        
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
            System.Uri resourceLocater = new System.Uri("/foroosh;component/window/win_inventory.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\window\win_inventory.xaml"
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
            
            #line 9 "..\..\..\window\win_inventory.xaml"
            ((foroosh.window.win_inventory)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\window\win_inventory.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imge_close = ((System.Windows.Controls.Image)(target));
            
            #line 24 "..\..\..\window\win_inventory.xaml"
            this.imge_close.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imge_close_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid_inventory = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btn_newTrans = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\..\window\win_inventory.xaml"
            this.btn_newTrans.Click += new System.Windows.RoutedEventHandler(this.btn_newTrans_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\..\window\win_inventory.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.calendar_az = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            case 9:
            this.calendar_ta = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            case 10:
            this.image_search = ((System.Windows.Controls.Image)(target));
            
            #line 168 "..\..\..\window\win_inventory.xaml"
            this.image_search.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.image_search_MouseDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lbl_productname = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.cmb_type = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
