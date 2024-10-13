using GarageManagement.Models.Enums;

namespace GarageManagement.Models.Entities
{
    public class Incident
    {
        public Guid IncidentId { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime DateReported { get; set; }

        public string Description { get; set; }

        public IncidentStatus Status { get; set; }

        public SeverityLevel SeverityLevel { get; set; }
       
    }
}
