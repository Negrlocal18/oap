namespace PRAKTICHESKOE_ZADANIE_21
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRazdel1Form2 = new System.Windows.Forms.RadioButton();
            this.rbRazdel2Form2 = new System.Windows.Forms.RadioButton();
            this.tbform2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndobav2 = new System.Windows.Forms.Button();
            this.btnotmena2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRazdel2Form2);
            this.groupBox1.Controls.Add(this.rbRazdel1Form2);
            this.groupBox1.Location = new System.Drawing.Point(29, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить в";
            // 
            // rbRazdel1Form2
            // 
            this.rbRazdel1Form2.AutoSize = true;
            this.rbRazdel1Form2.Location = new System.Drawing.Point(7, 20);
            this.rbRazdel1Form2.Name = "rbRazdel1Form2";
            this.rbRazdel1Form2.Size = new System.Drawing.Size(71, 17);
            this.rbRazdel1Form2.TabIndex = 0;
            this.rbRazdel1Form2.TabStop = true;
            this.rbRazdel1Form2.Text = "Раздел 1";
            this.rbRazdel1Form2.UseVisualStyleBackColor = true;
            // 
            // rbRazdel2Form2
            // 
            this.rbRazdel2Form2.AutoSize = true;
            this.rbRazdel2Form2.Location = new System.Drawing.Point(7, 43);
            this.rbRazdel2Form2.Name = "rbRazdel2Form2";
            this.rbRazdel2Form2.Size = new System.Drawing.Size(71, 17);
            this.rbRazdel2Form2.TabIndex = 1;
            this.rbRazdel2Form2.TabStop = true;
            this.rbRazdel2Form2.Text = "Раздел 2";
            this.rbRazdel2Form2.UseVisualStyleBackColor = true;
            // 
            // tbform2
            // 
            this.tbform2.Location = new System.Drawing.Point(29, 130);
            this.tbform2.Name = "tbform2";
            this.tbform2.Size = new System.Drawing.Size(200, 20);
            this.tbform2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите текст:";
            // 
            // btndobav2
            // 
            this.btndobav2.Location = new System.Drawing.Point(29, 157);
            this.btndobav2.Name = "btndobav2";
            this.btndobav2.Size = new System.Drawing.Size(89, 23);
            this.btndobav2.TabIndex = 3;
            this.btndobav2.Text = "Добавить";
            this.btndobav2.UseVisualStyleBackColor = true;
            this.btndobav2.Click += new System.EventHandler(this.btndobav2_Click);
            // 
            // btnotmena2
            // 
            this.btnotmena2.Location = new System.Drawing.Point(140, 157);
            this.btnotmena2.Name = "btnotmena2";
            this.btnotmena2.Size = new System.Drawing.Size(89, 23);
            this.btnotmena2.TabIndex = 4;
            this.btnotmena2.Text = "Отмена";
            this.btnotmena2.UseVisualStyleBackColor = true;
            this.btnotmena2.Click += new System.EventHandler(this.btnotmena2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnotmena2);
            this.Controls.Add(this.btndobav2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbform2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRazdel2Form2;
        private System.Windows.Forms.RadioButton rbRazdel1Form2;
        private System.Windows.Forms.TextBox tbform2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndobav2;
        private System.Windows.Forms.Button btnotmena2;
    }
}