using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miracle
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public string Message
        {
            get
            {
                return this.label1.Text;
            }
            set{ 
                this.label1.Text = value;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
        }
    }
}

