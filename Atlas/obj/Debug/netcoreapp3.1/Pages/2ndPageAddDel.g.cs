﻿#pragma checksum "..\..\..\..\Pages\2ndPageAddDel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DC74F54468C55F5F3824B0B1F675C4C524142BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Atlas.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Atlas.Pages {
    
    
    /// <summary>
    /// _2ndPageAddDel
    /// </summary>
    public partial class _2ndPageAddDel : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView inventory_list;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_btn;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_btn;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Category_Cmbox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView initial_Order;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalamount;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantityValue;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Order;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_orders;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\Pages\2ndPageAddDel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label sel_Customerlbl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Atlas;component/pages/2ndpageadddel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.inventory_list = ((System.Windows.Controls.ListView)(target));
            
            #line 31 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.inventory_list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.inventory_list_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.add_btn = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.add_btn.Click += new System.Windows.RoutedEventHandler(this.add_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.back_btn = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.back_btn.Click += new System.Windows.RoutedEventHandler(this.go_back_btn_click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Category_Cmbox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 83 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.Category_Cmbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Category_Cmbox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.initial_Order = ((System.Windows.Controls.ListView)(target));
            
            #line 96 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.initial_Order.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.initial_Order_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.totalamount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.quantityValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_Order = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.btn_Order.Click += new System.Windows.RoutedEventHandler(this.btn_Order_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cancel_orders = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\..\Pages\2ndPageAddDel.xaml"
            this.cancel_orders.Click += new System.Windows.RoutedEventHandler(this.cancel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sel_Customerlbl = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

