using GarageManagement.Models.Entities;
using GarageManagement.Models.Enums;

namespace GarageManagement.Models.ViewModels
{
    public class AddIncidentViewModel
    {
        public Guid IncidentId { get; set; }
        public Guid VehicleId { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public DateTime DateReported { get; set; }

        public string Description { get; set; }

        public IncidentStatus Status { get; set; }

        public SeverityLevel SeverityLevel { get; set; }
    }
}
