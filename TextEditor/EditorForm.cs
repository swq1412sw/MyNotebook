using MyTextEditor.TextEditor;
using MyTextEditor.TextEditor.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyTextEditor
{
    public partial class EditorForm : Form
    {
        private string FilePath;
        private string FileName;
        private string TextTitle;
        private string OldText;
        bool SaveFlag = true;
        System.Windows.Forms.Timer timer = new();
        Encoding encoding = Encoding.UTF8;
        public EditorForm() : this(null,null)
        {
            
        }
        public  EditorForm(string filePath, string fileName)
        {
            InitializeComponent();
            SetFileInfo(filePath, fileName);
            this.Text = FileName ?? "无标题";
            autoMulToolStripMenuItem.CheckedChanged += (obj, e) => { textBox1.WordWrap = autoMulToolStripMenuItem.Checked; };
            stateToolStripMenuItem.CheckStateChanged += (obj, e) => { label1.Text = GetState(); timer.Enabled = stateToolStripMenuItem.Checked; panel1.Visible = stateToolStripMenuItem.Checked;   };
            stateToolStripMenuItem.CheckOnClick = true;
            stateToolStripMenuItem.Checked = true;
            this.autoMulToolStripMenuItem.CheckOnClick = true;
            this.autoMulToolStripMenuItem.Checked = true;
            newTexttoolStripMenuItem.Click += new EventHandler(NewInit);
            newFormToolStripMenuItem.Click += new EventHandler(OpenNewForm);
            newFormOpenToolStripMenuItem.Click += new EventHandler(OpenNewFormHasFile);
            saveToolStripMenuItem.Click += new EventHandler(SaveFile);
            saveOtherToolStripMenuItem.Click += new EventHandler(SaveFileOther);
            openFilelStripMenuItem4.Click += new EventHandler(LoadFile);
            copyToolStripMenuItem.Click += new EventHandler(CopyText);
            cutToolStripMenuItem.Click += new EventHandler(CutText);
            pasteToolStripMenuItem.Click += new EventHandler(PasteText);
            allSelectToolStripMenuItem.Click += new EventHandler(AllSelectText);
            findToolStripMenuItem.Click += new EventHandler(FindText);
            findUpToolStripMenuItem.Click += new EventHandler(FindUp);
            findNextToolStripMenuItem.Click += new EventHandler(FindDown);
            replaceToolStripMenuItem.Click += new EventHandler(ReplaceText);
            dataTimeToolStripMenuItem.Click += new EventHandler(GetTimeText);
            selectFontToolStripMenuItem.Click += new EventHandler(FontSet);
            addFontSizeToolStripMenuItem.Click += new EventHandler(FontSizeAddSet);
            subFontToolStripMenuItem.Click += new EventHandler(FontSizeSubSet);
            DefaultSizeToolStripMenuItem.Click += (obj, e) => { textBox1.Font = new Font("Microsoft YaHei UI", 9f); };
            textBox1.Font = new Font("Microsoft YaHei UI", 9f);
            aboutToolStripMenuItem.Click += (obj, e) => { MessageBox.Show("这个是关于"); };
            this.label1.Text = "第1行 ，第1列";
            textBox1.TextChanged += (obj, e) =>
            { 
                SetSaveFlag(OldText == textBox1.Text);
            };
            //状态栏的显示
            timer.Interval = 500;
            timer.Tick += (obj, e) =>
            {
                label1.BeginInvoke((MethodInvoker)delegate ()
                {
                    label1.Text = GetState();
                });
            };
            timer.Enabled = true;
            if (File.Exists(FilePath)) 
            {
                textBox1.ReadOnly = true;
                Task.Run(async () =>
                {
                    using (StreamReader sr = new StreamReader(FilePath, encoding))
                    {
                        textBox1.Text = string.Empty;
                        // 读取文件内容
                        while (!sr.EndOfStream)
                        {
                            char[] buffer = new char[40960]; // 读取缓冲区大小
                            int charsRead = await sr.ReadAsync(buffer, 0, buffer.Length);
                            string textPart = new string(buffer, 0, charsRead);
                            AppendLineToTextBox(GetFileEncodingText(textPart));
                        }
                        // 将内容设置到 TextBox 中
                        OldText = textBox1.Text;
                        SetSaveFlag(true);
                        textBox1.ReadOnly = false;
                    }
                });

            }
            //关闭之前的逻辑
            this.FormClosing += (sender, e) =>
            {
                if (!SaveFlag)
                {
                    CloseingAskForm closeingAskForm = new CloseingAskForm(SaveFile, FileName);
                    DialogResult result = closeingAskForm.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        if (SaveFlag)
                        {
                            timer.Stop();
                            timer.Enabled = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else 
                    {
                        timer.Stop();
                        timer.Enabled = false;
                    }

                }
                else 
                {
                    timer.Stop();
                    timer.Enabled = false;
                }
            };
            //字符编码
            List<string> commonEncodings = new List<string>
            {
                //"ASCII",
                //"ISO-8859-1 (Latin-1)",
                "UTF-8",
                //"UTF-16",
                //"GB2312",
                //"BIG5",
                //"GBK",
                //"GB18030",
                //Encoding.Default.EncodingName
            };
            comboBox1.DataSource = commonEncodings;
            comboBox1.SelectedIndexChanged += (obj, e) => {
              //  byte[] old = encoding.GetBytes(textBox1.Text);
                //Encoding temp = encoding;
                //encoding = Encoding.GetEncoding(comboBox1.SelectedValue.ToString());
               // byte[] newBytes = Encoding.Convert(temp, encoding, old);
               // textBox1.Text = encoding.GetString(newBytes);
               // MessageBox.Show("已更换字符集");
            };
            comboBox1.SelectedIndex= 0;
            encoding = Encoding.GetEncoding(commonEncodings[0]);

            
        }

       // private async void Load_ByEncoding() 
        //{
            //if (File.Exists(FilePath))
            //{
            //    using (StreamReader sr = new StreamReader(FilePath, encoding))
            //    {
            //        // 读取文件内容
            //        string content = await sr.ReadToEndAsync();
            //        // 将内容设置到 TextBox 中
            //        OldText = content;
            //        textBox1.Text = content;
            //        SetSaveFlag(true);
            //    }

            //}
            
       // }
        private string GetState() 
        {
            int cursorPosition = textBox1.SelectionStart+textBox1.SelectionLength;
            int lineNumber = textBox1.GetLineFromCharIndex(cursorPosition) + 1;
            int columnIndex = cursorPosition - textBox1.GetFirstCharIndexOfCurrentLine() + 1;
            return $"第{lineNumber}行 ， 第{columnIndex}列 ，文件编码方式为  ";
        }
        private void SetFileInfo(string filePath,string fileName) 
        {
            FilePath = filePath;
            FileName = fileName;
            if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))
            {
                this.TextTitle = "无标题";
            }
            else 
            {
                this.TextTitle = FileName;
            }
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
        }

        //新建

        private void NewInit(object o, EventArgs e) 
        {
            if (textBox1.ReadOnly) return;
            SetFileInfo(null, null);
            SetSaveFlag(true);
            OldText = string.Empty;
            textBox1.Text = string.Empty;
            encoding = Encoding.UTF8;
        }

        private void SetSaveFlag(bool flag) 
        {
            SaveFlag = flag;
            Text = TextTitle + (flag ? "" : " *(未保存)");
        }
        //打开
        private void LoadFile(object o,EventArgs e) 
        {
            if (textBox1.ReadOnly) return;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    if (File.Exists(openFileDialog1.FileName)) 
                    {
                        textBox1.ReadOnly = true;
                        Task.Run(async () => {
                            using (StreamReader sr = new StreamReader(openFileDialog1.FileName, encoding))
                            {
                                textBox1.Text = string.Empty;
                                SetFileInfo(openFileDialog1.FileName, Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                                // 读取文件内容
                                while (!sr.EndOfStream)
                                {
                                    char[] buffer = new char[40960]; // 读取缓冲区大小
                                    int charsRead = await sr.ReadAsync(buffer, 0, buffer.Length);
                                    string textPart = new string(buffer, 0, charsRead);
                                    AppendLineToTextBox(GetFileEncodingText(textPart));
                                }
                                // 将内容设置到 TextBox 中

                                OldText = textBox1.Text;
                                SetSaveFlag(true);
                                textBox1.ReadOnly = false;
                            }
                        });
                    }              
                }  
            }
        }
        //批量添加到文本框
        private void AppendLineToTextBox(string line)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((Action)(() => AppendLineToTextBox(line)));
            }
            else
            {
                textBox1.AppendText(line);
            }
        }



        // 新窗口
        private void OpenNewForm(object o, EventArgs e) 
        {
            Process.Start(Application.ExecutablePath);    
        }

        //新窗口打开
        private void OpenNewFormHasFile(object o, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Arguments = $"\"{openFileDialog1.FileName}\" \"{Path.GetFileNameWithoutExtension(openFileDialog1.FileName)}\""; // 传递的参数
                Process.Start(startInfo);
            }
        }

        //保存
        private  void SaveFile(object o, EventArgs e) 
        {
            if (textBox1.ReadOnly) return;
            if (File.Exists(FilePath))
            {
                textBox1.ReadOnly = true;
                Task.Run(async () =>
                {
                    using (StreamWriter streamWriter = new StreamWriter(FilePath, false, encoding))
                    {
                        await streamWriter.WriteAsync(GetFileEncodingTextWrite(textBox1.Text));
                        OldText = textBox1.Text;
                        SetSaveFlag(true);
                    }
                    textBox1.ReadOnly = false;
                });
            }
            else 
            {
                SaveFileOther(o, e);
            }
        }
        //另存为
        private  void SaveFileOther(object o, EventArgs e) 
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    textBox1.ReadOnly = true;
                    Task.Run(async () =>
                    {
                        using (StreamWriter streamWriter = new StreamWriter(saveFileDialog1.OpenFile(), encoding))
                        {
                            await streamWriter.WriteAsync(GetFileEncodingTextWrite(textBox1.Text));
                            SetFileInfo(saveFileDialog1.FileName, Path.GetFileNameWithoutExtension(saveFileDialog1.FileName));
                            OldText = textBox1.Text;
                            SetSaveFlag(true);
                        }
                        textBox1.ReadOnly = false;
                    });
                }
            }
        }
        //复制
        private void CopyText(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
                Clipboard.SetText(textBox1.SelectedText);
            textBox1.Focus();
        }

        // 剪切按钮的事件处理程序
        private void CutText(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly) return;
            if (textBox1.SelectedText != "")
            {
                Clipboard.SetText(textBox1.SelectedText);
                textBox1.SelectedText = "";
            }
            textBox1.Focus();
        }

        // 粘贴按钮的事件处理程序
        private void PasteText(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly) return;
            if (Clipboard.ContainsText())
            {
                textBox1.Paste();
            }
            textBox1.Focus();
        }
        //全选
        private void AllSelectText(Object sender, EventArgs e) 
        {
            textBox1.SelectAll();
        }
        //时间
        private void GetTimeText(Object sender, EventArgs e)
        {
            if (textBox1.ReadOnly) return;
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");
            textBox1.SelectedText = formattedDate;
        }

        //查找
        private void FindText(Object sender, EventArgs e) 
        {
            new FindTextForm(textBox1, textBox1.SelectedText).ShowDialog();
        }

        //替换
        private void ReplaceText(Object sender, EventArgs e)
        {
            if (textBox1.ReadOnly) return;
            new ReplaceForm(textBox1, textBox1.SelectedText).ShowDialog();
        }
        //查找上一个
        private void FindUp(Object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(textBox1.SelectedText)) { return; }
            int index = KMPUtil.Search(textBox1.Text.Substring(0, textBox1.SelectionStart), textBox1.SelectedText, true);
            if (index != -1)
            {
                int length = textBox1.SelectionLength;
                textBox1.SelectionStart = index;
                textBox1.SelectionLength = length;
                textBox1.ScrollToCaret();
            }
            else 
            {
                MessageBox.Show("在指定区域内未找到符合的内容");
            }
        }
        //查找下一个
        private void FindDown(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.SelectedText)) { return; }
            int index = KMPUtil.Search(textBox1.Text.Substring(textBox1.SelectionStart+textBox1.SelectionLength), textBox1.SelectedText, false);
            if (index != -1)
            {
                int length = textBox1.SelectionLength;
                textBox1.SelectionStart = index+ textBox1.SelectionStart + textBox1.SelectionLength;
                textBox1.SelectionLength = length;
                textBox1.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("在指定区域内未找到符合的内容");
            }
        }
        //设置字体
        private void FontSet(Object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }
        //放大
        private void FontSizeAddSet(Object sender, EventArgs e)
        {
            if (textBox1.Font.Size >=40) { MessageBox.Show("不能再大了"); return; }
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size + 1);
        }
        //缩小
        private void FontSizeSubSet(Object sender, EventArgs e)
        {
            if (textBox1.Font.Size <= 8) { MessageBox.Show("不能再小了");return; }
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size -1);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                // 保存
                SaveFile(null,null);
                return true;
            }
            if (keyData == (Keys.Control |Keys.Shift| Keys.S))
            {
                // 另存为
                SaveFileOther(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.N))
            {
                // 新建
                NewInit(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.M))
            {
                // 新窗口
                OpenNewForm(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.N))
            {
                // 新窗口打开
                OpenNewFormHasFile(null, null);;
                return true;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                // 打开
                LoadFile(null, null); 
                return true;
            }
            if (keyData == (Keys.Control | Keys.F))
            {
                // 查询
                FindText(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.H))
            {
                // 替换
                ReplaceText(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                // 时间
                GetTimeText(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.U))
            {
                // 查找上一个
                FindUp(null, null);
                return true;
            }
            if (keyData == (Keys.Control |Keys.Shift | Keys.D))
            {
                // 查找下一个
                FindDown(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D1))
            {
                // 加字号
                FontSizeAddSet(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D2))
            {
                // 减字号
                FontSizeSubSet(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D0))
            {
                // 默认字号
                textBox1.Font = new Font("Microsoft YaHei UI", 9f);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.F))
            {
                // 换字体
                FontSet(null, null);
                return true;
            }
            if(keyData == (Keys.Alt | Keys.R))
            {
                // 换行
                this.autoMulToolStripMenuItem.Checked = !this.autoMulToolStripMenuItem.Checked;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public  string GetFileEncodingText(string text)
        {
            //byte[]old = encoding.GetBytes(text);
            //byte[] newtext = Encoding.Convert(encoding, Encoding.Default, old);
            //return Encoding.Default.GetString(newtext);
            return text;
        }

        public string GetFileEncodingTextWrite(string text)
        {
            //byte[] old = Encoding.Default.GetBytes(text);
            //byte[] newtext = Encoding.Convert(Encoding.Default, encoding, old);
            //return encoding.GetString(newtext);
            return text;
        }
    }
}
