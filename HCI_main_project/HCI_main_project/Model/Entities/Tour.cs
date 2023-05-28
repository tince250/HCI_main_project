using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public byte[] Image { get; set; }

        [ForeignKey("TravelAgent")]
        public int TravelAgentId { get; set; }
        public virtual User TravelAgent { get; set; }

        public virtual List<TourAttraction> TourAttractions { get; set; }
        public virtual List<TourAccommodation> TourAccommodations { get; set; }
        public virtual List<TourRestaurant> TourRestaurants { get; set; }
        public virtual List<TourTraveler> TourTravelers { get; set; }

    }
}
