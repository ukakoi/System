using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nasledovanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            if (radioButton1.Checked)
            {
                
                Tangens o = new Tangens(x);
                listBox1.Items.Add(o);
            }
            else if (radioButton2.Checked)
            {
                double n = Convert.ToDouble(textBox2.Text);

                Stepen r = new Stepen(n,x);
                listBox1.Items.Add(r);
            }
            else
              {   
           double n = Convert.ToDouble(textBox2.Text);
                double o = Convert.ToDouble(textBox3.Text);
                Minimum mimi = new Minimum( n,o, x);
                listBox1.Items.Add(mimi);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            textBox3.Visible = false;
            label3.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            textBox1.Visible = true;
            label1.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            textBox3.Visible = true;
            label3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (listBox1.SelectedItem is Tangens)
                {
                    Tangens o = listBox1.SelectedItem as Tangens;
                    label5.Text =  o.Calc().ToString();
                }
                else if (listBox1.SelectedItem is Stepen)
                {
                    Stepen o = listBox1.SelectedItem as Stepen;
                    label5.Text = o.Calc().ToString();
                }
                else
                {
                    Minimum o = listBox1.SelectedItem as Minimum;
                    label5.Text = o.Calc().ToString();
                }
            }
        }
    }
}
