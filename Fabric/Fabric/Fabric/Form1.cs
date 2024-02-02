using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabric
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fabric.factoryEntities db = new Fabric.factoryEntities();

            string name=textBox1.Text.ToString();
            string pass=textBox2.Text.ToString();

            var users=db.User.ToList();
            
            bool canEnter=false;
            string role = "";
            for (int i = 0; i < db.User.ToList().Count; i++)
            {
                if (users[i].Username == name && users[i].Password == pass)
                {
                    canEnter = true;
                    role = users[i].Role.Name.ToString();
                }
                    
            }
            if (canEnter)
            {
                MessageBox.Show("Вошли", "Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
                switch (role) {
                    case "Администратор": 
                        Admin admin = new Admin();
                        admin.Show();
                        break;
                    case "Менеджер":
                        Manager manager = new Manager();
                        manager.Show();
                        break;
                    case "Клиент":
                        Customer customer = new Customer(); 
                        customer.Show();
                        break;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Не верные данные", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration(); 
            registration.Show();
            this.Hide();
        }
    }
}
