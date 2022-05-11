using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD.Models
{
    public partial class Doctor
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string FechaNacimiento { get; set; }
        public string CodigoPostal { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
