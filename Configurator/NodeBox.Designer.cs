namespace Updater.Configurator
{
    partial class NodeBox
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
            this.DescriptionField = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.UpArrow = new System.Windows.Forms.Label();
            this.DestinationPathBox = new Updater.Configurator.PathBox();
            this.SourcePathBox = new Updater.Configurator.PathBox();
            this.SuspendLayout();
            // 
            // DescriptionField
            // 
            this.DescriptionField.Location = new System.Drawing.Point(10, 17);
            this.DescriptionField.Margin = new System.Windows.Forms.Padding(10, 4, 0, 0);
            this.DescriptionField.Name = "DescriptionField";
            this.DescriptionField.Size = new System.Drawing.Size(256, 20);
            this.DescriptionField.TabIndex = 2;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(10, 0);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "Description";
            // 
            // UpArrow
            // 
            this.UpArrow.AutoSize = true;
            this.UpArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpArrow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpArrow.Location = new System.Drawing.Point(269, 17);
            this.UpArrow.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.UpArrow.Name = "UpArrow";
            this.UpArrow.Size = new System.Drawing.Size(21, 20);
            this.UpArrow.TabIndex = 9;
            this.UpArrow.Text = "▲";
            this.UpArrow.MouseEnter += new System.EventHandler(this.OnUpArrowMouseEnter);
            this.UpArrow.MouseLeave += new System.EventHandler(this.OnUpArrowMouseLeave);
            // 
            // DestinationPathBox
            // 
            this.DestinationPathBox.Label = "Destination";
            this.DestinationPathBox.Location = new System.Drawing.Point(0, 84);
            this.DestinationPathBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.DestinationPathBox.MaximumSize = new System.Drawing.Size(60000, 40);
            this.DestinationPathBox.MinimumSize = new System.Drawing.Size(150, 40);
            this.DestinationPathBox.Name = "DestinationPathBox";
            this.DestinationPathBox.Path = "";
            this.DestinationPathBox.Size = new System.Drawing.Size(300, 40);
            this.DestinationPathBox.TabIndex = 11;
            // 
            // SourcePathBox
            // 
            this.SourcePathBox.Label = "Source";
            this.SourcePathBox.Location = new System.Drawing.Point(0, 40);
            this.SourcePathBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.SourcePathBox.MaximumSize = new System.Drawing.Size(60000, 40);
            this.SourcePathBox.MinimumSize = new System.Drawing.Size(150, 40);
            this.SourcePathBox.Name = "SourcePathBox";
            this.SourcePathBox.Path = "";
            this.SourcePathBox.Size = new System.Drawing.Size(300, 40);
            this.SourcePathBox.TabIndex = 10;
            // 
            // NodeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DestinationPathBox);
            this.Controls.Add(this.SourcePathBox);
            this.Controls.Add(this.UpArrow);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DescriptionField);
            this.Margin = new System.Windows.Forms.Padding(22, 4, 22, 4);
            this.MaximumSize = new System.Drawing.Size(60000, 124);
            this.MinimumSize = new System.Drawing.Size(200, 124);
            this.Name = "NodeBox";
            this.Size = new System.Drawing.Size(300, 124);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DescriptionField;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label UpArrow;
        private PathBox SourcePathBox;
        private PathBox DestinationPathBox;
    }
}
