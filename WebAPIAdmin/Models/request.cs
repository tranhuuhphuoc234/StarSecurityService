﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("request")]
    public class request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id",TypeName ="int")]
        public int id { get; set; }
        
        [Column("description",TypeName ="varchar")]
        [StringLength(3000)]
        public string description { get; set; }

        [Column("client",TypeName ="int")]
        public int client { get; set; }

        [Column("status",TypeName ="bit")]
        public bool status { get; set; }

    }
}
