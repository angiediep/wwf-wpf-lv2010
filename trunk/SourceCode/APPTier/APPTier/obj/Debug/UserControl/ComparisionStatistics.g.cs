﻿#pragma checksum "..\..\..\UserControl\ComparisionStatistics.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FCC3AC7A96B8BFFE3521FE29E33F3F10"
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
using System.Windows.Controls.DataVisualization.Charting;
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
    /// ComparisionStatistics
    /// </summary>
    public partial class ComparisionStatistics : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal APPTier.ComparisionStatistics UserControl;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 344 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Label lblMonth1;
        
        #line default
        #line hidden
        
        
        #line 345 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Label lblYear1;
        
        #line default
        #line hidden
        
        
        #line 346 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.ComboBox cbxMonth1;
        
        #line default
        #line hidden
        
        
        #line 349 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.ComboBox cbxYear1;
        
        #line default
        #line hidden
        
        
        #line 352 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Label lblFuncName;
        
        #line default
        #line hidden
        
        
        #line 353 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Label lblMonth2;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Label lblYear2;
        
        #line default
        #line hidden
        
        
        #line 355 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.ComboBox cbxMonth2;
        
        #line default
        #line hidden
        
        
        #line 358 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.ComboBox cbxYear2;
        
        #line default
        #line hidden
        
        
        #line 368 "..\..\..\UserControl\ComparisionStatistics.xaml"
        internal System.Windows.Controls.Button btnApply;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThi;component/usercontrol/comparisionstatistics.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl\ComparisionStatistics.xaml"
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
            this.UserControl = ((APPTier.ComparisionStatistics)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblMonth1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblYear1 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cbxMonth1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbxYear1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.lblFuncName = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblMonth2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblYear2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cbxMonth2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.cbxYear2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.btnApply = ((System.Windows.Controls.Button)(target));
            
            #line 368 "..\..\..\UserControl\ComparisionStatistics.xaml"
            this.btnApply.Click += new System.Windows.RoutedEventHandler(this.btnApply_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
