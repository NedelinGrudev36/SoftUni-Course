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
            //string suppliersXml = File.ReadAllText("../../../Datasets/Suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));
            //10
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, partsXml));
        }
        //09

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

        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartsImportDto[]),
                new XmlRootAttribute("Parts"));
            PartsImportDto[] partImportDtos;
            using (var reader = new StringReader(inputXml))
            {
                partImportDtos = (PartsImportDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliersId = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var partValidWithSuppliers = partImportDtos
                .Where(p => suppliersId.Contains(p.SupplierId))
                .ToArray();

            Part[] part = partValidWithSuppliers
                .Select(dto => new Part()
                {
                    Name =dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(part);
            context.SaveChanges();

            return $"Successfully imported {part.Length}";
                
            
        }
    }
}