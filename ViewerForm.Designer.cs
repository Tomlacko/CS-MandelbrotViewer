namespace FinalProject
{
	partial class ViewerForm
	{
		/// <summary>
		/// Vyžaduje se proměnná návrháře.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Uvolněte všechny používané prostředky.
		/// </summary>
		/// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kód generovaný Návrhářem Windows Form

		/// <summary>
		/// Metoda vyžadovaná pro podporu Návrháře - neupravovat
		/// obsah této metody v editoru kódu.
		/// </summary>
		private void InitializeComponent()
		{
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.btnSaveCfg = new System.Windows.Forms.Button();
            this.btnLoadCfg = new System.Windows.Forms.Button();
            this.inputY = new System.Windows.Forms.TextBox();
            this.inputX = new System.Windows.Forms.TextBox();
            this.inputZoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(640, 480);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox.TabIndex = 0;
            this.imgBox.TabStop = false;
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(646, 447);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(79, 23);
            this.btnRender.TabIndex = 1;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // btnSaveImg
            // 
            this.btnSaveImg.Enabled = false;
            this.btnSaveImg.Location = new System.Drawing.Point(646, 12);
            this.btnSaveImg.Name = "btnSaveImg";
            this.btnSaveImg.Size = new System.Drawing.Size(79, 23);
            this.btnSaveImg.TabIndex = 2;
            this.btnSaveImg.Text = "Save Image";
            this.btnSaveImg.UseVisualStyleBackColor = true;
            this.btnSaveImg.Click += new System.EventHandler(this.btnSaveImg_Click);
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Location = new System.Drawing.Point(646, 41);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.Size = new System.Drawing.Size(79, 23);
            this.btnSaveCfg.TabIndex = 4;
            this.btnSaveCfg.Text = "Save Config";
            this.btnSaveCfg.UseVisualStyleBackColor = true;
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // btnLoadCfg
            // 
            this.btnLoadCfg.Location = new System.Drawing.Point(646, 70);
            this.btnLoadCfg.Name = "btnLoadCfg";
            this.btnLoadCfg.Size = new System.Drawing.Size(79, 23);
            this.btnLoadCfg.TabIndex = 5;
            this.btnLoadCfg.Text = "Load Config";
            this.btnLoadCfg.UseVisualStyleBackColor = true;
            this.btnLoadCfg.Click += new System.EventHandler(this.btnLoadCfg_Click);
            // 
            // inputY
            // 
            this.inputY.Location = new System.Drawing.Point(660, 360);
            this.inputY.Name = "inputY";
            this.inputY.Size = new System.Drawing.Size(65, 20);
            this.inputY.TabIndex = 6;
            this.inputY.Text = "0";
            // 
            // inputX
            // 
            this.inputX.Location = new System.Drawing.Point(660, 334);
            this.inputX.Name = "inputX";
            this.inputX.Size = new System.Drawing.Size(65, 20);
            this.inputX.TabIndex = 7;
            this.inputX.Text = "0";
            // 
            // inputZoom
            // 
            this.inputZoom.Location = new System.Drawing.Point(646, 409);
            this.inputZoom.Name = "inputZoom";
            this.inputZoom.Size = new System.Drawing.Size(79, 20);
            this.inputZoom.TabIndex = 8;
            this.inputZoom.Text = "128";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zoom:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(737, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputZoom);
            this.Controls.Add(this.inputX);
            this.Controls.Add(this.inputY);
            this.Controls.Add(this.btnLoadCfg);
            this.Controls.Add(this.btnSaveCfg);
            this.Controls.Add(this.btnSaveImg);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.imgBox);
            this.Name = "Form1";
            this.Text = "Mandelbrot Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgBox;
		private System.Windows.Forms.Button btnRender;
		private System.Windows.Forms.Button btnSaveImg;
		private System.Windows.Forms.Button btnSaveCfg;
		private System.Windows.Forms.Button btnLoadCfg;
		private System.Windows.Forms.TextBox inputY;
		private System.Windows.Forms.TextBox inputX;
		private System.Windows.Forms.TextBox inputZoom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

