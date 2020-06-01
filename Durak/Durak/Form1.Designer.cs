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
            this.Player1 = new System.Windows.Forms.TextBox();
            this.Player2 = new System.Windows.Forms.TextBox();
            this.MoveButton = new System.Windows.Forms.Button();
            this.SuitPicture = new System.Windows.Forms.PictureBox();
            this.PickUpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SuitPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.Location = new System.Drawing.Point(13, 13);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(100, 22);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "Player1";
            this.Player1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player2
            // 
            this.Player2.Location = new System.Drawing.Point(688, 416);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(100, 22);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "Player2";
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
            this.SuitPicture.Location = new System.Drawing.Point(732, 41);
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
            // Durak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PickUpButton);
            this.Controls.Add(this.SuitPicture);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Durak";
            this.Text = "Durak";
            ((System.ComponentModel.ISupportInitialize)(this.SuitPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Player1;
        private System.Windows.Forms.TextBox Player2;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.PictureBox SuitPicture;
        private System.Windows.Forms.Button PickUpButton;
    }
}

