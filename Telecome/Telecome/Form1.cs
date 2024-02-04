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
    public partial class Form1 : Form
    {

        string pcode = "";
        string code = "";
        bool canEnter = false;
        int time = 1;
        TelecomeDBEntities db = new TelecomeDBEntities();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != "" && textBox2.Text != "")
            { 

            }
        }
        static string GenerateRandomCode()
        {
            const string charsetMini = "abcdefghijklmnopqrstuvwxyz";
            const string charsetBig = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string charsetNumbers = "0123456789";
            const string charsetSimbols = "!@#$%^&*()_+";

            Random random = new Random();
            char[] codeArray = new char[8];

            codeArray[0] = charsetMini[random.Next(0, charsetMini.Length)];
            codeArray[1] = charsetMini[random.Next(0, charsetMini.Length)];
            codeArray[2] = charsetMini[random.Next(0, charsetMini.Length)];
            codeArray[3] = charsetBig[random.Next(0, charsetBig.Length)];
            codeArray[4] = charsetBig[random.Next(0, charsetBig.Length)];
            codeArray[5] = charsetBig[random.Next(0, charsetBig.Length)];
            codeArray[6] = charsetSimbols[random.Next(0, charsetSimbols.Length)];
            codeArray[7] = charsetNumbers[random.Next(0, charsetNumbers.Length)];

            for (int i = codeArray.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                char temp = codeArray[i];
                codeArray[i] = codeArray[j];
                codeArray[j] = temp;
            }

            return new string(codeArray);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            var users = db.User.ToList();
            if (e.KeyCode == Keys.Enter && textBox1.Text != "" && textBox2.Text != "")
            {
                bool PassFind = false;
                for (int i = 0; i < users.Count; i++)
                {
                    if (textBox1.Text == users[i].Code.ToString() && textBox2.Text == users[i].Password.ToString())
                    {
                        PassFind = true;
                        code = GenerateRandomCode();
                        Sms sms = new Sms(code);
                        sms.FormClosed += Sms_FormClosed;
                        sms.ShowDialog();
                    }
                }
                if (PassFind)
                    textBox3.Enabled = true;
                else
                {
                    textBox3.Enabled = false;
                    MessageBox.Show("Не верный пароль");
                }
            }
        }
        private void Sms_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Start();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var users = db.User.ToList();
            if (e.KeyCode == Keys.Enter&&textBox1.Text!="")
            {
                if (textBox1.Text != "")
                {
                    bool CodeFind = false;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (textBox1.Text == users[i].Code.ToString())
                            CodeFind = true;
                    }
                    if (CodeFind)
                        textBox2.Enabled = true;
                    else
                    {
                        textBox2.Enabled = false;
                        MessageBox.Show("Такого номера нет");
                    }    
                       
                }
                else textBox2.Enabled = false;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled=false;
            code = GenerateRandomCode();
            Sms sms = new Sms(code);
            sms.ShowDialog();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string role = "";
            canEnter = false;
            var users = db.User.ToList();
            if (textBox1.Text != "" && textBox2.Text != ""&&textBox3.Text.Length!=0)
            {
                pcode = textBox3.Text;
                for (int i = 0; i < users.Count; i++)
                {
                    if (textBox1.Text == users[i].Code.ToString() && textBox2.Text == users[i].Password.ToString()&&code==pcode)
                    {
                        canEnter= true;
                        int id = (int)users[i].Id_role;
                        var roles=db.Role.ToList();
                        for (int j = 0; j < roles.Count; j++) {
                            if (roles[i].Id==id)
                            {
                                role = roles[i].Name;
                            }
                        }
                    }
                }
                if (canEnter)
                {
                    MessageBox.Show($"Вы вошли под ролью: {role}");
                }
                else
                {
                    MessageBox.Show("Не верный код подтверждения");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;
        }
    }
}
