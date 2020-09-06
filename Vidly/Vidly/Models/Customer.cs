using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Customer
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Customer()
        {

        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }
        
        [Display(Name ="Subscribed to NewsLetter")]
        public bool IsSubscribeToNewsLetter { get; set; }

        [Display(Name="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd MMM yyyy}")]
        [Min18YearsMembership]
        public DateTime? BirthDate { get; set; }

        public MemberShipType MemberShipType { get; set; }
        //Forign Key for membershiptype class
        [Display(Name ="Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }
}
