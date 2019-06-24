using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //Data annotation below will make the birthday show date only and not time.
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<DateTime> Birthdate { get; set; }

    }
}