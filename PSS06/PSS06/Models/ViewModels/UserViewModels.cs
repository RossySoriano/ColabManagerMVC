using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PSS06.Models.ViewModels
{
    public class QueryViewModels
    {
        public int _Id { get; set; }
        public string _Email { get; set; }
        public int _Edad { get; set; }
    }

    public class AddViewModel
    {
        [Required]
        [Display(Name ="Nombre de Usuario")]
        public string Nombre { get; set; }
        
        [Required]
        [Display(Name ="Correo Electronico")]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="El {0} debe tener al menos {1} caracter", MinimumLength =1)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirma Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Las contrasenas no son iguales")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name ="edad")]
        public int Edad { get; set; }
    }

    public class EditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirma Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contrasenas no son iguales")]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "edad")]
        public int Edad { get; set; }
    }
}