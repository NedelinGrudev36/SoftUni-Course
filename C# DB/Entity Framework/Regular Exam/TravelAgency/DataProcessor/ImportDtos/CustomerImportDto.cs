using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class CustomerImportDto
    {
        [XmlElement("FullName")]
        public string FullName { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlAttribute("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
