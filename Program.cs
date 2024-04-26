using MyTextEditor.TextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextEditor
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args != null && args.Count() == 2)
            {
                string filePath = args[0];
                string fileName = args[1];
                Console.WriteLine("File Path: " + filePath);
                Console.WriteLine("File Name: " + fileName);
                Application.Run(new EditorForm(filePath,fileName));
            }
            else 
            {
                Application.Run(new EditorForm());
            }
            
        }
    }
}
