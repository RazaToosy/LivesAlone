using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using F23.StringSimilarity;

namespace LivesAlone
{
    public class LogicController
    {
        public bool CheckIfAlone(PatientDataModel patientData, List<PatientModel> PatientsOverEighteenInSamePostCode)
        {
            var patientDataAddress = $"{patientData.HouseNameFlatNumber} {patientData.NumberAndStreet}";

            var patientName = patientData.FamilyName;


            foreach (var patient in PatientsOverEighteenInSamePostCode)
            {
                if (patientData.EMISNumber + patientData.OrganisationCode == patient.EMISNumber + patient.OrganisationCode) continue;

                var patientAddress = $"{patient.HouseNameFlatNumber} {patient.NumberAndStreet}";

                if (patientAddress == patientDataAddress) return false;

                if (IsAddressesSimilar(patientDataAddress, patientAddress)) return false;
            }         
         
            return true;
        }

        public bool CheckIfChildInTheHouse(PatientDataModel patientData, List<PatientModel> PatientsUnderEighteenInSamePostCode)
        {
            return true;
        }

        private bool IsAddressesSimilar(string patientaddress, string addressesInRepo)
        {
            Levenshtein levenshtein = new Levenshtein();
            double similarity = levenshtein.Distance(patientaddress, addressesInRepo);

            if (similarity > 0.8) return false;

            return true;
        }

    }
}
