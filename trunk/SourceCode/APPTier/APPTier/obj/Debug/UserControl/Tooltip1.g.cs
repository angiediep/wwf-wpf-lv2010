﻿#pragma checksum "..\..\..\UserControl\Tooltip1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B526ACB3DE5750BA5AB2A4CACD06DAAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
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
    /// Tooltip1
    /// </summary>
    public partial class Tooltip1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UserControl\Tooltip1.xaml"
        internal APPTier.Tooltip1 UserControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UserControl\Tooltip1.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserControl\Tooltip1.xaml"
        internal System.Windows.Controls.TextBlock tbxContent;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserControl\Tooltip1.xaml"
        internal System.Windows.Controls.Button btnStart;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControl\Tooltip1.xaml"
        internal System.Windows.Controls.Button btnChange;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserControl\Tooltip1.xaml"
        internal System.Windows.Controls.Button btnFinish;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/usercontrol/tooltip1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\Tooltip1.xaml"
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
            this.UserControl = ((APPTier.Tooltip1)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tbxContent = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\UserControl\Tooltip1.xaml"
            this.btnStart.Click += new System.Windows.RoutedEventHandler(this.btnStart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnChange = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\UserControl\Tooltip1.xaml"
            this.btnChange.Click += new System.Windows.RoutedEventHandler(this.btnChange_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnFinish = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\UserControl\Tooltip1.xaml"
            this.btnFinish.Click += new System.Windows.RoutedEventHandler(this.btnFinish_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
