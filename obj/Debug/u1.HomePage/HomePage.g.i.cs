﻿#pragma checksum "..\..\..\u1.HomePage\HomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8742C49E0366C3FBAD39DF320A614A250F8D61370D0543E830EE6A7AC6E1FFAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PiTimeSolution.u1.HomePage;
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


namespace PiTimeSolution.u1.HomePage {
    
    
    /// <summary>
    /// HomePage
    /// </summary>
    public partial class HomePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid sidePanel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton storeBtn;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton captureBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton viewDatabtn;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton logOutBtn;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel windowContent;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\u1.HomePage\HomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock welcomeMsg;
        
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
            System.Uri resourceLocater = new System.Uri("/PiTimeSolution;component/u1.homepage/homepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\u1.HomePage\HomePage.xaml"
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
            
            #line 14 "..\..\..\u1.HomePage\HomePage.xaml"
            ((PiTimeSolution.u1.HomePage.HomePage)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sidePanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.MenuButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\u1.HomePage\HomePage.xaml"
            this.MenuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.storeBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 59 "..\..\..\u1.HomePage\HomePage.xaml"
            this.storeBtn.Click += new System.Windows.RoutedEventHandler(this.storeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.captureBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 72 "..\..\..\u1.HomePage\HomePage.xaml"
            this.captureBtn.Click += new System.Windows.RoutedEventHandler(this.captureBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.viewDatabtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 85 "..\..\..\u1.HomePage\HomePage.xaml"
            this.viewDatabtn.Click += new System.Windows.RoutedEventHandler(this.viewDatabtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.logOutBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 105 "..\..\..\u1.HomePage\HomePage.xaml"
            this.logOutBtn.Click += new System.Windows.RoutedEventHandler(this.logOutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.windowContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\u1.HomePage\HomePage.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 162 "..\..\..\u1.HomePage\HomePage.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.welcomeMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

