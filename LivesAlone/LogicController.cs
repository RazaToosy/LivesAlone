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

            foreach (var patient in PatientsOverEighteenInSamePostCode)
            {
                if (patientData.EMISNumber + patientData.OrganisationCode == patient.EMISNumber + patient.OrganisationCode) continue;

                var patientAddress = $"{patient.HouseNameFlatNumber} {patient.NumberAndStreet}";

                if (patientAddress == patientDataAddress) return false;

                if (IsAddressesSimilar(patientDataAddress, patientAddress)) return false;
            }         
         
            return true;
        }

        public bool IsSingleMother(PatientDataModel patientData, List<PatientModel> PatientsUnderEighteenInSamePostCode, List<PatientModel> PatientsOverEighteenInSamePostCode)
        {
            var isAlone = CheckIfAlone(patientData, PatientsOverEighteenInSamePostCode);

            if (isAlone)
            {
                var patientDataAddress = $"{patientData.HouseNameFlatNumber} {patientData.NumberAndStreet}";
                var patientCount = 0;

                foreach (var patient in PatientsUnderEighteenInSamePostCode)
                {
                    if (patientData.EMISNumber + patientData.OrganisationCode == patient.EMISNumber + patient.OrganisationCode) continue;

                    var patientAddress = $"{patient.HouseNameFlatNumber} {patient.NumberAndStreet}";

                    if (patientAddress == patientDataAddress || IsAddressesSimilar(patientDataAddress, patientAddress))
                    {
                        patientCount++;
                    }
                }

                if (patientCount >= 1) return true;
            }

            return false;
        }

        public PatientDataModel GetSpouseDetails(PatientDataModel patientData, List<PatientModel> PatientsOverEighteenInSamePostCode)
        {
            var patientDataAddress = $"{patientData.HouseNameFlatNumber} {patientData.NumberAndStreet}";
            var patientCount = 0;
            var spouseDetails = new PatientModel();

            foreach (var patient in PatientsOverEighteenInSamePostCode)
            {
                if (patientData.EMISNumber + patientData.OrganisationCode == patient.EMISNumber + patient.OrganisationCode) continue;

                var patientAddress = $"{patient.HouseNameFlatNumber} {patient.NumberAndStreet}";

                if (patientAddress == patientDataAddress || IsAddressesSimilar(patientDataAddress, patientAddress))
                {
                    patientCount++;
                    spouseDetails = patient;
                }
            }

            if (patientCount == 1) return new PatientDataModel
            {
                PatientType ="DementiaCohabiting",
                EMISNumber = spouseDetails.EMISNumber,
                OrganisationCode = spouseDetails.OrganisationCode, 
                NHSNumber = spouseDetails.NHSNumber,
                GivenName = spouseDetails.GivenName,
                FamilyName = spouseDetails.FamilyName,
                DateOfBirth = spouseDetails.DateOfBirth,
                Age = spouseDetails.Age,
                Gender = spouseDetails.Gender,
                HouseNameFlatNumber = spouseDetails.HouseNameFlatNumber,
                NumberAndStreet = spouseDetails.NumberAndStreet,
                Locality = spouseDetails.Locality,
                Town = spouseDetails.Town,
                County = spouseDetails.County,
                Postcode = spouseDetails.Postcode,
                UsualGPsFullName = spouseDetails.UsualGPsFullName,
                MaritalStatus = spouseDetails.MaritalStatus,
                EthnicOrigin = spouseDetails.EthnicOrigin
            };

            return null;
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
