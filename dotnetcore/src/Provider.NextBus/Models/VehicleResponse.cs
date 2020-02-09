using Refit;

namespace Provider.NextBus.Models
{
    public class VehicleResponse
    {
        [AliasAs("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
