using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string path = (AppDomain.CurrentDomain.BaseDirectory + "/money.txt");

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "0");
            }
            textBox1.Text = File.ReadAllText(path);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text = "Money to Add: ";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label2.Text = "Money to Substract: ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float oldArgent = float.Parse(textBox1.Text);
            float newArgent = float.Parse(textBox2.Text);
            float totalArgent = 0;

            if (comboBox1.SelectedIndex == 0)
            {
                totalArgent = oldArgent + newArgent;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                totalArgent = oldArgent - newArgent;
            }

            textBox1.Text = totalArgent.ToString();
            File.WriteAllText(path, textBox1.Text);
        }
    }
}
