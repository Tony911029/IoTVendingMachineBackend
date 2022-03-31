
namespace IoTVendingMachineBackend
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
            this.item1 = new System.Windows.Forms.TextBox();
            this.item4 = new System.Windows.Forms.TextBox();
            this.item3 = new System.Windows.Forms.TextBox();
            this.item2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.name1 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.Label();
            this.name3 = new System.Windows.Forms.Label();
            this.name4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // item1
            // 
            this.item1.Location = new System.Drawing.Point(125, 72);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(100, 25);
            this.item1.TabIndex = 1;
            // 
            // item4
            // 
            this.item4.Location = new System.Drawing.Point(125, 227);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(100, 25);
            this.item4.TabIndex = 2;
            // 
            // item3
            // 
            this.item3.Location = new System.Drawing.Point(125, 175);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(100, 25);
            this.item3.TabIndex = 3;
            // 
            // item2
            // 
            this.item2.Location = new System.Drawing.Point(125, 122);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(100, 25);
            this.item2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Submit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(274, 229);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Submit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // name1
            // 
            this.name1.AutoSize = true;
            this.name1.Location = new System.Drawing.Point(21, 75);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(44, 15);
            this.name1.TabIndex = 9;
            this.name1.Text = "name1";
            // 
            // name2
            // 
            this.name2.AutoSize = true;
            this.name2.Location = new System.Drawing.Point(21, 125);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(44, 15);
            this.name2.TabIndex = 10;
            this.name2.Text = "name2";
            // 
            // name3
            // 
            this.name3.AutoSize = true;
            this.name3.Location = new System.Drawing.Point(21, 183);
            this.name3.Name = "name3";
            this.name3.Size = new System.Drawing.Size(44, 15);
            this.name3.TabIndex = 11;
            this.name3.Text = "name3";
            // 
            // name4
            // 
            this.name4.AutoSize = true;
            this.name4.Location = new System.Drawing.Point(21, 230);
            this.name4.Name = "name4";
            this.name4.Size = new System.Drawing.Size(44, 15);
            this.name4.TabIndex = 12;
            this.name4.Text = "name4";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(140, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(171, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "UpdateStockToCloud";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 361);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.name4);
            this.Controls.Add(this.name3);
            this.Controls.Add(this.name2);
            this.Controls.Add(this.name1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.item2);
            this.Controls.Add(this.item3);
            this.Controls.Add(this.item4);
            this.Controls.Add(this.item1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox item1;
        private System.Windows.Forms.TextBox item4;
        private System.Windows.Forms.TextBox item3;
        private System.Windows.Forms.TextBox item2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label name1;
        private System.Windows.Forms.Label name2;
        private System.Windows.Forms.Label name3;
        private System.Windows.Forms.Label name4;
        private System.Windows.Forms.Button button5;
    }
}

