using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnterpriseDotNet6.Entities.DataTransferObjects
{
    public class OwnerForUpdateDto
    {
        private string _name = null!;
        private string _address = null!;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address
        {
            get => _address;
            set => _address = value;
        }
    }
}
