using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gostica
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private Button currentButton;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnDashdoard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form3(), sender);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisaleButton();
                    
                    currentButton = (Button)btnSender;
                    
                    
                    currentButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    
                    
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisaleButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    
                    previousBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesltopPane.Controls.Add(childForm);
            this.panelDesltopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1(), sender);
        }

        private void btnKlient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form4(), sender);
        }

        private void btnNomera_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form5(), sender);
        }

        private void btnPocel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form6(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form7(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form8(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form9(), sender);
        }
    }
}
