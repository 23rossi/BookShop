using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    // model of Authors mapped into DB
    public class Author
    {
        [Column("AuthorID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AuthorID { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        [Required]
        public int BookID { get; set; }
    }
}
