using Savi.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace Savi.Core.DTO
{
    public class UpdateKycDto
    {
        [Required(ErrorMessage = "Date ofBirth is required")]
        public DateTime DateOfBirth { get; set; }

        [EnumDataType(typeof(Occupation), ErrorMessage = "Occupation is required")]
        public Occupation Occupation { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "BVN is required")]
        public string BVN { get; set; } = string.Empty;

        [EnumDataType(typeof(IdentificationType), ErrorMessage = "Identification Type is required")]
        public IdentificationType IdentificationType { get; set; }

        [Required(ErrorMessage = "Identification Number is required")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Identification Document is required")]
        public string IdentificationDocumentUrl { get; set; }

        [Required(ErrorMessage = "Proof of Address is required")]
        public string ProofOfAddressUrl { get; set; }
    }
}
