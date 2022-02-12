﻿#pragma checksum "..\..\..\..\Pages\EditDelivery.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5CAC40ED69BAECA3DB291E1E0CDA28FF98B00A1C"
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
    /// EditDelivery
    /// </summary>
    public partial class EditDelivery : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView initial_Order;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox category;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stocks;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_btn;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_btn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock productID;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox brand;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Pages\EditDelivery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock productID_Copy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Atlas;component/pages/editdelivery.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\EditDelivery.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.initial_Order = ((System.Windows.Controls.ListView)(target));
            
            #line 40 "..\..\..\..\Pages\EditDelivery.xaml"
            this.initial_Order.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.initial_Order_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.category = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.stocks = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.save_btn = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\Pages\EditDelivery.xaml"
            this.save_btn.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\Pages\EditDelivery.xaml"
            this.cancel_btn.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.productID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.brand = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.productID_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

