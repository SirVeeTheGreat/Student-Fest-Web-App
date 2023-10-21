using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studfest.Models
{
    public class Events
    {
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }
        [Required]
        public string Decription { get; set; }
        [Required]
        public string ImgUrl { get; set; }

        public bool ApprovedToPublish { get; set; } = false;

        public string UserEmail { get; set; }
    }
}
