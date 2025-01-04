using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JsonToMysql.DataTableClass;

namespace JsonToMysql {

  internal class Code {

    internal FormMain MainForm;
    internal JArray dataSource;
    internal List<List<JToken>> rows;
    internal DataTableClass DataTable = new DataTableClass();
    internal List<string> listStrRows;

    internal string JsonToMysql(string TableName, CheckedListBox checkedListBoxColumns) {
      //columns data follow checked list box column
      DataTable.ColumnHeaders = new List<string>();
      List<string> columnsRemove = new List<string>();
      for (int i = 0; i < checkedListBoxColumns.Items.Count; i++) {
        bool isChecked = checkedListBoxColumns.GetItemChecked(i);
        if (isChecked)
          DataTable.ColumnHeaders.Add(checkedListBoxColumns.Items[i].ToString());
        else
          columnsRemove.Add(checkedListBoxColumns.Items[i].ToString());
      }

      //data follow checked list box column
      JArray data = dataSource.DeepClone() as JArray;
      RemoveKeysFromJArray(data, columnsRemove);

      StringBuilder stringSql = new StringBuilder();
      //Create table
      if (MainForm.checkBoxCreateTable.Checked) {
        stringSql.Append(CreateTableSQL(TableName, data));
      }
      //Insert data
      stringSql.Append(InsertDataSQL(TableName));
      return stringSql.ToString();
    }

    internal string CreateTableSQL(string TableName, JArray data) {
      List<string> strings = new List<string>();
      for(int i = 0; i < DataTable.ColumnHeaders.Count; i++) {
        strings.Add($"\t`{DataTable.ColumnHeaders[i]}` {DataTable.ColumnType[i]}");
      }
      string stringSql = $"CREATE TABLE `{TableName}` (\n"
          + string.Join(",\n", strings)
          + "\n);\n\n";
      return stringSql;
    }

    internal string InsertDataSQL(string TableName, bool InsertIgnore = true) {
      StringBuilder stringSql = new StringBuilder();
      //Insert ignore
      if (InsertIgnore) {
        stringSql.Append($"INSERT IGNORE INTO `{TableName}` (");
      } else {
        stringSql.Append($"INSERT INTO `{TableName}` (");
      }

      stringSql.Append(string.Join(", ", DataTable.ColumnHeaders));
      stringSql.Append(")").Append(" VALUES ");

      listStrRows = new List<string>();

      foreach (DataTableClass.DataRow currRow in DataTable.DataRows) {
        List<string> listStrRow = new List<string>();
        foreach (string column in DataTable.ColumnHeaders) {
          var result = from x in currRow.DataColumns
                       where x.Key == column
                       select x.Value;
          if (result.Count() == 0) {
            listStrRow.Add("");
          } else {
            listStrRow.Add(result.First());
          }
        }
        listStrRows.Add("\n('" + string.Join("', '", listStrRow) + "')");
      }
      stringSql.Append(string.Join(",", listStrRows));
      stringSql.Append(";");
      return stringSql.ToString();
    }

    internal static string ToMySqlType(JTokenType type) {
      switch (type) {
        case JTokenType.Integer:
          return "INT";
        case JTokenType.Float:
          return "DOUBLE";
        default:
          return "TEXT";
      }
    }

    internal void GetTableData(JArray jsonArray) {
      DataTable.ColumnHeaders = new List<string>();
      DataTable.ColumnType = new List<string>();

      foreach (JObject currObject in jsonArray) {
        DataTableClass.DataRow currRow = new DataTableClass.DataRow();
        foreach (JProperty property in currObject.Properties()) {
          if (!DataTable.ColumnHeaders.Contains(property.Name)) {
            DataTable.ColumnHeaders.Add(property.Name);
            DataTable.ColumnType.Add(ToMySqlType(property.First.Type));
          }
          DataValue currData = new DataValue();
          currData.Key = property.Name;
          currData.Value = property.Value.ToString();
          currRow.DataColumns.Add(currData);
        }
        DataTable.DataRows.Add(currRow);
      }
    }

    internal static void RemoveKeysFromJArray(JArray jsonArray, List<string> keysToRemove) {
      if (keysToRemove.Count == 0)
        return;
      foreach (JObject obj in jsonArray.Children<JObject>()) {
        foreach (string key in keysToRemove) {
          JProperty propertyToRemove = obj.Property(key);
          propertyToRemove?.Remove();
        }
      }
    }


    internal void InitializeDataSource() {
      if (dataSource != null)
        dataSource.Clear();
      try {
        dataSource = JArray.Parse(MainForm.richTextBoxJSON.Text);
      } catch (Exception ex) {
        MessageBox.Show("Can't deserialize json, please check again. " + ex.Message);
        return;
      }
    }

    internal void InitializeCheckedListBox() {
      if (dataSource == null || dataSource.Count == 0) {
        return;
      }
      MainForm.checkedListBoxColumns.Items.Clear();
      GetTableData(dataSource);
      MainForm.checkedListBoxColumns.Items.AddRange(DataTable.ColumnHeaders.ToArray());
      for (int i = 0; i < DataTable.ColumnHeaders.Count; i++) {
        MainForm.checkedListBoxColumns.SetItemChecked(i, true);
      }
    }

  }
}
