﻿#pragma checksum "..\..\..\window\win_product.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76BD65B08DED0FF00608691E6DC9500FA34A0810"
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
    /// win_product
    /// </summary>
    public partial class win_product : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imge_close;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_product;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_newproduct;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_editproduct;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_delproduct;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Name;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker calendar_az;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Arash.PersianDateControls.PersianDatePicker calendar_ta;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_search;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_status;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_active;
        
        #line default
        #line hidden
        
        
        #line 262 "..\..\..\window\win_product.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdb_deactive;
        
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
            System.Uri resourceLocater = new System.Uri("/foroosh;component/window/win_product.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\window\win_product.xaml"
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
            
            #line 9 "..\..\..\window\win_product.xaml"
            ((foroosh.window.win_product)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\window\win_product.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imge_close = ((System.Windows.Controls.Image)(target));
            
            #line 24 "..\..\..\window\win_product.xaml"
            this.imge_close.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imge_close_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid_product = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 218 "..\..\..\window\win_product.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ShowPrice_click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 223 "..\..\..\window\win_product.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_showInventory_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_newproduct = ((System.Windows.Controls.Button)(target));
            
            #line 235 "..\..\..\window\win_product.xaml"
            this.btn_newproduct.Click += new System.Windows.RoutedEventHandler(this.btn_newproduct_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_editproduct = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\window\win_product.xaml"
            this.btn_editproduct.Click += new System.Windows.RoutedEventHandler(this.btn_editproduct_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.bt_delproduct = ((System.Windows.Controls.Button)(target));
            
            #line 245 "..\..\..\window\win_product.xaml"
            this.bt_delproduct.Click += new System.Windows.RoutedEventHandler(this.bt_delproduct_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.calendar_az = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            case 12:
            this.calendar_ta = ((Arash.PersianDateControls.PersianDatePicker)(target));
            return;
            case 13:
            this.image_search = ((System.Windows.Controls.Image)(target));
            
            #line 258 "..\..\..\window\win_product.xaml"
            this.image_search.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.image_search_MouseDown);
            
            #line default
            #line hidden
            return;
            case 14:
            this.cmb_status = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.rdb_active = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 16:
            this.rdb_deactive = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
