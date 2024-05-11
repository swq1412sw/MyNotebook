using System.Text;

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

        private async void ReplaceAll_click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text) 
            {
                MessageBox.Show("无需更换");
                return;
            }
            int start =Environment.TickCount;
            string oldText = textBox.Text;
            string findText = textBox1.Text;
            string replaceText = textBox2.Text;
            string newText = oldText.Replace(findText,replaceText);
            Task<int> numTask = Task<int>.Run(()=> KMPUtil.KMPSearch(oldText, findText).Count()); 
            int re = Environment.TickCount;
            textBox.Text = newText;
            int end = Environment.TickCount;
            int count = await numTask;
            MessageBox.Show($"全部更换完成，一共{count}处被替换,查找替换用时{re-start}，渲染用时{end-re}，总用时{end-start}");
        }

            private void Cancle_click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
