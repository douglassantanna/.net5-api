using System;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataDeNascimento { get; set; }
        
    }
}