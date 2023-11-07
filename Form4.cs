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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{

    public partial class Form4 : Form
    {
        

        public Form4(string S)

        {
            InitializeComponent();
             
        }
       

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream MainStream;
            using (SaveFileDialog dirReport = new SaveFileDialog())
            {
                dirReport.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //фильтр для создания файлов с расширением txt

                if (dirReport.ShowDialog() == DialogResult.OK) 
                {
                    if ((MainStream = dirReport.OpenFile()) != null) //весь блок - написание отчета в текстовом документе
                    {
                        string txtReport = "\tОтчет: \n";

                        if (checkBox1.Checked) txtReport = txtReport + "Работу выполнил Ленцов Павел Александрович";
                        if (checkBox2.Checked) txtReport = txtReport + "\n Дата составления отчета - \"" + Convert.ToString(DateTime.Now);                                               
                        if (checkBox3.Checked) txtReport = txtReport + "\n Отделите точку экстремума функции f(x)=lg(pi/4 + x^2), т.е. найдите отрезок [a, b], на котором лежит точка экстремума. Оптимизируйте функцию методом дихотомии с точностью до 0,001."; //записывает в отчет дату
                        if (checkBox5.Checked) txtReport = txtReport + "\n Среда разработки: Microsoft Visual Studio 2022";

                        byte[] file_text = System.Text.Encoding.Default.GetBytes(txtReport);//заносим нашу строку в массив байтов
                        MainStream.Write(file_text, 0, file_text.Length);//записываем наш массив в файл
                        MainStream.Close();//закрываем поток обмена данных
                    }


                }
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    

            

      
