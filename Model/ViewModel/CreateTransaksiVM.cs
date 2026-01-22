using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barangku.Model.ViewModel
{
    public class CreateTransaksiVM : IValidatableObject
    {
        [Required(ErrorMessage = "Kasir wajib diisi")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Total wajib diisi")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Bayar wajib diisi")]
        public decimal Bayar { get; set; }

        public decimal Kembali { get; set; }

        [Required]
        public List<AddDetailTransaksiVM> Details { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Bayar < Total)
            {
                yield return new ValidationResult(
                    "Bayar tidak boleh lebih kecil dari Total",
                    new[] { nameof(Bayar) }
                );
            }

            if (Bayar >= Total)
            {
                Kembali = Bayar - Total;
            }
        }
    }
}
