using GarageManagement.Models.Entities;
using GarageManagement.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Models.ViewModels
{
    public class AddIncidentViewModel
    {
        public Guid IncidentId { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
        [BindNever]
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public DateTime DateReported { get; set; }

        public string Description { get; set; }

        public IncidentStatus Status { get; set; }

        public SeverityLevel SeverityLevel { get; set; }
    }
}
