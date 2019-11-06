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
            this.nodeCollectionBox1 = new Updater.Configurator.NodeCollectionBox();
            this.SuspendLayout();
            // 
            // nodeCollectionBox1
            // 
            this.nodeCollectionBox1.AutoScroll = true;
            this.nodeCollectionBox1.Location = new System.Drawing.Point(137, 54);
            this.nodeCollectionBox1.Margin = new System.Windows.Forms.Padding(22, 4, 22, 4);
            this.nodeCollectionBox1.Name = "nodeCollectionBox1";
            this.nodeCollectionBox1.Size = new System.Drawing.Size(468, 343);
            this.nodeCollectionBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nodeCollectionBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Configurator.NodeCollectionBox nodeCollectionBox1;
    }
}

