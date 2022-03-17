using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace krsch_trpo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if ((richTextBox1.Text != "") & (richTextBox2.Text != "") & (comboBox1.Text != "") & (comboBox2.Text != ""))
                
                { try
                    {

                        obmen client = new obmen(richTextBox1.Text, Convert.ToDouble(richTextBox2.Text), comboBox1.Text, comboBox2.Text);
                        dataGridView1.Rows.Add(client.FIO, Math.Round(client.vneseno, 2), client.vnValuta, Math.Round(client.polycheno, 2), client.polValuta, client.time);
                        InputStack.Push(client);
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = ""; 
                    } catch (Exception a) { MessageBox.Show("Где требуется, вводите числа, а не буквы"); }
                   
                }
                else MessageBox.Show("Проверьте заполненность всех полей");
        }
        Stack<obmen> InputStack = new Stack<obmen>();

        private void сериализацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
            if (save.ShowDialog() != DialogResult.OK) { return; }
            FileStream stream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, InputStack);
            stream.Close();
        }

        private void десереализацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Stack<obmen> st = new Stack<obmen>();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
            if (open.ShowDialog() != DialogResult.OK) { return; }
            FileStream stream = new FileStream(open.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            st = (Stack<obmen>)bf.Deserialize(stream);
            stream.Close();
            foreach (obmen client in st)
            {
                InputStack.Push(client);
                dataGridView1.Rows.Add(client.FIO, Math.Round(client.vneseno, 2), client.vnValuta, Math.Round(client.polycheno, 2), client.polValuta, client.time);
            }
        }

        private void изменитьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 cf = new Form2();
            cf.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    [Serializable]
    public class obmen
    {
        public string FIO { get; set; }
        public double vneseno { get; set; }
        public string vnValuta { get; set; }
        public string polValuta { get; set; }
        public double polycheno { get; set; }
        public double bankye { get; set; }
        public DateTime time { get; set; }
        public obmen(string fio, double vnes, string vnvaluta, string polvaluta  )
        {
            FIO = fio;
            vneseno = vnes;
            vnValuta = vnvaluta;
            polValuta = polvaluta;
            time = DateTime.Now;
            switch (vnvaluta)
            {
                case "Рубли": bankye = vnes * cours.rubles; break;
                case "Доллары": bankye = vnes * cours.dollars; break;
                case "Дублоны": bankye = vnes * cours.doublon; break;
                case "Песо": bankye = vnes * cours.peso; break;
                case "Гривны": bankye = vnes * cours.grivna; break;
                case "Евро": bankye = vnes * cours.euro; break;
                case "Юань": bankye = vnes * cours.uan; break;
                default: MessageBox.Show("Банк не оперирует этой валютой"); break;
            }
            switch (polvaluta)
            {
                case "Рубли" : polycheno = bankye / cours.rubles;break;
                case "Доллары": polycheno = bankye / cours.dollars; break;
                case "Дублоны": polycheno = bankye / cours.doublon; break;
                case "Песо": polycheno = bankye / cours.peso; break;
                case "Гривны": polycheno = bankye / cours.grivna; break;
                case "Евро": polycheno = bankye / cours.euro; break;
                case "Юань": polycheno = bankye / cours.uan; break;
                default: MessageBox.Show("Банк не оперирует этой валютой"); break;
            }
            

        }
    }
    public class cours
    {
        static public double rubles = 20;
        static public double dollars = 1426;
        static public double euro = 1598;
        static public double peso = 78;
        static public double doublon = 653464;
        static public double grivna = 54;
        static public double uan = 245;

    }

}
