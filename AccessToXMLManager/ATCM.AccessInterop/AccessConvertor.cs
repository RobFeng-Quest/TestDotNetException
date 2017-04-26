using Microsoft.Office.Interop.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ATCM.AccessInterop
{
    public class AccessConvertor
    {
        /// <summary>
        /// Will get exception "Microsoft Access can't save the output data to the file you've selected."
        /// when the path not exist.
        /// </summary>
        private const string XMLPath = @"G:\Work\TestDotNetException\ExportedXML";
        private const string EmptyDataAccessPath = @"C:\Users\rfeng\Desktop\Access to XML\ATCMDB-Empty.mdb";
        private const string FullDataAccessPath = @"C:\Users\rfeng\Desktop\Access to XML\ATCM-All.mdb";

        public void ExportXMLExample()
        {
            try
            {
                IEnumerable<string> tableNames = null;
                using (var bench = new Benchmark($"Get all table name:"))
                {
                    tableNames = TestGetAllTableName();
                }

                using (var bench = new Benchmark($"Export access to xml:"))
                {
                    TestExportXML(tableNames);
                }

                //using (var bench = new Benchmark($"Import xml to access:"))
                //{
                //    TestImportXML(tableNames);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to do that.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("---------------------");
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public void ImportXMLExample()
        {
            try
            {
                IEnumerable<string> tableNames = null;
                using (var bench = new Benchmark($"Get all table name:"))
                {
                    tableNames = TestGetAllTableName();
                }

                using (var bench = new Benchmark($"Import xml to access:"))
                {
                    TestImportXML(tableNames);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to do that.");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("---------------------");
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void TestImportXML(IEnumerable<string> aTables)
        {
            // https://msdn.microsoft.com/en-us/library/office/ff823157(v=office.14).aspx
            var acApp = new Microsoft.Office.Interop.Access.ApplicationClass();
            acApp.OpenCurrentDatabase(EmptyDataAccessPath, false, null);
            try
            {
                foreach (var table in aTables)
                {
                    var dataTargetPath = Path.Combine(XMLPath, table + ".xml");
                    acApp.ImportXML(
                        DataSource: dataTargetPath,
                        ImportOptions: AcImportXMLOption.acStructureAndData);
                }
            }
            finally
            {
                acApp.CloseCurrentDatabase();
            }
        }

        private void TestExportXML(IEnumerable<string> aTables)
        {
            // https://msdn.microsoft.com/en-us/library/office/ff193212(v=office.14).aspx
            var acApp = new Microsoft.Office.Interop.Access.ApplicationClass();
            acApp.OpenCurrentDatabase(FullDataAccessPath, false, null);
            try
            {
                foreach (var table in aTables)
                {
                    var dataTargetPath = Path.Combine(XMLPath, table + ".xml");
                    var schemaTargetPath = Path.Combine(XMLPath, table + ".xsd");
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

        private IEnumerable<string> TestGetAllTableName()
        {
            var tableNames = new List<string>();

            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + FullDataAccessPath;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var tables = connection.GetSchema("tables");
                    foreach (DataRow table in tables.Rows)
                    {
                        var tableType = table["TABLE_TYPE"].ToString();
                        if (tableType == "TABLE")
                        {
                            tableNames.Add(table["TABLE_NAME"].ToString());
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("Failed to connect to data source: " + ex.Message);
            }

            return tableNames;
        }

        private void TestGetAllTables()
        {

            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data source=C:\Users\rfeng\Desktop\Access to XML\ATCM-All.mdb";


            // var myTable = DataAccess.GetTableFromQuery("SELECT * FROM TableName", null, CommandType.Text)

            string queryString = "SELECT * FROM MSysObjects WHERE Type=1 AND Flags=0";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var tables = connection.GetSchema("tables");
                    foreach (DataRow table in tables.Rows)
                    {
                        var tableType = table["TABLE_TYPE"].ToString();
                        if (tableType == "TABLE")
                        {
                            queryString = "SELECT count(*) FROM [" + table["TABLE_NAME"] + "]";
                            using (OleDbCommand command = new OleDbCommand(queryString, connection))
                            {
                                try
                                {
                                    OleDbDataReader reader = command.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        Debug.WriteLine(reader[0].ToString() + " - " + queryString);
                                    }
                                    reader.Close();
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("ExecuteReader error: " + ex.Message + " " + queryString);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("Failed to connect to data source");
            }
        }
    }
}