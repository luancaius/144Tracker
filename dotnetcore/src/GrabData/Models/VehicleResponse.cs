using Refit;

namespace GrabData.Models
{
    public class VehicleResponse
    {
        [AliasAs("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
