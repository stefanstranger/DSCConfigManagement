using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSCConfigurationManagement.Models
{
    public class MyGuid
    {
        public int ID { get; set; }
        [Required]
        public string FQDN { get; set; }
        public string DSCGuid { get; set; }
    }
}