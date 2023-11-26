using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace Data
{
    public class Repo
    {
        // Your in-memory repository
        List<PatientDataModel> _datarepository = new List<PatientDataModel>();
        //List<PatientModel> _patientsOverEighteen = new List<PatientModel>();
        //List<PatientModel> _patientsUnderEighteen = new List<PatientModel>();
        Dictionary<string, List<PatientModel>> _patientsOverEighteenByPostCode = new Dictionary<string, List<PatientModel>>();
        Dictionary<string, List<PatientModel>> _patientsUnderEighteenByPostCode = new Dictionary<string, List<PatientModel>>();

        public List<PatientDataModel> DataRepository => _datarepository;
        //public List<PatientModel> PatientsOverEighteen => _patientsOverEighteen;
        //public List<PatientModel> PatientsUnderEighteen => _patientsUnderEighteen;
        public Dictionary<string, List<PatientModel>> PatientsOverEighteenByPostCode => _patientsOverEighteenByPostCode;
        public Dictionary<string, List<PatientModel>> PatientsUnderEighteenByPostCode => _patientsUnderEighteenByPostCode;

        public Repo(string LocationOfFiles)
        {
            string directoryPath = LocationOfFiles;
            string filename = string.Empty;

            List<PatientModel> patients = new List<PatientModel>();

            foreach (var filePath in Directory.EnumerateFiles(directoryPath, "*.csv"))
            {
                filename = Path.GetFileNameWithoutExtension(filePath);
                if (Path.GetFileName(filePath).StartsWith("Patient")) 
                    patients = getDataFromFiles<PatientModel>(filePath);
                else getDataFromFiles<PatientDataModel>(filePath);

                if (filename == "PatientsOver18")
                    _patientsOverEighteenByPostCode = patients
                        .GroupBy(p => p.Postcode)
                        .ToDictionary(g => g.Key, g => g.ToList());

                if (filename == "PatientsUnder18")
                    _patientsUnderEighteenByPostCode = patients
                        .GroupBy(p => p.Postcode)
                        .ToDictionary(g => g.Key, g => g.ToList());
            }

        }

        private List<T> getDataFromFiles<T>(string filepath) where T : class, IPatientData, new()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Configure as necessary for your CSV format
            };
            List<T> results = new List<T>();

            Type type = typeof(T);

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, config))
            {

                if (type == typeof(PatientModel))
                {
                    csv.Context.RegisterClassMap<PatientMap>();
                    var records = csv.GetRecords<PatientModel>();
                    foreach (var record in records)
                    {
                        record.PatientType = Path.GetFileNameWithoutExtension(filepath);
                        results.Add(record as T);
                    }
                }

                if (type == typeof(PatientDataModel))
                {
                    csv.Context.RegisterClassMap<PatientDataMap>();
                    var records = csv.GetRecords<PatientDataModel>();
                    foreach (var record in records)
                    {
                        record.PatientType = Path.GetFileNameWithoutExtension(filepath);
                        _datarepository.Add(record);
                    }
                }
            }

            return results;
        }
    }
}
