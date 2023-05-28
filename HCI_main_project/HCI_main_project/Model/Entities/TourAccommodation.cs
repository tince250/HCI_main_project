using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class TourAccommodation
    {
        [ForeignKey("Tour")]
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }

        [ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }
        public virtual Accommodation Accommodation { get; set; }
    }
}
