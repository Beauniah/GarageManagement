namespace GarageManagement.Models.Entities
{
    public class Vehicle
    {
        
            public Guid VehicleId { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public DateTime DateAquired { get; set; }
             public Guid MinistryId { get; set; }
             public Ministry Ministry { get; set; }
            
        }

    
}
