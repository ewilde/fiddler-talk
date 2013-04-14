using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace avalon.fiddler.plugin
{
    using ICSharpCode.AvalonEdit;

    public partial class ViewHost : UserControl
    {
        public ViewHost()
        {
            InitializeComponent();
            this.elementHost.Child = new avalon.fiddler.plugin.View();
        }

        public TextEditor TextEditor
        {
            get
            {
                return ((View)this.elementHost.Child).textEditor;
            }
        }
    }
}
