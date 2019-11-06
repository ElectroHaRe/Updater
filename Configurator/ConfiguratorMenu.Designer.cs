namespace Updater.Configurator
{
    partial class ConfiguratorMenu
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
            this.nodeCollectionBox = new Updater.Configurator.NodeCollectionBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nodeCollectionBox
            // 
            this.nodeCollectionBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeCollectionBox.Location = new System.Drawing.Point(4, 4);
            this.nodeCollectionBox.Margin = new System.Windows.Forms.Padding(4);
            this.nodeCollectionBox.MinimumSize = new System.Drawing.Size(468, 150);
            this.nodeCollectionBox.Name = "nodeCollectionBox";
            this.nodeCollectionBox.Size = new System.Drawing.Size(468, 150);
            this.nodeCollectionBox.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(4, 162);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(397, 162);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // ConfiguratorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.nodeCollectionBox);
            this.MinimumSize = new System.Drawing.Size(476, 188);
            this.Name = "ConfiguratorMenu";
            this.Size = new System.Drawing.Size(476, 188);
            this.SizeChanged += new System.EventHandler(this.ConfiguratorMenu_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private NodeCollectionBox nodeCollectionBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackButton;
    }
}
