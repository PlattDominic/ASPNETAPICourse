namespace CarsAPI.Models
{
    public class UpdateCarRequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public bool isUsed { get; set; }  
    }
}
