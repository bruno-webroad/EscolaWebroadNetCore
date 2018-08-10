using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaWRWeb.ViewModels
{
    public class EnterpriseVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório.")]
        [MaxLength(30, ErrorMessage = "A cidade deve ter no máximo 30 caracteres.")]
        [Display(Name = "Cidade:")]
        public string City { get; set; }

        [Display(Name = "Endereço:")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O campo número de funcionários é obrigatório.")]
        [Range(0, 100000, ErrorMessage = "O número de funcionários deve estar entre 0 e 100000.")]
        [Display(Name = "Número de funcionários:")]
        public int? StaffNumber { get; set; }

        [Required(ErrorMessage = "O campo lucro anual é obrigatório.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Lucro anual:")]
        public decimal? AnualProfit { get; set; } 
    }
}
