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
            this.ArrowButton = new System.Windows.Forms.Label();
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
            this.DescriptionLabel.Text = "Description \\ Описание";
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
            this.SourcePathLabel.Text = "Source \\ Источник";
            // 
            // DestinationPathLabel
            // 
            this.DestinationPathLabel.AutoEllipsis = true;
            this.DestinationPathLabel.Location = new System.Drawing.Point(268, 0);
            this.DestinationPathLabel.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.DestinationPathLabel.Name = "DestinationPathLabel";
            this.DestinationPathLabel.Size = new System.Drawing.Size(128, 12);
            this.DestinationPathLabel.TabIndex = 7;
            this.DestinationPathLabel.Text = "Destination \\ Назначение";
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
            // ArrowButton
            // 
            this.ArrowButton.AutoSize = true;
            this.ArrowButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ArrowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArrowButton.Location = new System.Drawing.Point(400, 16);
            this.ArrowButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ArrowButton.Name = "ArrowButton";
            this.ArrowButton.Size = new System.Drawing.Size(21, 20);
            this.ArrowButton.TabIndex = 8;
            this.ArrowButton.Text = "▼";
            this.ArrowButton.MouseEnter += new System.EventHandler(this.OnArrowMouseEnter);
            this.ArrowButton.MouseLeave += new System.EventHandler(this.OnArrowMouseLeave);
            // 
            // NodePreviewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ArrowButton);
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
        private System.Windows.Forms.Label ArrowButton;
    }
}
