namespace GarageManagement.Models.Entities
{
    public class Ministry
    {
        public Guid MinistryId { get; set; }
        public string Name { get; set; }

        
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
