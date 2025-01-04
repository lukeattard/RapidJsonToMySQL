
namespace JsonToMysql
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxTableName = new System.Windows.Forms.TextBox();
      this.buttonConvert = new System.Windows.Forms.Button();
      this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
      this.richTextBoxJSON = new System.Windows.Forms.RichTextBox();
      this.checkBoxIgnore = new System.Windows.Forms.CheckBox();
      this.checkedListBoxColumns = new System.Windows.Forms.CheckedListBox();
      this.label4 = new System.Windows.Forms.Label();
      this.checkBoxCreateTable = new System.Windows.Forms.CheckBox();
      this.dataGridViewData = new System.Windows.Forms.DataGridView();
      this.label5 = new System.Windows.Forms.Label();
      this.labelRowCount = new System.Windows.Forms.Label();
      this.buttonUpdate = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
      this.SuspendLayout();
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(491, 77);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Result:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(36, 77);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(83, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Paste json here:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(33, 22);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Table name:";
      // 
      // textBoxTableName
      // 
      this.textBoxTableName.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxTableName.Location = new System.Drawing.Point(100, 20);
      this.textBoxTableName.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxTableName.Name = "textBoxTableName";
      this.textBoxTableName.Size = new System.Drawing.Size(113, 23);
      this.textBoxTableName.TabIndex = 10;
      // 
      // buttonConvert
      // 
      this.buttonConvert.Location = new System.Drawing.Point(493, 248);
      this.buttonConvert.Margin = new System.Windows.Forms.Padding(2);
      this.buttonConvert.Name = "buttonConvert";
      this.buttonConvert.Size = new System.Drawing.Size(68, 20);
      this.buttonConvert.TabIndex = 9;
      this.buttonConvert.Text = "Convert";
      this.buttonConvert.UseVisualStyleBackColor = true;
      this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
      // 
      // richTextBoxResult
      // 
      this.richTextBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxResult.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBoxResult.Location = new System.Drawing.Point(493, 99);
      this.richTextBoxResult.Name = "richTextBoxResult";
      this.richTextBoxResult.ReadOnly = true;
      this.richTextBoxResult.Size = new System.Drawing.Size(487, 131);
      this.richTextBoxResult.TabIndex = 8;
      this.richTextBoxResult.Text = "";
      this.richTextBoxResult.WordWrap = false;
      // 
      // richTextBoxJSON
      // 
      this.richTextBoxJSON.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.richTextBoxJSON.Location = new System.Drawing.Point(36, 99);
      this.richTextBoxJSON.Name = "richTextBoxJSON";
      this.richTextBoxJSON.Size = new System.Drawing.Size(343, 131);
      this.richTextBoxJSON.TabIndex = 7;
      this.richTextBoxJSON.Text = "";
      // 
      // checkBoxIgnore
      // 
      this.checkBoxIgnore.AutoSize = true;
      this.checkBoxIgnore.Location = new System.Drawing.Point(231, 23);
      this.checkBoxIgnore.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxIgnore.Name = "checkBoxIgnore";
      this.checkBoxIgnore.Size = new System.Drawing.Size(111, 17);
      this.checkBoxIgnore.TabIndex = 14;
      this.checkBoxIgnore.Text = "INSERT IGNORE";
      this.checkBoxIgnore.UseVisualStyleBackColor = true;
      // 
      // checkedListBoxColumns
      // 
      this.checkedListBoxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.checkedListBoxColumns.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.checkedListBoxColumns.FormattingEnabled = true;
      this.checkedListBoxColumns.Location = new System.Drawing.Point(36, 295);
      this.checkedListBoxColumns.Margin = new System.Windows.Forms.Padding(2);
      this.checkedListBoxColumns.Name = "checkedListBoxColumns";
      this.checkedListBoxColumns.Size = new System.Drawing.Size(343, 220);
      this.checkedListBoxColumns.TabIndex = 15;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(36, 280);
      this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(50, 13);
      this.label4.TabIndex = 16;
      this.label4.Text = "Columns:";
      // 
      // checkBoxCreateTable
      // 
      this.checkBoxCreateTable.AutoSize = true;
      this.checkBoxCreateTable.Location = new System.Drawing.Point(361, 23);
      this.checkBoxCreateTable.Margin = new System.Windows.Forms.Padding(2);
      this.checkBoxCreateTable.Name = "checkBoxCreateTable";
      this.checkBoxCreateTable.Size = new System.Drawing.Size(83, 17);
      this.checkBoxCreateTable.TabIndex = 17;
      this.checkBoxCreateTable.Text = "Create table";
      this.checkBoxCreateTable.UseVisualStyleBackColor = true;
      // 
      // dataGridViewData
      // 
      this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewData.Location = new System.Drawing.Point(493, 295);
      this.dataGridViewData.Margin = new System.Windows.Forms.Padding(2);
      this.dataGridViewData.Name = "dataGridViewData";
      this.dataGridViewData.ReadOnly = true;
      this.dataGridViewData.RowHeadersWidth = 62;
      this.dataGridViewData.RowTemplate.Height = 28;
      this.dataGridViewData.Size = new System.Drawing.Size(486, 217);
      this.dataGridViewData.TabIndex = 18;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(491, 280);
      this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(58, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "Data view:";
      // 
      // labelRowCount
      // 
      this.labelRowCount.AutoSize = true;
      this.labelRowCount.Location = new System.Drawing.Point(534, 77);
      this.labelRowCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labelRowCount.Name = "labelRowCount";
      this.labelRowCount.Size = new System.Drawing.Size(67, 13);
      this.labelRowCount.TabIndex = 20;
      this.labelRowCount.Text = "Rows count:";
      // 
      // buttonUpdate
      // 
      this.buttonUpdate.Location = new System.Drawing.Point(249, 248);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(130, 23);
      this.buttonUpdate.TabIndex = 21;
      this.buttonUpdate.Text = "Update Columns";
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1014, 539);
      this.Controls.Add(this.buttonUpdate);
      this.Controls.Add(this.labelRowCount);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.dataGridViewData);
      this.Controls.Add(this.checkBoxCreateTable);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.checkedListBoxColumns);
      this.Controls.Add(this.checkBoxIgnore);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBoxTableName);
      this.Controls.Add(this.buttonConvert);
      this.Controls.Add(this.richTextBoxResult);
      this.Controls.Add(this.richTextBoxJSON);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "FormMain";
      this.Text = "Json2Mysql";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.CheckBox checkBoxIgnore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRowCount;
    internal System.Windows.Forms.CheckedListBox checkedListBoxColumns;
    internal System.Windows.Forms.CheckBox checkBoxCreateTable;
    internal System.Windows.Forms.RichTextBox richTextBoxResult;
    internal System.Windows.Forms.RichTextBox richTextBoxJSON;
    private System.Windows.Forms.Button buttonUpdate;
  }
}

