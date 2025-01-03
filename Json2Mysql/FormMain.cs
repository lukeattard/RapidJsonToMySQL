using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Json2Mysql.Code;

namespace Json2Mysql {
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

    private void buttonConvert_Click(object sender, EventArgs e) {
      if (textBoxTableName.TextLength == 0 || richTextBoxJSON.TextLength == 0 || MyCode.dataSource == null || MyCode.dataSource.Count == 0) {
        MessageBox.Show("Please input table name and paste JSON text.");
        return;
      }
      string sql = MyCode.JsonToMysql(textBoxTableName.Text, checkedListBoxColumns);

      richTextBoxResult.Clear();
      richTextBoxResult.Text = sql;
      label6.Text = "Rows count: " + MyCode.rows.Count;
      UpdateDataGridView();
    }


    internal string GetJSON() {
      return MainForm.richTextBoxJSON.Text.ToString();
    }
    void UpdateDataGridView() {
      dataGridViewData.Columns.Clear();
      dataGridViewData.Rows.Clear();
      foreach (string s in MyCode.columns) {
        dataGridViewData.Columns.Add(s, s);
      }

      foreach (List<JToken> row in MyCode.rows) {
        List<string> listValue = new List<string>();
        foreach (JToken jToken in row) {
          listValue.Add(jToken.ToString(Formatting.None));
        }
        dataGridViewData.Rows.Add(listValue.ToArray());
      }
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      MyCode.InitializeDataSource();
      MyCode.InitializeCheckedListBox();
    }

    //string CreateTableSQL(string TableName, JArray data) {
    //  List<string> strings = new List<string>();
    //  List<KeyValuePair<string, JToken>> keyValuePairs = GetAllKeyValuePairs(data.First as JObject);
    //  foreach (KeyValuePair<string, JToken> keyValuePair in keyValuePairs) {
    //    strings.Add($"\t`{keyValuePair.Key}` {ToMySqlType(keyValuePair.Value.Type)}");
    //  }
    //  string stringSql = $"CREATE TABLE `{TableName}` (\n"
    //      + string.Join(",\n", strings)
    //      + "\n);\n\n";
    //  return stringSql;
    //}

    //private void richTextBox1_TextChanged(object sender, EventArgs e) {
    //  MyCode.InitializeDataSource();
    //  MyCode.InitializeCheckedListBox();
    //}
    //string InsertDataSQL(string TableName) {
    //  StringBuilder stringSql = new StringBuilder();
    //  //Insert ignore
    //  if (checkBoxIgnore.Checked) {
    //    stringSql.Append($"INSERT IGNORE INTO `{TableName}` (");
    //  } else {
    //    stringSql.Append($"INSERT INTO `{TableName}` (");
    //  }

    //  List<string> listStrColumns = new List<string>();
    //  foreach (string column in MyCode.columns) {
    //    listStrColumns.Add($"`{column}`");
    //  }
    //  stringSql.Append(string.Join(", ", listStrColumns));
    //  stringSql.Append(")").Append(" VALUES ");

    //  List<string> listStrRows = new List<string>();
    //  foreach (List<JToken> row in MyCode.rows) {
    //    List<string> listStrRow = new List<string>();
    //    foreach (JToken jToken in row) {
    //      if (jToken.Type == JTokenType.String) {
    //        listStrRow.Add($"'{jToken}'");
    //      } else if (jToken.Type == JTokenType.Array || jToken.Type == JTokenType.Object) {
    //        listStrRow.Add($"'{jToken.ToString(Formatting.None)}'");
    //      } else {
    //        listStrRow.Add(jToken.ToString(Formatting.None));
    //      }
    //    }
    //    listStrRows.Add("\n(" + string.Join(", ", listStrRow) + ")");
    //  }
    //  stringSql.Append(string.Join(",", listStrRows));
    //  stringSql.Append(";");
    //  return stringSql.ToString();
    //}

    //string ToMySqlType(JTokenType type) {
    //  switch (type) {
    //    case JTokenType.Integer:
    //      return "INT";
    //    case JTokenType.Float:
    //      return "DOUBLE";
    //    default:
    //      return "TEXT";
    //  }
    //}



    //static List<string> GetKeys(JArray jsonArray) {
    //  List<string> keys = new List<string>();

    //  if (jsonArray.Count > 0 && jsonArray.First is JObject firstObject) {
    //    foreach (JProperty property in firstObject.Properties()) {
    //      keys.Add(property.Name);
    //    }
    //  }

    //  return keys;
    //}



    //static void RemoveKeysFromJArray(JArray jsonArray, List<string> keysToRemove) {
    //  if (keysToRemove.Count == 0)
    //    return;
    //  foreach (JObject obj in jsonArray.Children<JObject>()) {
    //    foreach (string key in keysToRemove) {
    //      JProperty propertyToRemove = obj.Property(key);
    //      propertyToRemove?.Remove();
    //    }
    //  }
    //}


  }
}
