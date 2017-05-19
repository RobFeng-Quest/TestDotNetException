using Microsoft.Office.Interop.Access;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ATCM.AccessInterop
{
    public class AccessImporter
    {
        /// <summary>
        /// Import the xml to access.
        /// </summary>
        /// <param name="aAccessFilePath"></param>
        /// <param name="aExportedFilePath"></param>
        /// <remarks>
        /// Will get exception "Microsoft Access can't save the output data to the file you've selected."
        /// when the path not exist.
        /// </remarks>
        public void Import(string aAccessFilePath, string aExportedFilePath)
        {
            var tables = GetTableNames(aExportedFilePath);

            var acApp = new ApplicationClass();
            acApp.OpenCurrentDatabase(aAccessFilePath, false, null);
            try
            {
                foreach (var table in tables)
                {
                    var dataTargetPath = Path.Combine(aExportedFilePath, table + AccessConstants.ExportTableFileExtension);
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

        private IEnumerable<string> GetTableNames(string aExportedFilePath)
        {
            var allTableFiles = Directory.EnumerateFiles(aExportedFilePath, $"*{AccessConstants.ExportTableFileExtension}", SearchOption.TopDirectoryOnly);

            return allTableFiles.Select(t => Path.GetFileNameWithoutExtension(t)).ToArray();
        }
    }
}
