using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace DiarioPolitico.Models
{
    public class Usuario
    {
        [Display(Name = "Cedula")]
        [Key]
        [MinLength(8, ErrorMessage = "La cedula debe constar de 8 caracteres numericos sin . ni - ")]
        [MaxLength(8, ErrorMessage = "La cedula debe constar de 8 caracteres numericos sin . ni - ")]
        public string ci { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Display(Name = "E-Mail")]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        [Index(IsUnique = true/*, ErrorMessage = "El mail ya esta registrado en el sistema."*/)]
        public string email { get; set; }

        [Display(Name = "Contraseña")]
        [Required]
        [MinLength(8, ErrorMessage = "La contraseña debe ser mayor a 8 caracteres.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name ="Administrador")]
        public bool isAdmin { get; set; }

        [NotMapped]
        public List<Proyecto> proyectos { get; set; }

        [NotMapped]
        public List<Comentario> comentarios { get; set; }

        [Display(Name = "Confirmación")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Las contraseñas deben coincidir.")]
        public string rePassword { get; set; }

        public Usuario() { }
        
    }
}