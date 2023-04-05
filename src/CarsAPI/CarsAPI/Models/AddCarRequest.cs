namespace CarsAPI.Models
{
    public class AddCarRequest
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public bool isUsed { get; set; }
    }
}
