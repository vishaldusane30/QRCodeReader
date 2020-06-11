using QRCODE.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE.Models
{
    public class QRCODE
    {
        

        [Required]
        public string Name { get; set; }

       
    }
}
