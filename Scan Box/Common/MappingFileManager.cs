using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scan_Box.Common
{
    public class MappingFileManager
    {
        private const string MAPPING_FOLDER = "ColumnMappings";
        private const string FILE_EXTENSION = ".txt";

        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return "DefaultConfig";

            // Remove invalid characters for file names
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string sanitized = fileName;

            foreach (char c in invalidChars)
            {
                sanitized = sanitized.Replace(c, '_');
            }

            // Also replace some additional problematic characters
            sanitized = sanitized.Replace(':', '_')
                                .Replace('*', '_')
                                .Replace('?', '_')
                                .Replace('"', '_')
                                .Replace('<', '_')
                                .Replace('>', '_')
                                .Replace('|', '_');

            // Trim whitespace and dots from the end
            sanitized = sanitized.Trim().TrimEnd('.');

            // Ensure the name is not empty after sanitization
            if (string.IsNullOrWhiteSpace(sanitized))
                sanitized = "DefaultConfig";

            return sanitized;
        }

        public static void EnsureMappingFolderExists()
        {
            string folderPath = Path.Combine(Application.StartupPath, MAPPING_FOLDER);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void SaveMappingToFile(MappingConfiguration config, string fileName)
        {
            try
            {
                EnsureMappingFolderExists();
                string sanitizedFileName = SanitizeFileName(fileName);
                string filePath = Path.Combine(Application.StartupPath, MAPPING_FOLDER, sanitizedFileName + FILE_EXTENSION);

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Write header information
                    writer.WriteLine($"# Column Mapping Configuration");
                    writer.WriteLine($"# Configuration Name: {config.ConfigurationName}");
                    writer.WriteLine($"# Created: {config.CreatedDate:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine($"# Last Modified: {config.LastModified:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();

                    // Write source database info
                    writer.WriteLine("[SOURCE_DATABASE]");
                    writer.WriteLine($"ConnectionString={config.SourceDatabase.ConnectionString}");
                    writer.WriteLine($"DatabaseName={config.SourceDatabase.DatabaseName}");
                    writer.WriteLine($"TableName={config.SourceDatabase.TableName}");
                    writer.WriteLine();

                    // Write target database info
                    writer.WriteLine("[TARGET_DATABASE]");
                    writer.WriteLine($"ConnectionString={config.TargetDatabase.ConnectionString}");
                    writer.WriteLine($"DatabaseName={config.TargetDatabase.DatabaseName}");
                    writer.WriteLine($"TableName={config.TargetDatabase.TableName}");
                    writer.WriteLine();

                    // Write column mappings
                    writer.WriteLine("[COLUMN_MAPPINGS]");
                    foreach (var mapping in config.ColumnMappings)
                    {
                        if (mapping.IsEnabled && !string.IsNullOrEmpty(mapping.SourceColumn) && !string.IsNullOrEmpty(mapping.TargetColumn))
                        {
                            writer.WriteLine($"{mapping.SourceColumn}={mapping.TargetColumn}|{mapping.DataType}|{mapping.IsEnabled}");
                        }
                    }

                    // Write fixed column mappings
                    writer.WriteLine();
                    writer.WriteLine("[FIXED_COLUMN_MAPPINGS]");
                    foreach (var fixedMapping in config.FixedColumnMappings)
                    {
                        if (!string.IsNullOrEmpty(fixedMapping.ColumnName))
                        {
                            writer.WriteLine($"{fixedMapping.ColumnName}={fixedMapping.FixedValue}|{fixedMapping.DataType}|{fixedMapping.IsEnabled}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu file ánh xạ: {ex.Message}");
            }
        }

        public static MappingConfiguration LoadMappingFromFile(string fileName)
        {
            try
            {
                string sanitizedFileName = SanitizeFileName(fileName);
                string filePath = Path.Combine(Application.StartupPath, MAPPING_FOLDER, sanitizedFileName + FILE_EXTENSION);
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file ánh xạ: {fileName}");
                }

                MappingConfiguration config = new MappingConfiguration();
                string currentSection = "";

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        
                        // Skip comments and empty lines
                        if (line.StartsWith("#") || string.IsNullOrEmpty(line))
                            continue;

                        // Check for section headers
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            currentSection = line.Substring(1, line.Length - 2);
                            continue;
                        }

                        // Parse key-value pairs
                        if (line.Contains("="))
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length >= 2)
                            {
                                string key = parts[0].Trim();
                                string value = string.Join("=", parts.Skip(1)).Trim();

                                switch (currentSection)
                                {
                                    case "SOURCE_DATABASE":
                                        ParseDatabaseInfo(config.SourceDatabase, key, value);
                                        break;
                                    case "TARGET_DATABASE":
                                        ParseDatabaseInfo(config.TargetDatabase, key, value);
                                        break;
                                    case "COLUMN_MAPPINGS":
                                        ParseColumnMapping(config.ColumnMappings, key, value);
                                        break;
                                    case "FIXED_COLUMN_MAPPINGS":
                                        ParseFixedColumnMapping(config.FixedColumnMappings, key, value);
                                        break;
                                }
                            }
                        }
                    }
                }

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải file ánh xạ: {ex.Message}");
            }
        }

        public static MappingConfiguration LoadMappingFromFullPath(string fullFilePath)
        {
            try
            {
                if (!File.Exists(fullFilePath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file: {fullFilePath}");
                }

                MappingConfiguration config = new MappingConfiguration();
                string currentSection = "";

                using (StreamReader reader = new StreamReader(fullFilePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

                        // Skip comments and empty lines
                        if (line.StartsWith("#") || string.IsNullOrEmpty(line))
                            continue;

                        // Check for section headers
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            currentSection = line.Substring(1, line.Length - 2);
                            continue;
                        }

                        // Parse key-value pairs
                        if (line.Contains("="))
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length >= 2)
                            {
                                string key = parts[0].Trim();
                                string value = string.Join("=", parts.Skip(1)).Trim();

                                switch (currentSection)
                                {
                                    case "SOURCE_DATABASE":
                                        ParseDatabaseInfo(config.SourceDatabase, key, value);
                                        break;
                                    case "TARGET_DATABASE":
                                        ParseDatabaseInfo(config.TargetDatabase, key, value);
                                        break;
                                    case "COLUMN_MAPPINGS":
                                        ParseColumnMapping(config.ColumnMappings, key, value);
                                        break;
                                    case "FIXED_COLUMN_MAPPINGS":
                                        ParseFixedColumnMapping(config.FixedColumnMappings, key, value);
                                        break;
                                }
                            }
                        }
                    }
                }

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải file ánh xạ: {ex.Message}");
            }
        }

        private static void ParseDatabaseInfo(DatabaseInfo dbInfo, string key, string value)
        {
            switch (key)
            {
                case "ConnectionString":
                    dbInfo.ConnectionString = value;
                    break;
                case "DatabaseName":
                    dbInfo.DatabaseName = value;
                    break;
                case "TableName":
                    dbInfo.TableName = value;
                    break;
            }
        }

        private static void ParseColumnMapping(List<ColumnMapping> mappings, string sourceColumn, string value)
        {
            string[] parts = value.Split('|');
            if (parts.Length >= 1)
            {
                ColumnMapping mapping = new ColumnMapping
                {
                    SourceColumn = sourceColumn,
                    TargetColumn = parts[0],
                    DataType = parts.Length > 1 ? parts[1] : "",
                    IsEnabled = parts.Length > 2 ? bool.Parse(parts[2]) : true
                };
                mappings.Add(mapping);
            }
        }

        private static void ParseFixedColumnMapping(List<FixedColumnMapping> mappings, string columnName, string value)
        {
            string[] parts = value.Split('|');
            if (parts.Length >= 1)
            {
                FixedColumnMapping mapping = new FixedColumnMapping
                {
                    ColumnName = columnName,
                    FixedValue = parts[0],
                    DataType = parts.Length > 1 ? parts[1] : "",
                    IsEnabled = parts.Length > 2 ? bool.Parse(parts[2]) : false
                };
                mappings.Add(mapping);
            }
        }

        public static List<string> GetAvailableMappingFiles()
        {
            List<string> files = new List<string>();
            try
            {
                EnsureMappingFolderExists();
                string folderPath = Path.Combine(Application.StartupPath, MAPPING_FOLDER);
                
                foreach (string filePath in Directory.GetFiles(folderPath, "*" + FILE_EXTENSION))
                {
                    files.Add(Path.GetFileNameWithoutExtension(filePath));
                }
            }
            catch (Exception)
            {
                // Return empty list if error occurs
            }
            return files;
        }

        public static void DeleteMappingFile(string fileName)
        {
            try
            {
                string sanitizedFileName = SanitizeFileName(fileName);
                string filePath = Path.Combine(Application.StartupPath, MAPPING_FOLDER, sanitizedFileName + FILE_EXTENSION);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa file ánh xạ: {ex.Message}");
            }
        }
    }
}
