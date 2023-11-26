using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Models
{
    public class PatientModel : IPatientData
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
    }
}
