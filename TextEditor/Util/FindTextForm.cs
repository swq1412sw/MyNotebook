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
    public partial class FindTextForm : Form
    {
        internal TextBox textBox;

        public FindTextForm(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            button1.Click += new EventHandler(FindText_click);
            button2.Click += new EventHandler(Cancle_click);
        }

        public FindTextForm(TextBox textBox, string text):this(textBox)
        {
            this.textBox1.Text = text;
        }

        private void FindText_click(object sender, EventArgs e) 
        {
            string text = radioButton2.Checked ? textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength) : textBox.Text.Substring(0, textBox.SelectionStart);
            int initlengh = radioButton2.Checked ? textBox.SelectionStart + textBox.SelectionLength : 0;
            int index =  KMPUtil.Search(text, textBox1.Text, radioButton1.Checked);
            if (index != -1)
            {
                textBox.SelectionStart = index+initlengh;
                textBox.SelectionLength = textBox1.TextLength;
                textBox.ScrollToCaret();
            }
            else 
            {
                MessageBox.Show("在指定区域内未找到符合的内容");
            }
        }

        private void Cancle_click(object sender, EventArgs e) 
        {
            Close();
        }


    }
}
