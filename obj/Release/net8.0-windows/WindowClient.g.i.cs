﻿#pragma checksum "..\..\..\WindowClient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06EF5608C11FA1C7750C2CF2A2FCDBB620CAFDC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using InternetMagazine;
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


namespace InternetMagazine {
    
    
    /// <summary>
    /// WindowClient
    /// </summary>
    public partial class WindowClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockUserStatus;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockUserLogin;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockUserName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridProducts;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridOrders;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSearchProduct;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonUpdateList;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\WindowClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOrder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InternetMagazine;component/windowclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowClient.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlockUserStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBlockUserLogin = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBlockUserName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 5:
            this.dataGridProducts = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.dataGridOrders = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.textBoxSearchProduct = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\WindowClient.xaml"
            this.textBoxSearchProduct.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxSearchProduct_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonUpdateList = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\WindowClient.xaml"
            this.buttonUpdateList.Click += new System.Windows.RoutedEventHandler(this.buttonUpdateList_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttonOrder = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\WindowClient.xaml"
            this.buttonOrder.Click += new System.Windows.RoutedEventHandler(this.buttonOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
