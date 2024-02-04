using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telecome
{
    public partial class Sms : Form
    {
        public Sms(string sms)
        {
            InitializeComponent();
            textBox1.Text = sms;
        }

        private void Sms_Load(object sender, EventArgs e)
        {

        }
    }
}
