﻿#pragma checksum "..\..\..\UserControl\ChangeWorkTimebyTime.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "05A08883FFB2379043CAF60C3BF3CC05"
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
    /// ChangeWorkTimebyTime
    /// </summary>
    public partial class ChangeWorkTimebyTime : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
        internal APPTier.ChangeWorkTimebyTime UserControl;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
        internal System.Windows.Controls.Label lblFuncName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
        internal Microsoft.Windows.Controls.DataGrid dtgvWorkItem;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/usercontrol/changeworktimebytime.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
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
            this.UserControl = ((APPTier.ChangeWorkTimebyTime)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblFuncName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.dtgvWorkItem = ((Microsoft.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\UserControl\ChangeWorkTimebyTime.xaml"
            this.dtgvWorkItem.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dtgvWorkItem_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

