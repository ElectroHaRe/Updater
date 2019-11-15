namespace Updater.UpdaterMenu
{
    partial class UpdateMenu
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgressBox = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBox
            // 
            this.ProgressBox.Location = new System.Drawing.Point(4, 17);
            this.ProgressBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBox.Maximum = 1000;
            this.ProgressBox.Name = "ProgressBox";
            this.ProgressBox.Size = new System.Drawing.Size(474, 23);
            this.ProgressBox.TabIndex = 0;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoEllipsis = true;
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(3, 0);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(16, 13);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "...";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(4, 47);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "<<";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(403, 47);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // UpdateMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.ProgressBox);
            this.MaximumSize = new System.Drawing.Size(60000, 74);
            this.MinimumSize = new System.Drawing.Size(180, 74);
            this.Name = "UpdateMenu";
            this.Size = new System.Drawing.Size(482, 74);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBox;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ExitButton;
    }
}
