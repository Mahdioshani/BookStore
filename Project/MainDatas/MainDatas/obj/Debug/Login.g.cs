#pragma checksum "..\..\Login.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1733D2B7A27FF31243B2D31EB516BCFF469F5D9CEED07B301BBF8E6D01F1F2FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MainDatas;
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


namespace MainDatas
{


    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 43 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem user;

#line default
#line hidden


#line 73 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameofUser;

#line default
#line hidden


#line 74 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Pass2;

#line default
#line hidden


#line 75 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Substitue2;

#line default
#line hidden


#line 79 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showing2;

#line default
#line hidden


#line 83 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem admin;

#line default
#line hidden


#line 114 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Pass1;

#line default
#line hidden


#line 115 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Substitue1;

#line default
#line hidden


#line 119 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showing1;

#line default
#line hidden


#line 123 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem signup;

#line default
#line hidden


#line 151 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;

#line default
#line hidden


#line 152 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;

#line default
#line hidden


#line 153 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Repeat;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MainDatas;component/login.xaml", System.UriKind.Relative);

#line 1 "..\..\Login.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.user = ((System.Windows.Controls.TabItem)(target));
                    return;
                case 2:
                    this.nameofUser = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.Pass2 = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 4:
                    this.Substitue2 = ((System.Windows.Controls.TextBox)(target));

#line 75 "..\..\Login.xaml"
                    this.Substitue2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameofUser2_TextChanged);

#line default
#line hidden
                    return;
                case 5:

#line 77 "..\..\Login.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.showing2 = ((System.Windows.Controls.CheckBox)(target));

#line 79 "..\..\Login.xaml"
                    this.showing2.Checked += new System.Windows.RoutedEventHandler(this.Showing2_Checked);

#line default
#line hidden

#line 80 "..\..\Login.xaml"
                    this.showing2.Unchecked += new System.Windows.RoutedEventHandler(this.Showing2_Unchecked);

#line default
#line hidden
                    return;
                case 7:
                    this.admin = ((System.Windows.Controls.TabItem)(target));
                    return;
                case 8:
                    this.Pass1 = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 9:
                    this.Substitue1 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:

#line 117 "..\..\Login.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);

#line default
#line hidden
                    return;
                case 11:
                    this.showing1 = ((System.Windows.Controls.CheckBox)(target));

#line 119 "..\..\Login.xaml"
                    this.showing1.Checked += new System.Windows.RoutedEventHandler(this.Showing_Checked);

#line default
#line hidden

#line 120 "..\..\Login.xaml"
                    this.showing1.Unchecked += new System.Windows.RoutedEventHandler(this.Showing_Unchecked);

#line default
#line hidden
                    return;
                case 12:
                    this.signup = ((System.Windows.Controls.TabItem)(target));
                    return;
                case 13:
                    this.password = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 14:
                    this.Email = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 15:
                    this.Repeat = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 16:

#line 154 "..\..\Login.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.RadioButton adminn;
        internal System.Windows.Controls.RadioButton Users;
        internal System.Windows.Controls.TextBox user1;
    }
}

