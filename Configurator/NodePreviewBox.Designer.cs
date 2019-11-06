namespace Updater.Configurator
{
    partial class NodePreviewBox
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionField = new System.Windows.Forms.TextBox();
            this.SourcePathField = new System.Windows.Forms.TextBox();
            this.SourcePathLabel = new System.Windows.Forms.Label();
            this.DestinationPathLabel = new System.Windows.Forms.Label();
            this.DestinationPathField = new System.Windows.Forms.TextBox();
            this.DownArrow = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoEllipsis = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(4, 0);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(128, 12);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Description";
            // 
            // DescriptionField
            // 
            this.DescriptionField.Location = new System.Drawing.Point(4, 16);
            this.DescriptionField.Margin = new System.Windows.Forms.Padding(4);
            this.DescriptionField.Name = "DescriptionField";
            this.DescriptionField.ReadOnly = true;
            this.DescriptionField.Size = new System.Drawing.Size(128, 20);
            this.DescriptionField.TabIndex = 3;
            // 
            // SourcePathField
            // 
            this.SourcePathField.Location = new System.Drawing.Point(136, 16);
            this.SourcePathField.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.SourcePathField.Name = "SourcePathField";
            this.SourcePathField.ReadOnly = true;
            this.SourcePathField.Size = new System.Drawing.Size(128, 20);
            this.SourcePathField.TabIndex = 4;
            // 
            // SourcePathLabel
            // 
            this.SourcePathLabel.AutoEllipsis = true;
            this.SourcePathLabel.Location = new System.Drawing.Point(136, 0);
            this.SourcePathLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.SourcePathLabel.Name = "SourcePathLabel";
            this.SourcePathLabel.Size = new System.Drawing.Size(128, 12);
            this.SourcePathLabel.TabIndex = 5;
            this.SourcePathLabel.Text = "Source";
            // 
            // DestinationPathLabel
            // 
            this.DestinationPathLabel.AutoEllipsis = true;
            this.DestinationPathLabel.Location = new System.Drawing.Point(268, 0);
            this.DestinationPathLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.DestinationPathLabel.Name = "DestinationPathLabel";
            this.DestinationPathLabel.Size = new System.Drawing.Size(128, 12);
            this.DestinationPathLabel.TabIndex = 7;
            this.DestinationPathLabel.Text = "Destination";
            // 
            // DestinationPathField
            // 
            this.DestinationPathField.Location = new System.Drawing.Point(268, 16);
            this.DestinationPathField.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.DestinationPathField.Name = "DestinationPathField";
            this.DestinationPathField.ReadOnly = true;
            this.DestinationPathField.Size = new System.Drawing.Size(128, 20);
            this.DestinationPathField.TabIndex = 6;
            // 
            // DownArrow
            // 
            this.DownArrow.AutoSize = true;
            this.DownArrow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DownArrow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DownArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownArrow.Location = new System.Drawing.Point(400, 16);
            this.DownArrow.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.DownArrow.Name = "DownArrow";
            this.DownArrow.Size = new System.Drawing.Size(21, 20);
            this.DownArrow.TabIndex = 8;
            this.DownArrow.Text = "▼";
            this.DownArrow.MouseEnter += new System.EventHandler(this.OnDownArrowMouseEnter);
            this.DownArrow.MouseLeave += new System.EventHandler(this.DownArrow_MouseLeave);
            // 
            // NodePreviewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DownArrow);
            this.Controls.Add(this.DestinationPathLabel);
            this.Controls.Add(this.DestinationPathField);
            this.Controls.Add(this.SourcePathLabel);
            this.Controls.Add(this.SourcePathField);
            this.Controls.Add(this.DescriptionField);
            this.Controls.Add(this.DescriptionLabel);
            this.Margin = new System.Windows.Forms.Padding(22, 4, 22, 4);
            this.MaximumSize = new System.Drawing.Size(60000, 40);
            this.MinimumSize = new System.Drawing.Size(424, 40);
            this.Name = "NodePreviewBox";
            this.Size = new System.Drawing.Size(424, 40);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionField;
        private System.Windows.Forms.TextBox SourcePathField;
        private System.Windows.Forms.Label SourcePathLabel;
        private System.Windows.Forms.Label DestinationPathLabel;
        private System.Windows.Forms.TextBox DestinationPathField;
        private System.Windows.Forms.Label DownArrow;
    }
}
