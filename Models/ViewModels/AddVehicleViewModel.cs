using GarageManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Models.ViewModels
{
    public class AddVehicleViewModel
    {
        public Guid VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime DateAquired { get; set; } // Fixed the typo
       
        public Guid MinistryId { get; set; }

        [BindNever]
        public List<Ministry> Ministries { get; set; } = new List<Ministry>();// For populating the dropdown list


    }
}
