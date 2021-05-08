using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAdmin.Models
{
    [Table("role")]
    public class role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    }
}
