using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;

namespace LivesAlone
{
    public class DataProcessor
    {
        public List<PatientDataModel> ReturnAlonePatients(Repo repo)
        {
            List<PatientDataModel> alonePatients = new List<PatientDataModel>();

            var patientDataByType =repo.DataRepository
                .GroupBy(p => p.PatientType)
                .ToDictionary(g => g.Key, g => g.ToList());

            var aloneController = new LogicController();

            foreach (var patientType in patientDataByType)
            {
                var patientData = patientDataByType[patientType.Key];

                foreach (var patient in patientData)
                {
                    switch (patientType.Key)
                    {
                        case "Dementia":
                            if (aloneController.CheckIfAlone(patient, repo.PatientsOverEighteenByPostCode[patient.Postcode]))
                                alonePatients.Add(patient);
                            var spouseDetails = aloneController.GetSpouseDetails(patient, repo.PatientsOverEighteenByPostCode[patient.Postcode]);
                            if (spouseDetails != null) alonePatients.Add(spouseDetails);
                            break;
                        case "Female20to35":
                            if (!repo.PatientsUnderEighteenByPostCode.ContainsKey(patient.Postcode)) break;
                            if (aloneController.IsSingleMother(patient, repo.PatientsUnderEighteenByPostCode[patient.Postcode], repo.PatientsOverEighteenByPostCode[patient.Postcode]))
                                alonePatients.Add(patient);
                            break;
                        default:
                            if (aloneController.CheckIfAlone(patient, repo.PatientsOverEighteenByPostCode[patient.Postcode]))
                                alonePatients.Add(patient);
                            break;
                    }                    
                }
            }

            return alonePatients;
        }
    }
}
