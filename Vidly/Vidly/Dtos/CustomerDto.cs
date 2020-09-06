using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

       // [Min18YearsMembership]
        public DateTime? BirthDate { get; set; }

        public MemberShipTypeDto MemberShipType { get; set; }
        public byte MemberShipTypeId { get; set; }
    }
}
