namespace Updater.Selector
{
    partial class SelectionMenu
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
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.MiddleButton = new System.Windows.Forms.Button();
            this.nodeCheckerCollection = new Updater.Selector.NodeCheckerCollectionBox();
            this.SuspendLayout();
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(4, 43);
            this.LeftButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(75, 23);
            this.LeftButton.TabIndex = 1;
            this.LeftButton.Text = "LeftB";
            this.LeftButton.UseVisualStyleBackColor = true;
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(223, 43);
            this.RightButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(75, 23);
            this.RightButton.TabIndex = 2;
            this.RightButton.Text = "RigthB";
            this.RightButton.UseVisualStyleBackColor = true;
            // 
            // MiddleButton
            // 
            this.MiddleButton.Location = new System.Drawing.Point(114, 43);
            this.MiddleButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.MiddleButton.Name = "MiddleButton";
            this.MiddleButton.Size = new System.Drawing.Size(75, 23);
            this.MiddleButton.TabIndex = 3;
            this.MiddleButton.Text = "MiddleB";
            this.MiddleButton.UseVisualStyleBackColor = true;
            // 
            // nodeCheckerCollection
            // 
            this.nodeCheckerCollection.AutoScroll = true;
            this.nodeCheckerCollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeCheckerCollection.Location = new System.Drawing.Point(4, 4);
            this.nodeCheckerCollection.Margin = new System.Windows.Forms.Padding(4);
            this.nodeCheckerCollection.MinimumSize = new System.Drawing.Size(294, 32);
            this.nodeCheckerCollection.Name = "nodeCheckerCollection";
            this.nodeCheckerCollection.Size = new System.Drawing.Size(294, 32);
            this.nodeCheckerCollection.TabIndex = 0;
            // 
            // SelectionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MiddleButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.nodeCheckerCollection);
            this.MinimumSize = new System.Drawing.Size(302, 70);
            this.Name = "SelectionMenu";
            this.Size = new System.Drawing.Size(302, 70);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private NodeCheckerCollectionBox nodeCheckerCollection;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button MiddleButton;
    }
}
