﻿#pragma checksum "..\..\..\..\Views\ELAView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A4EF8E0CA40E825C65809A55968ADF19CE8E4557"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro;
using Caliburn.Micro.Tutorial.Wpf.ViewModels;
using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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


namespace Caliburn.Micro.Tutorial.Wpf.Views {
    
    
    /// <summary>
    /// ELAView
    /// </summary>
    public partial class ELAView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DateTimePicker wfTimeFrom;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DateTimePicker wfTimeTo;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ChamberItems;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ToolItems;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddFile;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogSummary;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DataCommand;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RecipeData;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox DataListItems;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchText;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchCommand;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\Views\ELAView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ActiveItem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Caliburn.Micro.Tutorial.Wpf;V1.0.1;component/views/elaview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ELAView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.wfTimeFrom = ((System.Windows.Forms.DateTimePicker)(target));
            return;
            case 2:
            this.wfTimeTo = ((System.Windows.Forms.DateTimePicker)(target));
            return;
            case 3:
            this.ChamberItems = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.ToolItems = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.AddFile = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.LogSummary = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.DataCommand = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.RecipeData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.DataListItems = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            this.SearchText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.SearchCommand = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.ActiveItem = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

