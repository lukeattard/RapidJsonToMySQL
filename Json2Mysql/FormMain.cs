using FastReport.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JsonToMysql.Code;

namespace JsonToMysql {
  public partial class FormMain : Form {

    internal FormMain MainForm;
    internal Code MyCode = new Code();
    public void CreatePointerTo(FormMain _MainForm) {
      MainForm = _MainForm;
      MyCode.MainForm = _MainForm;
    }
    public FormMain() {
      InitializeComponent();
    }
    private void buttonUpdate_Click(object sender, EventArgs e) {
      MyCode.InitializeDataSource();
      MyCode.InitializeCheckedListBox();
    }

    private void buttonConvert_Click(object sender, EventArgs e) {
      if (MyCode.dataSource == null) {
        MyCode.InitializeDataSource();
        MyCode.InitializeCheckedListBox();
      }
      if (textBoxTableName.TextLength == 0 || richTextBoxJSON.TextLength == 0 || MyCode.dataSource == null || MyCode.dataSource.Count == 0) {
        MessageBox.Show("Please input table name and paste JSON text.");
        return;
      }
      string sql = MyCode.JsonToMysql(textBoxTableName.Text, checkedListBoxColumns);

      richTextBoxResult.Clear();
      richTextBoxResult.Text = sql;
      labelRowCount.Text = $"Rows count: {MyCode.dataSource.Count}";
      UpdateDataGridView();
    }


    internal string GetJSON() {
      return MainForm.richTextBoxJSON.Text.ToString();
    }
    void UpdateDataGridView() {
      dataGridViewData.Columns.Clear();
      dataGridViewData.Rows.Clear();
      foreach (string column in MyCode.DataTable.ColumnHeaders) {
        dataGridViewData.Columns.Add(column, column);
      }

      foreach (DataTableClass.DataRow currRow in MyCode.DataTable.DataRows) {
        List<string> listStrRow = new List<string>();
        foreach (string column in MyCode.DataTable.ColumnHeaders) {
          List<string> listValue = new List<string>();
          var result = from x in currRow.DataColumns
                       where x.Key == column
                       select x.Value;
          if (result.Count() == 0) {
            listStrRow.Add("");
          } else {
            listStrRow.Add(result.First());
          }
        }
        dataGridViewData.Rows.Add(listStrRow.ToArray());
      }
    }


    private void FormMain_FormClosed(object sender, FormClosedEventArgs e) {
      
      Environment.Exit(0);
    }
  }
}
