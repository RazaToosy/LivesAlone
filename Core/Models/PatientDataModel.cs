using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Models
{
    public class PatientDataModel : IPatientData
    {
        public string PatientType { get; set; }
        public string EMISNumber { get; set; }
        public string OrganisationCode { get; set; }
        public string NHSNumber { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DateOfBirth { get; set; } // Assuming dates are in string format
        public string Age { get; set; } // Assuming age is in string format
        public string Gender { get; set; }
        public string HouseNameFlatNumber { get; set; }
        public string NumberAndStreet { get; set; }
        public string Locality { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string UsualGPsFullName { get; set; }
        public string MaritalStatus { get; set; }
        public string EthnicOrigin { get; set; }
        public string Date { get; set; } // Assuming dates are in string format
        public string CodeTerm { get; set; }
        public string Date1 { get; set; }
        public string CodeTerm1 { get; set; }
        public string Date2 { get; set; }
        public string CodeTerm2 { get; set; }
        public string NameDosageAndQuantity { get; set; }
        public string MostRecentIssueDateInCourse { get; set; }
        public string Date3 { get; set; }
        public string CodeTerm3 { get; set; }
        public string Date4 { get; set; }
        public string CodeTerm4 { get; set; }
        public string MostRecentIssueDateInCourse1 { get; set; }
        public string NameDosageAndQuantity1 { get; set; }
        public string Date5 { get; set; }
        public string CodeTerm5 { get; set; }
        public string Date6 { get; set; }
        public string CodeTerm6 { get; set; }
        public string Date7 { get; set; }
        public string CodeTerm7 { get; set; }
        public string Date8 { get; set; }
        public string CodeTerm8 { get; set; }
        public string Value { get; set; }
        public string Count { get; set; }
        public string Count1 { get; set; }
    }

}
