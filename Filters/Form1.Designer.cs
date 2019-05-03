﻿namespace Filters
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
            this.btnImage = new System.Windows.Forms.Button();
            this.blurRadioButton = new System.Windows.Forms.RadioButton();
            this.grayscaleRadioButton = new System.Windows.Forms.RadioButton();
            this.negativeRadioButton = new System.Windows.Forms.RadioButton();
            this.sepiaRadioButton = new System.Windows.Forms.RadioButton();
            this.mediaRadioButton = new System.Windows.Forms.RadioButton();
            this.transparencyRadioButton = new System.Windows.Forms.RadioButton();
            this.panelSource = new System.Windows.Forms.PictureBox();
            this.panelOutput = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(13, 800);
            this.btnImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(100, 28);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "Carregar Imagem";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // blurRadioButton
            // 
            this.blurRadioButton.AutoSize = true;
            this.blurRadioButton.Location = new System.Drawing.Point(165, 782);
            this.blurRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.blurRadioButton.Name = "blurRadioButton";
            this.blurRadioButton.Size = new System.Drawing.Size(54, 21);
            this.blurRadioButton.TabIndex = 4;
            this.blurRadioButton.TabStop = true;
            this.blurRadioButton.Text = "Blur";
            this.blurRadioButton.UseVisualStyleBackColor = true;
            this.blurRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // grayscaleRadioButton
            // 
            this.grayscaleRadioButton.AutoSize = true;
            this.grayscaleRadioButton.Location = new System.Drawing.Point(165, 810);
            this.grayscaleRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.grayscaleRadioButton.Name = "grayscaleRadioButton";
            this.grayscaleRadioButton.Size = new System.Drawing.Size(93, 21);
            this.grayscaleRadioButton.TabIndex = 5;
            this.grayscaleRadioButton.TabStop = true;
            this.grayscaleRadioButton.Text = "Grayscale";
            this.grayscaleRadioButton.UseVisualStyleBackColor = true;
            this.grayscaleRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // negativeRadioButton
            // 
            this.negativeRadioButton.AutoSize = true;
            this.negativeRadioButton.Location = new System.Drawing.Point(313, 782);
            this.negativeRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.negativeRadioButton.Name = "negativeRadioButton";
            this.negativeRadioButton.Size = new System.Drawing.Size(85, 21);
            this.negativeRadioButton.TabIndex = 6;
            this.negativeRadioButton.TabStop = true;
            this.negativeRadioButton.Text = "Negative";
            this.negativeRadioButton.UseVisualStyleBackColor = true;
            this.negativeRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // sepiaRadioButton
            // 
            this.sepiaRadioButton.AutoSize = true;
            this.sepiaRadioButton.Location = new System.Drawing.Point(313, 810);
            this.sepiaRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.sepiaRadioButton.Name = "sepiaRadioButton";
            this.sepiaRadioButton.Size = new System.Drawing.Size(65, 21);
            this.sepiaRadioButton.TabIndex = 7;
            this.sepiaRadioButton.TabStop = true;
            this.sepiaRadioButton.Text = "Sepia";
            this.sepiaRadioButton.UseVisualStyleBackColor = true;
            this.sepiaRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // mediaRadioButton
            // 
            this.mediaRadioButton.AutoSize = true;
            this.mediaRadioButton.Location = new System.Drawing.Point(457, 782);
            this.mediaRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.mediaRadioButton.Name = "mediaRadioButton";
            this.mediaRadioButton.Size = new System.Drawing.Size(67, 21);
            this.mediaRadioButton.TabIndex = 8;
            this.mediaRadioButton.TabStop = true;
            this.mediaRadioButton.Text = "Media";
            this.mediaRadioButton.UseVisualStyleBackColor = true;
            this.mediaRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // transparencyRadioButton
            // 
            this.transparencyRadioButton.AutoSize = true;
            this.transparencyRadioButton.Location = new System.Drawing.Point(457, 810);
            this.transparencyRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.transparencyRadioButton.Name = "transparencyRadioButton";
            this.transparencyRadioButton.Size = new System.Drawing.Size(117, 21);
            this.transparencyRadioButton.TabIndex = 9;
            this.transparencyRadioButton.TabStop = true;
            this.transparencyRadioButton.Text = "Transparency";
            this.transparencyRadioButton.UseVisualStyleBackColor = true;
            this.transparencyRadioButton.CheckedChanged += new System.EventHandler(this.OnCheckChangedEventHandler);
            // 
            // panelSource
            // 
            this.panelSource.Location = new System.Drawing.Point(16, 28);
            this.panelSource.Margin = new System.Windows.Forms.Padding(4);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(666, 727);
            this.panelSource.TabIndex = 10;
            this.panelSource.TabStop = false;
            // 
            // panelOutput
            // 
            this.panelOutput.Location = new System.Drawing.Point(749, 28);
            this.panelOutput.Margin = new System.Windows.Forms.Padding(4);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(666, 727);
            this.panelOutput.TabIndex = 11;
            this.panelOutput.TabStop = false;
            this.panelOutput.Click += new System.EventHandler(this.panelOutput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 973);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.panelSource);
            this.Controls.Add(this.transparencyRadioButton);
            this.Controls.Add(this.mediaRadioButton);
            this.Controls.Add(this.sepiaRadioButton);
            this.Controls.Add(this.negativeRadioButton);
            this.Controls.Add(this.grayscaleRadioButton);
            this.Controls.Add(this.blurRadioButton);
            this.Controls.Add(this.btnImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.RadioButton blurRadioButton;
        private System.Windows.Forms.RadioButton grayscaleRadioButton;
        private System.Windows.Forms.RadioButton negativeRadioButton;
        private System.Windows.Forms.RadioButton sepiaRadioButton;
        private System.Windows.Forms.RadioButton mediaRadioButton;
        private System.Windows.Forms.RadioButton transparencyRadioButton;
        private System.Windows.Forms.PictureBox panelSource;
        private System.Windows.Forms.PictureBox panelOutput;
    }
}

