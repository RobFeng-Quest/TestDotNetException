using Microsoft.Office.Interop.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace ATCM.AccessInterop
{
    public class AccessExporter
    {
        /// <summary>
        /// Export the access to xml.
        /// </summary>
        /// <param name="aAccessFilePath"></param>
        /// <param name="aExportFilePath"></param>
        /// <remarks>
        /// Will get exception "Microsoft Access can't save the output data to the file you've selected."
        /// when the path not exist.
        /// </remarks>
        public void Export(string aAccessFilePath, string aExportFilePath)
        {
            var tables = GetTableNames(aAccessFilePath);

            var acApp = new ApplicationClass();
            acApp.OpenCurrentDatabase(aAccessFilePath, false, null);
            try
            {
                foreach (var table in tables)
                {
                    var dataTargetPath = Path.Combine(aExportFilePath, table + AccessConstants.ExportTableFileExtension);
                    var schemaTargetPath = Path.Combine(aExportFilePath, table + AccessConstants.ExportSchemaFileExtension);
                    acApp.ExportXML(
                        ObjectType: AcExportXMLObjectType.acExportTable,
                        DataSource: table,
                        DataTarget: dataTargetPath,
                        SchemaTarget: schemaTargetPath,
                        Encoding: AcExportXMLEncoding.acUTF8);
                }
            }
            finally
            {
                acApp.CloseCurrentDatabase();
            }
        }

        private IEnumerable<string> GetTableNames(string aAccessFilePath)
        {
            var tableNames = new List<string>();

            var connectionString = $"Provider={AccessConstants.ConnectionProviderJet};Data source={aAccessFilePath}";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var tables = connection.GetSchema("tables");
                foreach (DataRow dataRow in tables.Rows)
                {
                    var tableType = dataRow["TABLE_TYPE"].ToString();
                    if (tableType == "TABLE")
                    {
                        tableNames.Add(dataRow["TABLE_NAME"].ToString());
                    }
                }
                connection.Close();
            }

            return tableNames;
        }
    }
}
