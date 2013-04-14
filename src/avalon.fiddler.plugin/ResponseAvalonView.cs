// -----------------------------------------------------------------------
// <copyright file="ResponseAvalonView.cs" company="UBS AG">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace avalon.fiddler.plugin
{
    using System.IO;
    using System.Windows.Forms;

    using Fiddler;

    public class ResponseAvalonView : Inspector2, IResponseInspector2, IBaseInspector2
    {
        public bool bDirty { get; private set; }

        public bool bReadOnly { get; set; }

        public HTTPResponseHeaders headers { get; set; }

        public override void AddToTab(TabPage o)
        {
            this.TabPage = o;
            this.TabPage.Text = "Avalon";
        }

        public override int GetOrder()
        {
            return -380;
        }

        public void Clear()
        {
            this.body = null;
        }

        public byte[] body
        {
            get
            {
                return null;
            }
            set
            {
                this.EnsureReady();
                if (value == null)
                {
                    this.View.TextEditor.Text = string.Empty;
                }
                else
                {
                    using (var bodyStream = new MemoryStream(value))
                    {
                        this.View.TextEditor.Load(bodyStream);
                    }   
                }
            }
        }

        protected TabPage TabPage { get; set; }

        protected ViewHost View { get; set; }

        private void EnsureReady()
        {
            if (this.View == null)
            {
                this.View = new avalon.fiddler.plugin.ViewHost();
                this.TabPage.Controls.Add(this.View);
                this.View.Dock = DockStyle.Fill;
            }
        }
    }
}