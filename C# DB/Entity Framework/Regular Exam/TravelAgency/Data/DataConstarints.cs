using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public static class DataConstarints
    {
        //Customer
        public const byte FullNameMinLength = 4;
        public const byte FullNameMaxLength = 60;
        public const byte EmailMinLength = 6;
        public const byte EmailMaxLength = 50;
        //Booking
        //Guide
        //TourPackage
        public const byte PackageNameMinLength = 2;
        public const byte PackageNameMaxLength = 40;
        public const byte DescriptionMaxLenth = 200;
        
       
    }
}
