namespace Updater.Configurator
{
    partial class NodeCollectionBox
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
            this.AddButton = new System.Windows.Forms.Label();
            this.VScrollBar = new System.Windows.Forms.VScrollBar();
            this.RemoveButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(238, 4);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(26, 19);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "➕";
            this.AddButton.Click += new System.EventHandler(this.OnAddButtonClick);
            this.AddButton.MouseEnter += new System.EventHandler(this.OnAddButtonMouseEnter);
            this.AddButton.MouseLeave += new System.EventHandler(this.AddButton_MouseLeave);
            // 
            // VScrollBar
            // 
            this.VScrollBar.Location = new System.Drawing.Point(451, 0);
            this.VScrollBar.Name = "VScrollBar";
            this.VScrollBar.Size = new System.Drawing.Size(17, 343);
            this.VScrollBar.TabIndex = 3;
            this.VScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBar_Scroll);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveButton.Location = new System.Drawing.Point(204, 4);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(26, 19);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "➖";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            this.RemoveButton.MouseEnter += new System.EventHandler(this.RemoveButton_MouseEnter);
            this.RemoveButton.MouseLeave += new System.EventHandler(this.RemoveButton_MouseLeave);
            // 
            // NodeCollectionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.VScrollBar);
            this.Controls.Add(this.AddButton);
            this.Margin = new System.Windows.Forms.Padding(22, 4, 22, 4);
            this.MinimumSize = new System.Drawing.Size(468, 150);
            this.Name = "NodeCollectionBox";
            this.Size = new System.Drawing.Size(468, 343);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label AddButton;
        private System.Windows.Forms.VScrollBar VScrollBar;
        private System.Windows.Forms.Label RemoveButton;
    }
}
