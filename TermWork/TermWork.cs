using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TermWork
{
    public partial class Form1 : Form
    {
        List<CalcData> calcdata = new List<CalcData>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m = Convert.ToDouble(textBox1.Text);
            if (m < 2 || m > 10)
            {
                MessageBox.Show("Модуль ремня введён некорректно: " + m.ToString());
                return;
            }
            double z1 = Convert.ToDouble(textBox2.Text);
            if (z1 < 12 || z1 > 28)
            {
                MessageBox.Show("Число зубьев меньшего шкифа введено некорректно: " + z1.ToString());
                return;
            }
            double z2 = Convert.ToDouble(textBox9.Text);
            if (z2 < 12 || z2 > 28)
            {
                MessageBox.Show("Число зубьев большего шкифа введено некорректно: " + z2.ToString());
                return;
            }

            double u = z2 / z1;
            textBox3.Text = u.ToString("0.000");     //расчёт предаточного числа

            double amin = 0.5 * m * (z1 + z2) + 2 * m; //расстояние между осями
            textBox5.Text = amin.ToString(); /*+ " мм";*/
            double amax = 2 * m * (z1 + z2);
            textBox6.Text = amax.ToString(); /*+ " мм";*/
            double a = (amin + amax) / 2;
            textBox7.Text = a.ToString(); /*+ " мм";*/

            double tp = 3.1415 * m;     //расчёт шага ремня
            textBox8.Text = tp.ToString("0.000"); /*+ " мм";*/

            double zp = (2 * a) / tp + (z1 + z2) / 2 + ((z2 - z1) * (z2 - z1) * tp) / (40 * a);       //расчёт числа зубьев
            textBox4.Text = zp.ToString("0");

            double Lp = Convert.ToDouble(textBox10.Text);       //выбор длины ремня
            if (Lp < 201 || Lp > 3140)
            {
                MessageBox.Show("Длина ремня введёна некорректно: " + m.ToString());
                return;
            }

            double lambda = Lp - tp * (z1 + z2) / 2;
            textBox11.Text = lambda.ToString();
            double delta = m * (z2 - z1) / 2;
            textBox12.Text = delta.ToString();
            double truea = (lambda + Math.Sqrt(lambda * lambda - 8 * delta * delta)) / 4;
            textBox13.Text = truea.ToString("0.000"); /*+ " мм";*/

            double lb = 0;        //расстояние от впадины зуба до ремня
            if (radioButton1.Checked)
                if (m <= 4) lb = 0.6;
            else if (radioButton2.Checked)
                if (m >= 4) lb = 1.3;
            textBox16.Text = lb.ToString(); /*+ " мм";*/

            double i = 0;       //коэффицент продольной податливости каркаса ремня
            if (radioButton1.Checked)
            {
                if (m == 2) i = 0.0018;
                else if (m == 3) i = 0.0025;
                else if (m == 4) i = 0.003;
            }
            else
            {
                if (m == 4) i = 0.0011;
                else if (m == 5) i = 0.0013;
                else if (m == 7) i = 0.0019;
                else if (m == 10) i = 0.0025;
            }
            textBox17.Text = i.ToString(); /*+ " мм\u00B2/Н";*/

            double T1 = Convert.ToDouble(textBox18.Text);
            if (T1 < 0)
            {
                MessageBox.Show("Наибольший крутящий момент введён некорректно: " + T1.ToString());
                return;
            }
            double N = Convert.ToDouble(textBox19.Text);
            if (N < 500 || N > 7500) 
            {
                MessageBox.Show("Передаваемая мощность введёна некорректно: " + N.ToString());
                return;
            }
            double n1 = Convert.ToDouble(textBox22.Text);       //ввести таблицу
            double F = 0;
            if (T1 > 0)
                F = (2 * 1000 * T1) / (m * z1);
            else
                F = (1.91 * 10000000 * N) / (z1 * n1 * m);
            textBox20.Text = F.ToString("0"); /*+ " Н";*/

            double[] blist = new double[] { 8, 10, 12.5, 16, 20, 25, 32, 40, 50, 63, 80 };
            double b = 6 * m;
            for (int j = 0; j < 11; j++)
                if (b < blist[j])
                {
                    textBox21.Text = blist[j].ToString(); /*+ " мм";*/
                    break;
                }

            double C1 = (0.15 * F * i * z1) / b;
            textBox23.Text = C1.ToString("0"); /*+ " мм";*/
            double C2 = (0.15 * F * i * z2) / b;
            textBox24.Text = C2.ToString("0"); /*+ " мм";*/
            double da1 = m * z1 - 2 * lb + C1;
            textBox14.Text = da1.ToString("0"); /*+ " мм";*/
            double da2 = m * z2 - 2 * lb + C2;
            textBox15.Text = da2.ToString("0"); /*+ " мм";*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.InsertPerson(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox9.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox10.Text), Convert.ToDouble(textBox11.Text), Convert.ToDouble(textBox12.Text), Convert.ToDouble(textBox13.Text), Convert.ToDouble(textBox16.Text), Convert.ToDouble(textBox17.Text), Convert.ToDouble(textBox18.Text), Convert.ToDouble(textBox19.Text), Convert.ToDouble(textBox22.Text), Convert.ToDouble(textBox20.Text), Convert.ToDouble(textBox21.Text), Convert.ToDouble(textBox23.Text), Convert.ToDouble(textBox24.Text), Convert.ToDouble(textBox14.Text), Convert.ToDouble(textBox15.Text));

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
