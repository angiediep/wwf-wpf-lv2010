﻿#pragma checksum "..\..\Register.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A0765B0737DA5CEC9D7F59F956E23897"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
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


namespace APPTier {
    
    
    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 6 "..\..\Register.xaml"
        internal APPTier.Register Window;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\Register.xaml"
        internal System.Windows.Controls.Label lblRealName;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Register.xaml"
        internal System.Windows.Controls.Label lblPassword;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\Register.xaml"
        internal System.Windows.Controls.Label lblPhone;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Register.xaml"
        internal System.Windows.Controls.Label lblEmail;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Register.xaml"
        internal System.Windows.Controls.TextBox tbxRealName;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\Register.xaml"
        internal System.Windows.Controls.PasswordBox tbxPassword;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Register.xaml"
        internal System.Windows.Controls.TextBox tbxPhone;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Register.xaml"
        internal System.Windows.Controls.TextBox tbxEmail;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Register.xaml"
        internal System.Windows.Controls.Button btnRegister;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\Register.xaml"
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Register.xaml"
        internal System.Windows.Controls.TextBlock lblFuncName;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\Register.xaml"
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Register.xaml"
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\Register.xaml"
        internal System.Windows.Controls.Label lblUsername;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\Register.xaml"
        internal System.Windows.Controls.TextBox tbxUsername;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/register.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Register.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((APPTier.Register)(target));
            return;
            case 4:
            
            #line 105 "..\..\Register.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblRealName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblPassword = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblPhone = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblEmail = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.tbxRealName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            this.tbxPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.tbxEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.btnRegister = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\Register.xaml"
            this.btnRegister.Click += new System.Windows.RoutedEventHandler(this.btnRegister_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\Register.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.lblFuncName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            return;
            case 18:
            this.lblUsername = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.tbxUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 49 "..\..\Register.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.btnMinimize_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 78 "..\..\Register.xaml"
            ((System.Windows.Shapes.Path)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.btnClose_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
