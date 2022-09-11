namespace rc_frequency_finder
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kinectImage = new System.Windows.Forms.PictureBox();
            this.IPText = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portText = new System.Windows.Forms.TextBox();
            this.thresholdText = new System.Windows.Forms.TextBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.differenceLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kinectImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kinectImage
            // 
            this.kinectImage.Location = new System.Drawing.Point(316, 22);
            this.kinectImage.Name = "kinectImage";
            this.kinectImage.Size = new System.Drawing.Size(472, 466);
            this.kinectImage.TabIndex = 0;
            this.kinectImage.TabStop = false;
            // 
            // IPText
            // 
            this.IPText.Location = new System.Drawing.Point(67, 39);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(100, 20);
            this.IPText.TabIndex = 1;
            this.IPText.Text = "raspberrypi.local";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(12, 46);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(20, 13);
            this.IPLabel.TabIndex = 2;
            this.IPLabel.Text = "IP:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 88);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 4;
            this.portLabel.Text = "Port:";
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(67, 81);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(100, 20);
            this.portText.TabIndex = 3;
            this.portText.Text = "12345";
            // 
            // thresholdText
            // 
            this.thresholdText.Location = new System.Drawing.Point(67, 126);
            this.thresholdText.Name = "thresholdText";
            this.thresholdText.Size = new System.Drawing.Size(100, 20);
            this.thresholdText.TabIndex = 5;
            this.thresholdText.Text = "1.5";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(7, 133);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.thresholdLabel.TabIndex = 6;
            this.thresholdLabel.Text = "Threshold";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(67, 173);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // differenceLabel
            // 
            this.differenceLabel.AutoSize = true;
            this.differenceLabel.Location = new System.Drawing.Point(527, 6);
            this.differenceLabel.Name = "differenceLabel";
            this.differenceLabel.Size = new System.Drawing.Size(59, 13);
            this.differenceLabel.TabIndex = 8;
            this.differenceLabel.Text = "Difference:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(10, 202);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputTextBox.Size = new System.Drawing.Size(274, 286);
            this.outputTextBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.differenceLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.thresholdText);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPText);
            this.Controls.Add(this.kinectImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kinectImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox kinectImage;
        private System.Windows.Forms.TextBox IPText;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox thresholdText;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label differenceLabel;
        private System.Windows.Forms.TextBox outputTextBox;
    }
}

