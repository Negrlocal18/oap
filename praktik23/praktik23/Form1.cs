using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktik23
{
    public partial class Form1 : Form
    {
        bool drawing;
        GraphicsPath currentPath;
        Point oldLocation;
        int historyCounter; //Счетчик истории 
        public Pen currentPen;
        Color historyColor; //Сохранение текущего цвета перед использованием ластика 
        List<Image> History; //Списокдляистории


        public Form1()
        {
            InitializeComponent();
            drawing = false; //Переменная, ответственная за рисование 
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом 
            currentPen.Width = trackBar1.Value; //Инициализация толщины пера 
            History = new List<Image>();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель Коновальцев Никита Сергеевич 2004-2023 гг.");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1; //По умолчанию будет выбрано первое расширение *.jpg И, когда пользователь укажет нужный путь к картинке, ее нужно будет загрузить в PictureBox: 
            if (OP.ShowDialog() != DialogResult.Cancel)
                pictureBox1.Load(OP.FileName);
            pictureBox1.AutoSize = true;

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "") //Если введено не пустое имя 
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;

                }
                fs.Close();
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.Cancel:
                        return;
                }
                History.Clear();
                historyCounter = 0;
                Bitmap pic = new Bitmap(750, 500);
                pictureBox1.Image = pic;
                History.Add(new Bitmap(pictureBox1.Image));
            }
            if (pictureBox1.Image == null)
            {
                History.Clear();
                historyCounter = 0;
                Bitmap pic = new Bitmap(750, 500);
                pictureBox1.Image = pic;
                History.Add(new Bitmap(pictureBox1.Image));
            }




        }

        private void toolStripButton5_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Сначала создайте новый файл!");
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    drawing = true;
                    oldLocation = e.Location;
                    currentPath = new GraphicsPath();
                }
                if (e.Button == MouseButtons.Right)
                {
                    historyColor = currentPen.Color;
                    currentPen.Color =Color.White;
                }
            }


        }

        private void toolStripButton5_MouseUp(object sender, MouseEventArgs e)
        {
            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(pictureBox1.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                currentPath.Dispose();
            }
            catch { };
            if (e.Button == MouseButtons.Right)
            {
                currentPen.Color = historyColor;
            }
        }

        private void toolStripButton5_MouseMove(object sender, MouseEventArgs e)
        {
            {
                if (drawing)
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    currentPath.AddLine(oldLocation, e.Location);
                    g.DrawPath(currentPen, currentPath);
                    oldLocation = e.Location;
                    g.Dispose();
                    pictureBox1.Invalidate();
                }
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            {
                currentPen.Width = trackBar1.Value;
            }

        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;
            solidToolStripMenuItem.Checked = true;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (History.Count != 0 && historyCounter != 0)
                {
                    pictureBox1.Image = new Bitmap(History[--historyCounter]);
                }
                else MessageBox.Show("История пуста");
            }

        }

        private void renoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (historyCounter < History.Count - 1)
                {
                    pictureBox1.Image = new Bitmap(History[++historyCounter]);
                }
                else MessageBox.Show("История пуста");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2(currentPen.Color);
            AddRec.Owner = this;
            AddRec.ShowDialog();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "") //Если введено не пустое имя 
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Png);
                        break;

                }
                fs.Close();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1; //По умолчанию будет выбрано первое расширение *.jpg И, когда пользователь укажет нужный путь к картинке, ее нужно будет загрузить в PictureBox: 
            if (OP.ShowDialog() != DialogResult.Cancel)
                pictureBox1.Load(OP.FileName);
            pictureBox1.AutoSize = true;
        }
    }
}
