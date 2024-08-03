using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [Key]
        [ForeignKey(nameof(TourPackage))]
        [Required]
        public int TourPackageId { get; set; }
        public virtual TourPackage TourPackage { get; set; }

        [Key]
        [ForeignKey(nameof(Guide))]
        [Required]
        public int GuideId { get; set; }
        public virtual Guide Guide { get; set; }
    }
}
