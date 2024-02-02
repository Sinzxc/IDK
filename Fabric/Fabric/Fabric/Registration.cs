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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fabric.factoryEntities db = new Fabric.factoryEntities();
            string username = textBox1.Text.ToString();
            string pass = textBox2.Text.ToString();
            string name = textBox3.Text.ToString();

            var users = db.User.ToList();

            bool canAdd = true;
            for (int i = 0; i < db.User.ToList().Count; i++)
            {
                if (users[i].Username == name && users[i].Password == pass)
                {
                    canAdd = false;
                }
                if (canAdd != false)
                   canAdd=IsPasswordValid(pass);
            }

            if (canAdd)
            {
                User user = new User();
                user.Username = username;
                user.Password = pass;
                user.Name = name;
                user.Id_Role = 3;
                db.User.Add(user);
                db.SaveChanges();
                MessageBox.Show("Зарегистрировано", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Не верные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static bool IsPasswordValid(string password)
        {
            // Проверка длины пароля
            if (password.Length < 6)
                return false;

            // Проверка наличия прописной буквы
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Проверка наличия цифры
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // Проверка наличия одного из символов: ! @ # $ % ^
            if (!Regex.IsMatch(password, "[!@#$%^]"))
                return false;

            // Если все проверки пройдены, возвращаем true
            return true;
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
