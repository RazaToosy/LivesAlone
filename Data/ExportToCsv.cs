using Core.Models;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ExportToCsv
    {
        public  ExportToCsv(List<PatientDataModel> data, string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Configure as necessary for your CSV format
            };

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, config))
            {
                // If you're using a ClassMap
                //csv.Context.RegisterClassMap<PatientDataMap>();

                csv.WriteRecords(data);
            }
        }
    }
}
