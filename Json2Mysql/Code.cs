using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json2Mysql {
  internal class Code {
    internal FormMain MainForm;
    internal JArray dataSource;
    internal List<string> columns;
    internal List<List<JToken>> rows;

    internal string JsonToMysql(string TableName, CheckedListBox checkedListBoxColumns) {
      //columns data follow checked list box column
      columns = new List<string>();
      List<string> columnsRemove = new List<string>();
      for (int i = 0; i < checkedListBoxColumns.Items.Count; i++) {
        bool isChecked = checkedListBoxColumns.GetItemChecked(i);
        if (isChecked)
          columns.Add(checkedListBoxColumns.Items[i].ToString());
        else
          columnsRemove.Add(checkedListBoxColumns.Items[i].ToString());
      }

      //data follow checked list box column
      JArray data = dataSource.DeepClone() as JArray;
      RemoveKeysFromJArray(data, columnsRemove);
      rows = GetAllValuesListFromJArray(data);

      StringBuilder stringSql = new StringBuilder();
      //Create table
      if (MainForm.checkBoxCreateTable.Checked) {
        stringSql.Append(CreateTableSQL(TableName, data));
      }
      //Insert data
      stringSql.Append(InsertDataSQL(TableName));
      return stringSql.ToString();
    }

    internal static string CreateTableSQL(string TableName, JArray data) {
      List<string> strings = new List<string>();
      List<KeyValuePair<string, JToken>> keyValuePairs = GetAllKeyValuePairs(data.First as JObject);
      foreach (KeyValuePair<string, JToken> keyValuePair in keyValuePairs) {
        strings.Add($"\t`{keyValuePair.Key}` {ToMySqlType(keyValuePair.Value.Type)}");
      }
      string stringSql = $"CREATE TABLE `{TableName}` (\n"
          + string.Join(",\n", strings)
          + "\n);\n\n";
      return stringSql;
    }

    internal string InsertDataSQL(string TableName, bool InsertIgnore = true)  {
      StringBuilder stringSql = new StringBuilder();
      //Insert ignore
      if (InsertIgnore) {
        stringSql.Append($"INSERT IGNORE INTO `{TableName}` (");
      } else {
        stringSql.Append($"INSERT INTO `{TableName}` (");
      }

      List<string> listStrColumns = new List<string>();
      foreach (string column in columns) {
        listStrColumns.Add($"`{column}`");
      }
      stringSql.Append(string.Join(", ", listStrColumns));
      stringSql.Append(")").Append(" VALUES ");

      List<string> listStrRows = new List<string>();
      foreach (List<JToken> row in rows) {
        List<string> listStrRow = new List<string>();
        foreach (JToken jToken in row) {
          if (jToken.Type == JTokenType.String) {
            listStrRow.Add($"'{jToken}'");
          } else if (jToken.Type == JTokenType.Array || jToken.Type == JTokenType.Object) {
            listStrRow.Add($"'{jToken.ToString(Formatting.None)}'");
          } else {
            listStrRow.Add(jToken.ToString(Formatting.None));
          }
        }
        listStrRows.Add("\n(" + string.Join(", ", listStrRow) + ")");
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

    internal static List<List<JToken>> GetAllValuesListFromJArray(JArray jsonArray) {
      List<List<JToken>> allValuesList = new List<List<JToken>>();

      foreach (JObject obj in jsonArray.Children<JObject>()) {
        List<JToken> values = new List<JToken>();

        foreach (JProperty property in obj.Properties()) {
          values.Add(property.Value);
        }

        allValuesList.Add(values);
      }

      return allValuesList;
    }

    internal static List<string> GetKeys(JArray jsonArray) {
      List<string> keys = new List<string>();

      foreach (JObject currObject in jsonArray) {
        foreach (JProperty property in currObject.Properties()) {
          if (!keys.Contains(property.Name)) {
            keys.Add(property.Name);
          }
        }
      }

      /* This is the original code - la
       

      //if (jsonArray.Count > 0 && jsonArray.First is JObject firstObject) {
      //  foreach (JProperty property in firstObject.Properties()) {
      //    keys.Add(property.Name);
      //  }
      //} */

      return keys;
    }

    internal static List<KeyValuePair<string, JToken>> GetAllKeyValuePairs(JObject jsonObject) {
      List<KeyValuePair<string, JToken>> keyValuePairs = new List<KeyValuePair<string, JToken>>();

      foreach (JProperty property in jsonObject.Properties()) {
        keyValuePairs.Add(new KeyValuePair<string, JToken>(property.Name, property.Value));
      }

      return keyValuePairs;
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
      List<string> columns = GetKeys(dataSource);
      MainForm.checkedListBoxColumns.Items.AddRange(columns.ToArray());
      for (int i = 0; i < columns.Count; i++) {
        MainForm.checkedListBoxColumns.SetItemChecked(i, true);
      }
    }

  }
}
