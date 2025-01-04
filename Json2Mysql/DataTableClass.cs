using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToMysql {
  internal class DataTableClass {
    internal List<string> ColumnHeaders = new List<string>();
    internal List<string> ColumnType = new List<string>();
    internal List<DataRow> DataRows = new List<DataRow>();
    internal class DataRow {
      internal List<DataValue> DataColumns = new List<DataValue>();
    }
    internal struct DataValue {
      internal string Key;
      internal string Value;
    }
  }
}
