﻿#pragma checksum "..\..\ChangeWorkTimebyTimeDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8C8437C1EF05F70DBC64D24BD58EC89"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
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
    /// ChangeWorkTimebyTimeDetail
    /// </summary>
    public partial class ChangeWorkTimebyTimeDetail : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 8 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal APPTier.ChangeWorkTimebyTimeDetail Window;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Label lblNgayThi;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.TextBox tbxNgayBatDau;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.TextBlock lblFuncName;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Label lblTenDotThi;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.TextBlock tbxTenCV;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\ChangeWorkTimebyTimeDetail.xaml"
        internal System.Windows.Controls.TextBox tbxNgayKetThuc;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/changeworktimebytimedetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChangeWorkTimebyTimeDetail.xaml"
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
            this.Window = ((APPTier.ChangeWorkTimebyTimeDetail)(target));
            return;
            case 4:
            
            #line 106 "..\..\ChangeWorkTimebyTimeDetail.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblNgayThi = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tbxNgayBatDau = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\ChangeWorkTimebyTimeDetail.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblFuncName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.lblTenDotThi = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.tbxTenCV = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.tbxNgayKetThuc = ((System.Windows.Controls.TextBox)(target));
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
            
            #line 50 "..\..\ChangeWorkTimebyTimeDetail.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.btnMinimize_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 79 "..\..\ChangeWorkTimebyTimeDetail.xaml"
            ((System.Windows.Shapes.Path)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.btnClose_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
