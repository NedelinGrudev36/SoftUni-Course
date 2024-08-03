using Newtonsoft.Json;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
           .Where(g => g.Language == Language.Spanish)
           .Select(g => new
           {
               g.FullName,
               TourPackages = g.TourPackagesGuides
                   .Select(tpg => tpg.TourPackage)
                   .OrderByDescending(tp => tp.Price)
                   .ThenBy(tp => tp.PackageName)
                   .Select(tp => new
                   {
                       tp.PackageName,
                       tp.Description,
                       tp.Price
                   })
                   .ToList()
           })
           .OrderByDescending(g => g.TourPackages.Count)
           .ThenBy(g => g.FullName)
           .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<GuideExportDto>), new XmlRootAttribute("Guides"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var guideDtos = guides.Select(g => new GuideExportDto
            {
                FullName = g.FullName,
                TourPackages = g.TourPackages.Select(tp => new TourPackageExportDto
                {
                    Name = tp.PackageName,
                    Description = tp.Description,
                    Price = tp.Price
                }).ToArray()
            }).ToList();

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, guideDtos, namespaces);
                return stringWriter.ToString();
            }
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Bookings
            .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
            .GroupBy(b => b.Customer)
            .Select(g => new
            {
                FullName = g.Key.FullName,
                PhoneNumber = g.Key.PhoneNumber,
                Bookings = g.Select(b => new
                {
                    TourPackageName = b.TourPackage.PackageName,
                    Date = b.BookingDate.ToString("yyyy-MM-dd")
                })
                .OrderBy(b => b.Date)
                .ToList()
            })
            .OrderByDescending(c => c.Bookings.Count)
            .ThenBy(c => c.FullName)
            .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}
