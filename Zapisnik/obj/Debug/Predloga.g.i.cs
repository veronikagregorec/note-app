﻿#pragma checksum "..\..\Predloga.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5915BED60BBC6239CFDD33DEA80A46B2BE278E5395D49214184EF3531CED699A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using Zapisnik;


namespace Zapisnik {
    
    
    /// <summary>
    /// Predloga
    /// </summary>
    public partial class Predloga : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Predloga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridPredloga;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Predloga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxPredloga;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Predloga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button dodaj;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Predloga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izbriši;
        
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
            System.Uri resourceLocater = new System.Uri("/Zapisnik;component/predloga.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Predloga.xaml"
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
            this.gridPredloga = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\Predloga.xaml"
            this.gridPredloga.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.GridPredloga_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtBoxPredloga = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Predloga.xaml"
            this.dodaj.Click += new System.Windows.RoutedEventHandler(this.Dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.izbriši = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Predloga.xaml"
            this.izbriši.Click += new System.Windows.RoutedEventHandler(this.Izbriši_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
