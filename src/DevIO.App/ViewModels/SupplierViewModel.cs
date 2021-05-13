using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Documento")]
        public string Document { get; set; }
        
        [DisplayName("Tipo")]
        public int SupplierType { get; set; }
        
        [DisplayName("Ativo?")]
        public bool Active { get; set; }

        public AddressViewModel Address { get; set; }
        
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
