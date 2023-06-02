using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Models
{
    public class Attraction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }


    }
}
