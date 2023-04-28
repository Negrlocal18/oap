using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PRAKTICHESKOE_ZADANIE_21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbsort1.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void файдToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                rtb1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();

        }

        private void сохранитьCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < lb2.Items.Count; i++)
                {
                    Writer.WriteLine((string)lb2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();

        }

        private void выходAltXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель Никита Коновальцев. 11.04.2023");

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lbsort1.Items.Clear();
            lb2.Items.Clear();
            lbsort1.BeginUpdate();
            string[] Strings = rtb1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (rb1.Checked) lbsort1.Items.Add(Str);
                if (rb2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) lbsort1.Items.Add(Str);
                }
                if (rb3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) lbsort1.Items.Add(Str);
                }
            }
            lbsort1.EndUpdate();

        }

        private void btnPoisk_Click(object sender, EventArgs e)
        {
            lbPoisk.Items.Clear();
            string Find = textBox1.Text;
            if (cbRazdel1.Checked)
            {
                foreach (string String in lbsort1.Items)
                {
                    if (String.Contains(Find)) lbPoisk.Items.Add(String);
                }
            }

            if (cbRazdel1.Checked)
            {
                foreach (string String in lbsort1.Items)
                {
                    if (String.Contains(Find)) lbPoisk.Items.Add(String);
                }
            }
            if (cbRazdel2.Checked)
            {
                foreach (string String in lb2.Items)
                {
                    if (String.Contains(Find)) lbPoisk.Items.Add(String);
                }
            }

        }

        private void btnclear1_Click(object sender, EventArgs e)
        {
            lb2.Items.Clear();
        }

        private void btnleft_Click(object sender, EventArgs e)
        {

            for (int i = lbsort1.Items.Count - 1; i >= 0; i--)
            {
                if (lbsort1.GetSelected(i))
                {
                    lb2.Items.Add(lbsort1.Text);
                    lbsort1.Items.RemoveAt(i);
                }
            }
        }

        private void btnSbros_Click(object sender, EventArgs e)
        {
            lbsort1.Items.Clear();
            lb2.Items.Clear();
            lbPoisk.Items.Clear();
            rtb1.Clear();
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            cbRazdel1.Checked = false;
            cbRazdel2.Checked = false;

        }

        private void btndobav_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            for (int i = lbsort1.Items.Count - 1; i >= 0; i--)
            {
                if (lbsort1.GetSelected(i)) lbsort1.Items.RemoveAt(i);
                for (int b = lb2.Items.Count - 1; b >= 0; b--)
                {
                    if (lb2.GetSelected(b)) lb2.Items.RemoveAt(b);
                }
            }

        }

        private void btnright_Click(object sender, EventArgs e)
        {
            for (int i = lb2.Items.Count - 1; i >= 0; i--)
            {
                if (lb2.GetSelected(i))
                {
                    lbsort1.Items.Add(lb2.Text);
                    lb2.Items.RemoveAt(i);
                }
            }

        }

        private void btn2left_Click(object sender, EventArgs e)
        {
            lb2.Items.AddRange(lbsort1.Items);
            lbsort1.Items.Clear();
        }

        private void btn2right_Click(object sender, EventArgs e)
        {
            lbsort1.Items.AddRange(lb2.Items);
            lb2.Items.Clear();
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            string[] array = new string[lbsort1.Items.Count];
            switch (cb1.SelectedItem.ToString())
            {
                case "Алфавиту (по возрастанию) ":
                    lbsort1.Items.CopyTo(array, 0);
                    Array.Sort(array);
                    lbsort1.Items.Clear();
                    lbsort1.Items.AddRange(array);
                    break;
                case "Алфавиту (по убыванию) ":
                    lbsort1.Items.CopyTo(array, 0);
                    Array.Sort(array);
                    Array.Reverse(array);
                    lbsort1.Items.Clear();
                    lbsort1.Items.AddRange(array);
                    break;
                case "Длине слова (по возрастанию)":
                    lbsort1.Items.CopyTo(array, 0);
                    string s;
                    for (int i = 1; i < array.Length - 1; i++)
                        for (int j = i; j >= 0; j--)
                            if (array[j].Length > array[j + 1].Length)
                            {
                                s = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = s;

                            }
                    lbsort1.Items.Clear();
                    lbsort1.Items.AddRange(array);
                    break;
                case "Длине слова (по убыванию) ":
                    lbsort1.Items.CopyTo(array, 0);
                    for (int i = 1; i < array.Length - 1; i++)
                        for (int j = i; j >= 0; j--)
                            if (array[j].Length > array[j + 1].Length)
                            {
                                s = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = s;
                            }
                    Array.Reverse(array);
                    lbsort1.Items.Clear();
                    lbsort1.Items.AddRange(array);
                    break;


            }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsort1_Click(object sender, EventArgs e)
        {
            string[] array = new string[lb2.Items.Count];
            switch (cb2.SelectedItem.ToString())
            {
                case "Алфавиту (по возрастанию)":
                    lb2.Items.CopyTo(array, 0);
                    Array.Sort(array);
                    lb2.Items.Clear();
                    lb2.Items.AddRange(array);
                    break;
                case "Алфавиту (по убыванию)":
                    lb2.Items.CopyTo(array, 0);
                    Array.Sort(array);
                    Array.Reverse(array);
                    lb2.Items.Clear();
                    lb2.Items.AddRange(array);
                    break;
                case "Длине слова (по возрастанию)":
                    lb2.Items.CopyTo(array, 0);
                    string s;
                    for (int i = 1; i < array.Length - 1; i++)
                        for (int j = i; j >= 0; j--)
                            if (array[j].Length > array[j + 1].Length)
                            {
                                s = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = s;

                            }
                    lb2.Items.Clear();
                    lb2.Items.AddRange(array);
                    break;
                case "Длине слова (по убыванию)":
                    lb2.Items.CopyTo(array, 0);
                    for (int i = 1; i < array.Length - 1; i++)
                        for (int j = i; j >= 0; j--)
                            if (array[j].Length > array[j + 1].Length)
                            {
                                s = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = s;
                            }
                    Array.Reverse(array);
                    lb2.Items.Clear();
                    lb2.Items.AddRange(array);
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

