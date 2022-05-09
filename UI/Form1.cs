using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{
    public partial class Form1 : Form
    {
        Core.CreateFiles createFiles;
        public Form1()
        {
            InitializeComponent();
            createFiles = new Core.CreateFiles();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createFiles.Run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createFiles.Run5Threads();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //createFiles.Handler_FileCreated += createFiles.DeleteOneFile;
            createFiles.CreateNDelete10Files();
        }
    }
}
