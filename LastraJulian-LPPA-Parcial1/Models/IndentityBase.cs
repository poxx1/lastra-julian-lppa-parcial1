using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LastraJulian_LPPA_Parcial1.Models
{
    public class IndentityBase
    {
        public class IdentityBase
        {
            [Key]
            public int Id { get; set; }
        }
    }
}