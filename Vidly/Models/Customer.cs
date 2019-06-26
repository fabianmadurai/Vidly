using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First and Last Name")]
        public string Name { get; set; }

        [Display(Name = "Subscribe to News Letter")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Type of Membership")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        //Data annotation below will make the birthday show date only and not time.
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Date of Birth")]
        public Nullable<DateTime> Birthdate { get; set; }

    }
}