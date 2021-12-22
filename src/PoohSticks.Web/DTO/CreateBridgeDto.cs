using System.ComponentModel.DataAnnotations;

namespace PoohSticks.Web.DTO
{
    public class CreateBridgeDto
    {
        [Required]
        public string? Lat { get; set; }
        [Required]
        public string? Lng { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
