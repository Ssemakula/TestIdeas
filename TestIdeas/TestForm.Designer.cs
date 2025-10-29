namespace TestIdeas
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.label1 = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.placeTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(183, 58);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(255, 20);
            this.locationTextBox.TabIndex = 2;
            // 
            // goButton
            // 
            this.goButton.Image = ((System.Drawing.Image)(resources.GetObject("goButton.Image")));
            this.goButton.Location = new System.Drawing.Point(447, 54);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(34, 29);
            this.goButton.TabIndex = 3;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // placeTextBox
            // 
            this.placeTextBox.Location = new System.Drawing.Point(497, 57);
            this.placeTextBox.Name = "placeTextBox";
            this.placeTextBox.Size = new System.Drawing.Size(285, 20);
            this.placeTextBox.TabIndex = 4;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(183, 109);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(599, 295);
            this.resultTextBox.TabIndex = 5;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 504);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.placeTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.label1);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox placeTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

