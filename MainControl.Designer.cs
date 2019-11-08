namespace Updater
{
    partial class MainControl
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
            this.updateMenu = new Updater.UpdaterMenu.UpdateMenu();
            this.selectionMenu = new Updater.Selector.SelectionMenu();
            this.configMenu = new Updater.Configurator.ConfiguratorMenu();
            this.SuspendLayout();
            // 
            // updateMenu
            // 
            this.updateMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateMenu.Location = new System.Drawing.Point(0, 0);
            this.updateMenu.Margin = new System.Windows.Forms.Padding(0);
            this.updateMenu.MaximumSize = new System.Drawing.Size(60000, 74);
            this.updateMenu.MinimumSize = new System.Drawing.Size(180, 74);
            this.updateMenu.Name = "updateMenu";
            this.updateMenu.Size = new System.Drawing.Size(600, 74);
            this.updateMenu.TabIndex = 4;
            this.updateMenu.OnBackClick += new System.EventHandler(this.OnBackClick);
            this.updateMenu.OnExitClick += new System.EventHandler(this.OnExitClick);
            // 
            // selectionMenu
            // 
            this.selectionMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionMenu.LeftButtonText = "Update";
            this.selectionMenu.Location = new System.Drawing.Point(0, 0);
            this.selectionMenu.MiddleButtonText = "Config";
            this.selectionMenu.MinimumSize = new System.Drawing.Size(302, 70);
            this.selectionMenu.Name = "selectionMenu";
            this.selectionMenu.RightButtonText = "Exit";
            this.selectionMenu.Size = new System.Drawing.Size(600, 400);
            this.selectionMenu.TabIndex = 3;
            this.selectionMenu.OnLeftButtonClick += new System.EventHandler(this.OnUpdateClick);
            this.selectionMenu.MiddleButtonClick += new System.EventHandler(this.OnConfigClick);
            this.selectionMenu.RightButtonClick += new System.EventHandler(this.OnExitClick);
            this.selectionMenu.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            // 
            // configMenu
            // 
            this.configMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configMenu.Location = new System.Drawing.Point(0, 0);
            this.configMenu.MinimumSize = new System.Drawing.Size(476, 188);
            this.configMenu.Name = "configMenu";
            this.configMenu.Size = new System.Drawing.Size(600, 400);
            this.configMenu.TabIndex = 0;
            this.configMenu.OnSaveClick += new System.EventHandler(this.OnSaveClick);
            this.configMenu.OnBackClick += new System.EventHandler(this.OnBackClick);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateMenu);
            this.Controls.Add(this.selectionMenu);
            this.Controls.Add(this.configMenu);
            this.MinimumSize = new System.Drawing.Size(476, 188);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private Configurator.ConfiguratorMenu configMenu;
        private Selector.SelectionMenu selectionMenu;
        private UpdaterMenu.UpdateMenu updateMenu;
    }
}
