﻿

#pragma checksum "C:\sqlite\C#\SQLiteWp8.1\Views\AddReceipt.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2742636003A92DCE366078AB2D3B38F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLiteWp8._1.Views
{
    partial class AddReceipt : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 41 "..\..\..\Views\AddReceipt.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddImage_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 48 "..\..\..\Views\AddReceipt.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddReceipt_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 20 "..\..\..\Views\AddReceipt.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.TextBlock_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

