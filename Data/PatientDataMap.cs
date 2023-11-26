using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Data
{
    public class PatientDataMap : ClassMap<PatientDataModel>
    {
        public PatientDataMap()
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
            Map(m => m.Date).Index(17);
            Map(m => m.CodeTerm).Index(18);
            Map(m => m.Date1).Index(19);
            Map(m => m.CodeTerm1).Index(20);
            Map(m => m.Date2).Index(21);
            Map(m => m.CodeTerm2).Index(22);
            Map(m => m.NameDosageAndQuantity).Index(23);
            Map(m => m.MostRecentIssueDateInCourse).Index(24);
            Map(m => m.Date3).Index(25);
            Map(m => m.CodeTerm3).Index(26);
            Map(m => m.Date4).Index(27);
            Map(m => m.CodeTerm4).Index(28);
            Map(m => m.MostRecentIssueDateInCourse1).Index(29);
            Map(m => m.NameDosageAndQuantity1).Index(30);
            Map(m => m.Date5).Index(31);
            Map(m => m.CodeTerm5).Index(32);
            Map(m => m.Date6).Index(33);
            Map(m => m.CodeTerm6).Index(34);
            Map(m => m.Date7).Index(35);
            Map(m => m.CodeTerm7).Index(36);
            Map(m => m.Date8).Index(37);
            Map(m => m.CodeTerm8).Index(38);
            Map(m => m.Value).Index(39);
            Map(m => m.Count).Index(40);
            Map(m => m.Count1).Index(41);

            // Explicitly ignore the PatientType property
            Map(m => m.PatientType).Ignore();
        }
    }
}

