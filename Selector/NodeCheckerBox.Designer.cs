namespace Updater.Selector
{
    partial class NodeCheckerBox
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
            this.Checker = new System.Windows.Forms.CheckBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Checker
            // 
            this.Checker.AutoSize = true;
            this.Checker.Location = new System.Drawing.Point(3, 3);
            this.Checker.Name = "Checker";
            this.Checker.Size = new System.Drawing.Size(80, 17);
            this.Checker.TabIndex = 0;
            this.Checker.Text = "checkBox1";
            this.Checker.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoEllipsis = true;
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(89, 4);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(35, 13);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "label1";
            this.StatusLabel.Click += new System.EventHandler(this.OnClick);
            // 
            // NodeCheckerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.Checker);
            this.Margin = new System.Windows.Forms.Padding(22, 4, 22, 4);
            this.MinimumSize = new System.Drawing.Size(200, 22);
            this.Name = "NodeCheckerBox";
            this.Size = new System.Drawing.Size(248, 20);
            this.Click += new System.EventHandler(this.OnClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Checker;
        private System.Windows.Forms.Label StatusLabel;
    }
}
