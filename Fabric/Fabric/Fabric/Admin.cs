using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fabric
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Fabric.factoryEntities db = new Fabric.factoryEntities();
            var rolls = db.Roll.ToList();
            for (int i = 0; i < rolls.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new[] { rolls[i].Id.ToString(), rolls[i].Id_material.ToString(), rolls[i].Id_color.ToString(), rolls[i].Width.ToString(), rolls[i].Height.ToString() }));
            }
           

        }
        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
