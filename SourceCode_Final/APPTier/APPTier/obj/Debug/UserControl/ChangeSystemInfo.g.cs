﻿#pragma checksum "..\..\..\UserControl\ChangeSystemInfo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F71BAF7B62D9961984984570D17E920B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// ChangeSystemInfo
    /// </summary>
    public partial class ChangeSystemInfo : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal APPTier.ChangeSystemInfo UserControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Label lblFuncName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Label lblDatabaseName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Label lblUserID;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Label lblPass;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Label lblServerName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.TextBox tbxServerName;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.TextBox tbxDatabaseName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.TextBox tbxUserID;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.TextBox tbxPass;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControl\ChangeSystemInfo.xaml"
        internal System.Windows.Controls.Button btnReset;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/usercontrol/changesysteminfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\ChangeSystemInfo.xaml"
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
            this.UserControl = ((APPTier.ChangeSystemInfo)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblFuncName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblDatabaseName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblUserID = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblPass = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblServerName = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.tbxServerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.tbxDatabaseName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbxUserID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbxPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\UserControl\ChangeSystemInfo.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\UserControl\ChangeSystemInfo.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\UserControl\ChangeSystemInfo.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
