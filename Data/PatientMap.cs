using Core.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PatientMap : ClassMap<PatientModel>
    {
        public PatientMap()
        {
            Map(m => m.EMISNumber).Index(0);
            Map(m => m.OrganisationCode).Index(1);
            Map(m => m.NHSNumber).Index(2);
            Map(m => m.GivenName).Index(3);
            Map(m => m.FamilyName).Index(4);
            Map(m => m.DateOfBirth).Index(5);
            Map(m => m.Age).Index(6);
            Map(m => m.Gender).Index(7);
            Map(m => m.HouseNameFlatNumber).Index(8);
            Map(m => m.NumberAndStreet).Index(9);
            Map(m => m.Locality).Index(10);
            Map(m => m.Town).Index(11);
            Map(m => m.County).Index(12);
            Map(m => m.Postcode).Index(13);
            Map(m => m.UsualGPsFullName).Index(14);
            Map(m => m.MaritalStatus).Index(15);
            Map(m => m.EthnicOrigin).Index(16);

            // Explicitly ignore the PatientType property
            Map(m => m.PatientType).Ignore();
        }
    }
}
