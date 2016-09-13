namespace ToDoApp
{
    partial class ToDoForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toDoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.toDoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.toDoBindingSource, "AddingTaskContent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 19);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.toDoBindingSource, "CanAdd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button1.Location = new System.Drawing.Point(228, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toDoBindingSource
            // 
            this.toDoBindingSource.DataSource = typeof(ToDoApp.ToDo);
            // 
            // ToDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "ToDoForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ToDoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource toDoBindingSource;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

