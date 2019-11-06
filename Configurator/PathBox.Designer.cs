namespace Updater.Configurator
{
    partial class PathBox
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
            this.pathField = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.changePath = new System.Windows.Forms.Button();
            this.PathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // pathField
            // 
            this.pathField.Location = new System.Drawing.Point(4, 17);
            this.pathField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 3);
            this.pathField.Name = "pathField";
            this.pathField.Size = new System.Drawing.Size(256, 20);
            this.pathField.TabIndex = 0;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoEllipsis = true;
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(42, 13);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "Label...";
            // 
            // changePath
            // 
            this.changePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePath.Location = new System.Drawing.Point(264, 15);
            this.changePath.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.changePath.Name = "changePath";
            this.changePath.Size = new System.Drawing.Size(32, 24);
            this.changePath.TabIndex = 2;
            this.changePath.Text = "...";
            this.changePath.UseVisualStyleBackColor = true;
            this.changePath.Click += new System.EventHandler(this.OnChangePathClick);
            // 
            // PathBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.changePath);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathField);
            this.MaximumSize = new System.Drawing.Size(60000, 40);
            this.MinimumSize = new System.Drawing.Size(150, 40);
            this.Name = "PathBox";
            this.Size = new System.Drawing.Size(300, 40);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathField;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button changePath;
        private System.Windows.Forms.FolderBrowserDialog PathDialog;
    }
}
