using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaButikenOnline.Core.ViewModels
{
    public class CheckoutFormViewModel
    {
        public CheckoutFormViewModel()
        {
            PaymentMenthods = new List<PaymentViewModel>
            {
                new PaymentViewModel {Id = 1, Name = "Kontant" },
                new PaymentViewModel {Id = 2, Name = "PayPal" },
                new PaymentViewModel {Id = 3, Name = "Kort" },
            };
        }
        public bool Delivery { get; set; }
        public DateTime PreferedDeliveryTime { get; set; }

        [Required(ErrorMessage = "Namnet måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara mellan 3-50 bokstäver")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gatuadressen måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Gatuadressen måste vara mellan 3-50 bokstäver")]
        [Display(Name = "Gatuadress")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Postkod måste vara ifylld")]
        [Range(0, int.MaxValue)]
        [Display(Name = "Postkod")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Staden måste vara ifylld")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Staden måste vara mellan 2-50 bokstäver")]
        [Display(Name = "Stad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Telefonnummret måste vara ifylld")]
        [Phone(ErrorMessage = "Måste vara ett giltigt telefonnummer")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email addressen måste vara ifylld")]
        [EmailAddress(ErrorMessage = "Måste vara en giltig email adress")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int PaymentMethod { get; set; }
        public List<PaymentViewModel> PaymentMenthods { get; set; }
    }
}
