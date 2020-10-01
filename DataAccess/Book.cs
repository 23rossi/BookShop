using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    public class Book
    {
        [Column("BookID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BookID { get; set; }

        [Column("BookName")]
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [ForeignKey("AuthorID")]
        public virtual List<Author> Orders { get; set; }
    }
}
