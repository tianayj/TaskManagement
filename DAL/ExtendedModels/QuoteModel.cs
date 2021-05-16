using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.DAL.ExtendedModels
{
    public class QuoteModel : Quote
    {
        [Required]
        public new string QuoteType { get; set; }

        [Required]
        public new string Contact { get; set; }

        [Required]
        public new string Task { get; set; }
    }
}