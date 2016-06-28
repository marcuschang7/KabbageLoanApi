using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarcusChangKappageAPI.Models
{
    public class KabbageFormModel
    {
        [Required(ErrorMessage = "You need to fill in a First Name")]
        [DisplayName("First Name ")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "You need to fill in a Last Name")]
        [DisplayName("Last Name ")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "You need to fill in a Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "You need to fill in a Business Name")]
        [DisplayName("Business Name")]
        public string businessName { get; set; }
        [Required(ErrorMessage = "You need to fill in a Phone Number")]
        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "You need to fill in Year Started")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        [DisplayName("Year Started")]
        public int yearStarted { get; set; }
        [Required(ErrorMessage = "You need to fill in Estimated FICO Score")]
        [DisplayName("Estimated FICO")]
        public int estimatedFICO { get; set; }
        [Required(ErrorMessage = "You need to fill in Annual Revenue")]
        [DisplayName("Annual Revenue")]
        public int estimatedAnnualRevenue { get; set; }
        //[Required(ErrorMessage = "You need to fill in Percentage (%) of annual revenue from credit card transactions.")]
        [DisplayName("% Annual Revenue from Credit Card Transactions")]
        public int grossPercentageFromCards { get; set; }
        [Required]
        [DisplayName("Type of Business")]
        public string api_key { get; set; }
        public typesOfBusiness typeOfBusiness { get; set; }

        public enum typesOfBusiness
        {
            Accounting,
            Amusement,
            AutoRepair,
            BusinessServices,
            Catering,
            ChildCare,
            ComputerServices,
            ConsumerGoodsRetailStore,
            ConsumerGoodsOnlineStore,
            ConsumerGoodsOnlineAndOffline,
            Construction,
            Dentists,
            DryCleaning,
            Equipment,
            FoodService,
            Grocery, Health,
            HomeRepair,
            Hotels,
            Insurance,
            Janitorial,
            Landscape,
            Optometrists,
            Physicians,
            Restaurants,
            Salons,
            Taxis,
            Trucking,
            Veterinarians
        }
    }

    public class PreQualificationResponse
    {
        public string Qualified { get; set; }
        public int QualifyAmount { get; set; }
        public Uri RedirectUrl { get; set; }
    }
    public class PreQualificationResponseFinal
    {
        public string Qualified { get; set; }
        public int QualifyAmount { get; set; }
        public string RedirectUrl { get; set; }
    }
    public class PreQualificationRequest
    {
        public string api_key { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string businessName { get; set; }
        public string phoneNumber { get; set; }
        public string typeOfBusiness { get; set; }
        public int yearStarted { get; set; }
        public int estimatedFICO { get; set; }
        public int estimatedAnnualRevenue { get; set; }
        public int grossPercentageFromCards { get; set; }
    }

}