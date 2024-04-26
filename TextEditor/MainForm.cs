using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor.TextEditor
{
    public partial class MainForm : Form
    {
        public List<Form>forms = new List<Form>();
        public MainForm()
        {
            InitializeComponent();
            addForm(new EditorForm(this));
            Load += (obj, e) => {
                this.BeginInvoke((MethodInvoker)delegate () {
                    this.Hide();
                });
            };
        }

        public void addForm(EditorForm edform) 
        {
            if (edform != null) 
            {
                edform.FormClosed += (obj, e) =>
                {
                    forms.Remove(edform);
                    if (forms.Count <= 0)
                    {
                        this.Close();
                    }
                };
                forms.Add(edform);
                edform.Show();
            }
        } 
    }
}
