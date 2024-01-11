using System.Windows.Forms;

namespace GraphProblemsWF
{
    partial class Form1
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
            this.dfsButton = new System.Windows.Forms.Button();
            this.bfsButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dfsButton
            // 
            this.dfsButton.Location = new System.Drawing.Point(9, 12);
            this.dfsButton.Name = "dfsButton";
            this.dfsButton.Size = new System.Drawing.Size(100, 80);
            this.dfsButton.TabIndex = 1;
            this.dfsButton.Text = "DFS-Matrice";
            this.dfsButton.UseVisualStyleBackColor = true;
            this.dfsButton.Click += new System.EventHandler(this.dfsButton_Click);
            // 
            // bfsButton
            // 
            this.bfsButton.Location = new System.Drawing.Point(130, 12);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(100, 80);
            this.bfsButton.TabIndex = 4;
            this.bfsButton.Text = "BFS-Lista";
            this.bfsButton.UseVisualStyleBackColor = true;
            this.bfsButton.Click += new System.EventHandler(this.bfsButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1178, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(216, 324);
            this.listBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 629);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bfsButton);
            this.Controls.Add(this.dfsButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private Button dfsButton;
        private Button bfsButton;
        private ListBox listBox1;
    }
}