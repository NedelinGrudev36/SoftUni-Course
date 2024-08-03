using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var output = new StringBuilder();
            var customersXml = XDocument.Parse(xmlString);
            var customers = customersXml.Root.Elements("Customer");

            foreach (var customerXml in customers)
            {
                var fullName = customerXml.Element("FullName")?.Value;
                var email = customerXml.Element("Email")?.Value;
                var phoneNumber = customerXml.Attribute("phoneNumber")?.Value;

                // Validation logic
                if (string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(phoneNumber))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                // Check for duplication
                if (context.Customers.Any(c => c.FullName == fullName || c.Email == email || c.PhoneNumber == phoneNumber))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                // Add customer to the database
                var customer = new Customer
                {
                    FullName = fullName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
                context.Customers.Add(customer);
                output.AppendLine(string.Format(SuccessfullyImportedCustomer, fullName));
            }
            context.SaveChanges();
            return output.ToString();

            //public static bool IsValid(object dto)
            //{
            //    var validateContext = new ValidationContext(dto);
            //    var validationResults = new List<ValidationResult>();

            //    bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            //    foreach (var validationResult in validationResults)
            //    {
            //        string currValidationMessage = validationResult.ErrorMessage;
            //    }

            //    return isValid;
            //}
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public string ImportBookings(string jsonString, TravelAgencyContext context)
        {
            var output = new StringBuilder();
            var bookings = JsonConvert.DeserializeObject<List<BookingDto>>(jsonString);

            foreach (var bookingDto in bookings)
            {
                DateTime bookingDate;
                if (!DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDate))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                if (customer == null || tourPackage == null)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                // Add booking to the database
                var booking = new Booking
                {
                    BookingDate = bookingDate,
                    Customer = customer,
                    TourPackage = tourPackage
                };
                context.Bookings.Add(booking);
                output.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.SaveChanges();
            return output.ToString();
        }
    }   
} 
        
