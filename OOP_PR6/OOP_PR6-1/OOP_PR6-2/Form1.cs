using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP_PR6_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Update_button(false);
            Dell_button(false);
            Save_button(false);
        }
        void Update_button(bool value)
        {
            button3.Enabled = value;
 
        }
        void Dell_button(bool value)
        {
            button2.Enabled = value;
             
        }
        void Save_button(bool value)
        {
            button4.Enabled = value;
 
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            //f.Text = "Добавление человека";
            //f.textBox1.Text = "";
            //f.textBox2.Text = "";
            //f.textBox3.Text = "";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string fio = f.textBox1.Text;
                string ulica = f.textBox2.Text;
                int hnum = Convert.ToInt32(f.textBox3.Text);
                int knum = Convert.ToInt32(f.textBox4.Text);

                TOpa p = new TOpa(fio,ulica, hnum, knum);
                listBox1.Items.Add(p);
            }

            if (listBox1.Items.Count > 0)
            {
                Update_button(true);
                Dell_button(true);
                Save_button(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            if (listBox1.Items.Count == 0)
            {
                Update_button(false);
                Dell_button(false);
                Save_button(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //берем выделенный обьект из листбокса
                TOpa peop = listBox1.Items
                    [listBox1.SelectedIndex] as TOpa;
                Form2 f = new Form2();
                f.Text = "Изменение данных о человеке";
                f.textBox1.Text = peop.FIO;
                f.textBox2.Text = peop.ULI;
                f.textBox3.Text = peop.NumH.ToString();
                f.textBox4.Text = peop.NumK.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    peop.FIO = f.textBox1.Text;
                    peop.NumH = Convert.ToInt32(f.textBox3.Text);
                    peop.NumK = Convert.ToInt32( f.textBox4.Text);
                    listBox1.Items[listBox1.SelectedIndex] = peop;

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                string file_name = saveFileDialog1.FileName;

                using (StreamWriter sw = new StreamWriter(
                    File.Open(file_name, FileMode.Create)))
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        TOpa p = listBox1.Items[i] as TOpa;
                        sw.WriteLine(p.FIO);
                        sw.WriteLine(p.ULI);
                        sw.WriteLine(p.NumH);
                        sw.WriteLine(p.NumK);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file_name = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(
                    File.Open(file_name, FileMode.Open)))
                {
                    while (!sr.EndOfStream)
                    {
                        string fio = sr.ReadLine();
                        string ulica = sr.ReadLine();
                        int hnum = Convert.ToInt32(sr.ReadLine());
                        int knum = Convert.ToInt32(sr.ReadLine());
                        TOpa p = new TOpa(fio, ulica, hnum, knum);
                        listBox1.Items.Add(p);
                    }
                }
            }
            if (listBox1.Items.Count > 0)
            {
                Update_button(true);
                Dell_button(true);
                Save_button(true);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                TOpa p = listBox1.Items[listBox1.SelectedIndex]
                    as TOpa;
                toolStripStatusLabel1.Text = p.FIO;
                toolStripStatusLabel2.Text = p.ULI;
                toolStripStatusLabel3.Text = p.NumH.ToString();
                toolStripStatusLabel4.Text = p.NumK.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TOpa[] mas = new TOpa[listBox1.Items.Count];
           
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                mas[i] = listBox1.Items[i] as TOpa;
            }
            for (int i = 0; i < listBox1.Items.Count - 1; i++)
            {
                for (int j = 0; j < listBox1.Items.Count - i - 1; j++)
                {
                    if (mas[j].FIO.Length > mas[j + 1].FIO.Length)
                    {
                        TOpa p = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = p;
                    }
                }
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox2.Items.Add(mas[i]);
            }
            //Сортируем массив
            //как???
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
 listBox2.Items.Clear();
        }
    }
}
