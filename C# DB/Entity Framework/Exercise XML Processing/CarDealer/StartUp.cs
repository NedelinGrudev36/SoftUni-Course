using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //09
            string suppliersXml = File.ReadAllText("../../../Datasets/Suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliersXml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]),
                new XmlRootAttribute("Suppliers"));
            SupplierImportDto[] importDtos;
            using (var reader = new StringReader(inputXml))
            {
                importDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] supplier = importDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                }).ToArray();

            context.Suppliers.AddRange(supplier);
            context.SaveChanges();

            return $"Successfully imported {supplier.Length}";
        }
    }
}