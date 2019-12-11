using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_PR6_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "")
                {
                    textBox1.Focus();
                    throw new Exception("Вы не ввели ФИО");
                }
                if (textBox2.Text.Trim() == "")
                {
                    textBox2.Focus();
                      throw new Exception("Вы не ввели улицу");
                }
            
                int k = Convert.ToInt32(textBox3.Text);
                if (k < 1 || k > 999999)
                {
                    textBox3.Focus();
                    throw new Exception("номер паспорта" +
                        "от 1 до 999999");
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                textBox3.Focus();
                MessageBox.Show("Номер дома " +
                    "-целое число!!");
            }
            catch (Exception E)
            {//запрещаем закрытие формы
                e.Cancel = true; 
                MessageBox.Show(E.Message);
            }

        
        }
    }
}
