namespace Durak
{
    partial class Durak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Durak));
            this.Player1 = new System.Windows.Forms.TextBox();
            this.Player2 = new System.Windows.Forms.TextBox();
            this.MoveButton = new System.Windows.Forms.Button();
            this.SuitPicture = new System.Windows.Forms.PictureBox();
            this.PickUpButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SuitPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.Location = new System.Drawing.Point(330, 166);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(100, 22);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "Player1";
            this.Player1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player2
            // 
            this.Player2.Location = new System.Drawing.Point(330, 203);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(100, 22);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "Player2";
            this.Player2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(688, 141);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(100, 59);
            this.MoveButton.TabIndex = 2;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // SuitPicture
            // 
            this.SuitPicture.Image = global::Durak.Properties.Resources.Diamonds;
            this.SuitPicture.Location = new System.Drawing.Point(732, 53);
            this.SuitPicture.Name = "SuitPicture";
            this.SuitPicture.Size = new System.Drawing.Size(56, 50);
            this.SuitPicture.TabIndex = 3;
            this.SuitPicture.TabStop = false;
            this.SuitPicture.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // PickUpButton
            // 
            this.PickUpButton.Location = new System.Drawing.Point(688, 206);
            this.PickUpButton.Name = "PickUpButton";
            this.PickUpButton.Size = new System.Drawing.Size(100, 59);
            this.PickUpButton.TabIndex = 4;
            this.PickUpButton.Text = "Pick up";
            this.PickUpButton.UseVisualStyleBackColor = true;
            this.PickUpButton.Click += new System.EventHandler(this.PickUpButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.Player1);
            this.panel1.Controls.Add(this.Player2);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 435);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter names of the players";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(342, 396);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(729, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // Durak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PickUpButton);
            this.Controls.Add(this.SuitPicture);
            this.Controls.Add(this.MoveButton);
            this.Name = "Durak";
            this.Text = "Durak";
            ((System.ComponentModel.ISupportInitialize)(this.SuitPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Player1;
        private System.Windows.Forms.TextBox Player2;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.PictureBox SuitPicture;
        private System.Windows.Forms.Button PickUpButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

