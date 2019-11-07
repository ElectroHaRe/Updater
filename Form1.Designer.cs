namespace Updater
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ConfigButton = new System.Windows.Forms.Button();
            this.nodeCheckerCollectionBox1 = new Updater.Selector.NodeCheckerCollectionBox();
            this.configuratorMenu1 = new Updater.Configurator.ConfiguratorMenu();
            this.updateMenu1 = new Updater.UpdaterMenu.UpdateMenu();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(12, 411);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(713, 411);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ConfigButton
            // 
            this.ConfigButton.Location = new System.Drawing.Point(378, 411);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(75, 23);
            this.ConfigButton.TabIndex = 4;
            this.ConfigButton.Text = "Config";
            this.ConfigButton.UseVisualStyleBackColor = true;
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // nodeCheckerCollectionBox1
            // 
            this.nodeCheckerCollectionBox1.AutoScroll = true;
            this.nodeCheckerCollectionBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeCheckerCollectionBox1.Location = new System.Drawing.Point(12, 12);
            this.nodeCheckerCollectionBox1.MinimumSize = new System.Drawing.Size(294, 32);
            this.nodeCheckerCollectionBox1.Name = "nodeCheckerCollectionBox1";
            this.nodeCheckerCollectionBox1.Size = new System.Drawing.Size(790, 393);
            this.nodeCheckerCollectionBox1.TabIndex = 1;
            // 
            // configuratorMenu1
            // 
            this.configuratorMenu1.Location = new System.Drawing.Point(12, 12);
            this.configuratorMenu1.MinimumSize = new System.Drawing.Size(476, 188);
            this.configuratorMenu1.Name = "configuratorMenu1";
            this.configuratorMenu1.Size = new System.Drawing.Size(776, 426);
            this.configuratorMenu1.TabIndex = 0;
            // 
            // updateMenu1
            // 
            this.updateMenu1.Location = new System.Drawing.Point(141, 151);
            this.updateMenu1.MaximumSize = new System.Drawing.Size(482, 44);
            this.updateMenu1.MinimumSize = new System.Drawing.Size(482, 44);
            this.updateMenu1.Name = "updateMenu1";
            this.updateMenu1.Size = new System.Drawing.Size(482, 44);
            this.updateMenu1.TabIndex = 5;
            this.updateMenu1.OnComplete += new System.Action(this.updateMenu1_OnComplete);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateMenu1);
            this.Controls.Add(this.ConfigButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.nodeCheckerCollectionBox1);
            this.Controls.Add(this.configuratorMenu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Configurator.ConfiguratorMenu configuratorMenu1;
        private Selector.NodeCheckerCollectionBox nodeCheckerCollectionBox1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ConfigButton;
        private UpdaterMenu.UpdateMenu updateMenu1;
    }
}

