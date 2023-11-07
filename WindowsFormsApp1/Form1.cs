using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                try
                {

                    string a = @"E:\\o.txt";
                    int b = int.Parse(textBox2.Text);
                    string c = @"E:\\u.txt";
                string d = textBox3.Text;

               
                    string D = Regex.Replace(d, @"\w", "");
                string A = Regex.Replace(a, @"\w", "");
                string C = Regex.Replace(c, @"\w", "");
                A = textBox1.Text;
               
                {
                        using (StreamReader sr = new StreamReader(@"E:\\o.txt", System.Text.Encoding.Default))
                        {

                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Length > b)
                                {
                                    using (StreamWriter sw = new StreamWriter(@"E:\\u.txt",true , System.Text.Encoding.Default))
                                    {
                                        sw.WriteLine(line);


                                    }

                                }
                            }
                        }
                    }
                    using (StreamReader sr = new StreamReader(@"E:\\u.txt", System.Text.Encoding.Default))
                    {
                    textBox3.Text = sr.ReadToEnd();
                    }
                    string[] text = textBox1.Text.Split(' ');

                    using (StreamWriter sw = new StreamWriter(@"E:\\o.txt", false, System.Text.Encoding.Default))
                    {
                        for (int i = 0; i < text.Length; i++)
                            sw.WriteLine(text[i]);
                    }
                }

                catch (FormatException)
                {
                    textBox1.Multiline = true;
                    MessageBox.Show("Неверный формат");

                }
            }
        }
    }
