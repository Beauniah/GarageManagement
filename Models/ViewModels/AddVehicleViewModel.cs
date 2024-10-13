using GarageManagement.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Models.ViewModels
{
    public class AddVehicleViewModel
    {
        public Guid VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateOnly Year { get; set; }
        public DateTime DateAquired { get; set; } // Fixed the typo
        [Required]
        public Guid MinistryId { get; set; }
        public List<Ministry> Ministries { get; set; } // For populating the dropdown list


    }
}
