
namespace WinFormsOP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clienteSel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // clienteSel
            // 
            this.clienteSel.AccessibleDescription = "clienteSel";
            this.clienteSel.AccessibleName = "clienteSel";
            this.clienteSel.FormattingEnabled = true;
            this.clienteSel.Location = new System.Drawing.Point(55, 24);
            this.clienteSel.Name = "clienteSel";
            this.clienteSel.Size = new System.Drawing.Size(121, 23);
            this.clienteSel.TabIndex = 0;
            this.clienteSel.Text = "Cliente";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clienteSel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox clienteSel;
    }
}

