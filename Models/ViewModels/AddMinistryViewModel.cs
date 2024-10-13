using GarageManagement.Models.Entities;

namespace GarageManagement.Models.ViewModels
{
    public class AddMinistryViewModel
    {
        public Guid MinistryId { get; set; }
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
