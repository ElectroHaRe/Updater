﻿namespace Updater
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.configuratorMenu1 = new Updater.Configurator.ConfiguratorMenu();
            this.SuspendLayout();
            // 
            // configuratorMenu1
            // 
            this.configuratorMenu1.Location = new System.Drawing.Point(12, 12);
            this.configuratorMenu1.MinimumSize = new System.Drawing.Size(476, 188);
            this.configuratorMenu1.Name = "configuratorMenu1";
            this.configuratorMenu1.Size = new System.Drawing.Size(776, 426);
            this.configuratorMenu1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.configuratorMenu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Configurator.ConfiguratorMenu configuratorMenu1;
    }
}
