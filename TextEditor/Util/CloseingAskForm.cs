using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor.TextEditor.Util
{
    public partial class CloseingAskForm : Form
    {
        string filename = string.Empty;
        EventHandler eventHandler; 
        public CloseingAskForm(EventHandler e, string _name)
        {
            eventHandler = e;
            filename = string.IsNullOrEmpty(_name) ? filename : $"文件： {_name}   的";
            InitializeComponent();
            label1.Text = filename + label1.Text;
            button1.Click += new EventHandler(Exit_click);
            button2.Click += new EventHandler(Save_click);
            button3.Click += new EventHandler(Cancle_click);
        }

        private void Exit_click(object o, EventArgs e) 
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private  void Save_click(object o, EventArgs e) 
        {
            eventHandler.Invoke(this, EventArgs.Empty);
            this.DialogResult = DialogResult.Yes; this.Close();
        }

        private void Cancle_click(object o, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
