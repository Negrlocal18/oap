using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PRAKTICHESKOE_ZADANIE_21
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btndobav2_Click(object sender, EventArgs e)
        {
            Form1 Main = this.Owner as Form1;
            if (tbform2.Text != "")
            {
                if (this.rbRazdel1Form2.Checked == true)
                    Main.lbsort1.Items.Add(this.tbform2.Text);
                else Main.lb2.Items.Add(this.tbform2.Text);
                this.Close();
            }

        }

        private void btnotmena2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
