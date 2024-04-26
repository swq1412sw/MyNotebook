using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor.TextEditor.Util
{
    public partial class ReplaceForm : Form
    {
        internal TextBox textBox;

        public ReplaceForm(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            button1.Click += new EventHandler(FindText_click);
            button2.Click += new EventHandler(Cancle_click);
            button3.Click += new EventHandler(Replace_click);
            button4.Click += new EventHandler(ReplaceAll_click);
        }

        public ReplaceForm(TextBox textBox, string text) : this(textBox)
        {
            this.textBox1.Text = text;
        }

        private void FindText_click(object sender, EventArgs e)
        {
            string text = radioButton2.Checked ? textBox.Text.Substring(textBox.SelectionStart+textBox.SelectionLength) : textBox.Text.Substring(0, textBox.SelectionStart);
            int initlengh = radioButton2.Checked ? textBox.SelectionStart + textBox.SelectionLength : 0;
            int index = KMPUtil.Search(text, textBox1.Text, radioButton1.Checked);
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


        private void Replace_click(object sender, EventArgs e) 
        {
            if (textBox.SelectedText == textBox1.Text)
            {
                StringBuilder newText = new StringBuilder(textBox.Text);
                newText.Remove(textBox.SelectionStart, textBox.TextLength);
                newText.Insert(textBox.SelectionStart, textBox1.Text);
                textBox.Text = newText.ToString();
            }
            else 
            {
                MessageBox.Show("请先查询");
            }
        }

        private void ReplaceAll_click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text) 
            {
                MessageBox.Show("无需更换");
                return;
            }
            // 使用StringBuilder来构建新的文本内容
            StringBuilder newText = new StringBuilder(textBox.Text);
            int index = KMPUtil.Search(newText.ToString(), textBox1.Text, false);
            int count = 0;
            int initlengh = 0;
            // 循环替换所有匹配项
            while (index != -1)
            {
                newText.Remove(index+initlengh, textBox1.TextLength);
                newText.Insert(index+initlengh, textBox2.Text);
                count++;
                int temp = index + initlengh;
                index = KMPUtil.Search(newText.ToString().Substring(temp+textBox1.SelectionLength), textBox1.Text, false);
                initlengh = temp + textBox1.SelectionLength;
            }

            // 更新textBox的内容
            textBox.Text = newText.ToString();
            MessageBox.Show($"全部更换完成，一共{count}处被替换");
        }

            private void Cancle_click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
