using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataManager.Library.Models
{
    public class GeneralDetailsModel
    {
        public int Id { get; set; }

        [Required]
        public int Brand_Id { get; set; }

        [Required]
        public int GeneralType_Id { get; set; }

        [Required]
        public int SubType_Id { get; set; }
    }
}
