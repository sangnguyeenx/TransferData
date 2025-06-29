using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
    public class ColumnMapping
    {
        public string SourceColumn { get; set; }
        public string TargetColumn { get; set; }
        public string DataType { get; set; }
        public bool IsEnabled { get; set; }

        public ColumnMapping()
        {
            IsEnabled = true;
        }

        public ColumnMapping(string sourceColumn, string targetColumn, string dataType = "")
        {
            SourceColumn = sourceColumn;
            TargetColumn = targetColumn;
            DataType = dataType;
            IsEnabled = true;
        }
    }

    public class DatabaseInfo
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public List<string> Columns { get; set; }

        public DatabaseInfo()
        {
            Columns = new List<string>();
        }
    }

    public class FixedColumnMapping
    {
        public string ColumnName { get; set; }
        public string FixedValue { get; set; }
        public bool IsEnabled { get; set; }
        public string DataType { get; set; }

        public FixedColumnMapping()
        {
            IsEnabled = false;
        }

        public FixedColumnMapping(string columnName, string fixedValue, string dataType = "")
        {
            ColumnName = columnName;
            FixedValue = fixedValue;
            DataType = dataType;
            IsEnabled = false;
        }
    }

    public class MappingConfiguration
    {
        public DatabaseInfo SourceDatabase { get; set; }
        public DatabaseInfo TargetDatabase { get; set; }
        public List<ColumnMapping> ColumnMappings { get; set; }
        public List<FixedColumnMapping> FixedColumnMappings { get; set; }
        public string ConfigurationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

        public MappingConfiguration()
        {
            SourceDatabase = new DatabaseInfo();
            TargetDatabase = new DatabaseInfo();
            ColumnMappings = new List<ColumnMapping>();
            FixedColumnMappings = new List<FixedColumnMapping>();
            CreatedDate = DateTime.Now;
            LastModified = DateTime.Now;
        }
    }
}
