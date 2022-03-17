using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace krsch_trpo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cours.rubles = 1;
            cours.dollars = Convert.ToDouble(richTextBox1.Text);
            cours.euro = Convert.ToDouble(richTextBox3.Text);
            cours.peso = Convert.ToDouble(richTextBox4.Text);
            cours.doublon = Convert.ToDouble(richTextBox2.Text);
            cours.grivna = Convert.ToDouble(richTextBox6.Text);
            cours.uan = Convert.ToDouble(richTextBox5.Text);
            
        }
    }
}
