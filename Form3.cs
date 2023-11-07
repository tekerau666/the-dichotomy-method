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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        
        
        string S;


        public Form3()
        {

            InitializeComponent();
            comboBox1.DataSource = formules;
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public double f1(double x)//функция по задаче
        {
            return (8 * x) / Math.Log(10) * (Math.PI + 4 * x * x);
        }

        public double f2(double x)//функция 2я
        {
            return 2;
        }
        public double f3(double x)//функция 3я
        {
            return 2*x+1;
        }

        string[] formules = { "f(x) = f(x)=lg(pi/4 + x^2)", "f(x) = 2x+5", "f(x) = x^2+x-4" }; //как выглядят формулы в комбобоксе
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a;
                double b;
                double step;
                int n = 1;
                a = Convert.ToDouble(textBoxA.Text);

                b = Convert.ToDouble(textBoxB.Text);

                step = Convert.ToDouble(textBoxStep.Text);

                int idFormula = comboBox1.SelectedIndex;
                for (double i = a; i < b; i += step)
                {
                    if (Math.Abs(i) < Math.Abs(step - step / 10))
                    {
                        i = 0;
                    }
                    switch (idFormula)
                    {
                        case 0: //кейсы - это выбор формулы для исследования из combo-box
                            dataGridView1.Rows.Add(i, Math.Log(Math.PI / 4 + i * i, 10));
                            break;
                        case 1:
                            dataGridView1.Rows.Add(i, 2*i+5);
                            break;
                        case 2:
                            dataGridView1.Rows.Add(i, Math.Pow(i,2)+i-4);
                            break;
                    }


                    n++;
                }
                label15.Visible= false;

            }
            catch
            {
                label15.Visible = true;return;
            }


        }



        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void График_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) //находит корень уравнения
        {
            try
            {

                int idFormula = comboBox1.SelectedIndex;
                switch (idFormula)
                {

                    case 0:

                        double a = Convert.ToDouble(textBox1.Text);  // Начальное значение левой границы интервала
                        double b = Convert.ToDouble(textBox2.Text);   // Начальное значение правой границы интервала
                        double E = Convert.ToDouble(textBox3.Text); // Заданная точность
                        string result;
                        double x0, x1, x2;
                        x0 = a;
                        x1 = b;
                        x2 = b;
                        textBox4.Text = Convert.ToString((x1 - x0) / 2);
                        while ((x1 - x0) / 2 > E) //сам метод дихотомии (описан в word)
                        {
                               
                            x2 = (x0 + x1) / 2;
                            if (f1(x2) == 0)
                            {
                                result = String.Format("{0:F3}", x2); //форматируем строку ответа, чтобы было 3 цифры после запятой
                                label13.Text = result;
                                label14.Visible = false; //после правильного ввода данных,закрывает текст с предупреждением
                                break; //закрываем case 
                            }
                            if (f1(x0) * f1(x2) < 0)
                            {

                                x1 = x2;
                            }
                            else
                            {
                                x0 = x2;
                            }

                        }
                        result = String.Format("{0:F3}", x2); //форматируем строку ответа, чтобы было 3 цифры после запятой
                        label13.Text = result;
                        label14.Visible = false; //после правильного ввода данных,закрывает текст с предупреждением
                        break; //закрываем case
                   
                }

            }
            catch { label14.Visible = true; return; } //в случае ошибки из-за неверного ввода - предупреждает о нем!


        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Ввод шага
        {
           
        }
        
        

       
       
        private void button2_Click(object sender, EventArgs e) // Построение графика
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value); //выбор точки из таблимцы
                double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                Chart.Series[0].Color = Color.Green;
                Chart.Series[0].Points.AddXY(x, y); //заносим точку в график
            }




        }

        private void button3_Click(object sender, EventArgs e) // Очищает график и таблицу
        {
            dataGridView1.Rows.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Chart.Series[0].Points.Clear();
            }

        }

        private void button4_Click(object sender, EventArgs e) // Открывает форму для отчёта
        {
            Form form3 = new Form4(S);
    
                form3.ShowDialog();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
