using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    using static DataConstarints;
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PackageNameMaxLength)]
        public string PackageName { get; set; }

        [MaxLength(DescriptionMaxLenth)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new List<TourPackageGuide>();
    }
}
