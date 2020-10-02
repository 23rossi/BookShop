using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    // model of Books mapped into DB
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
        public string Name { get; set; }

        [ForeignKey("BookID")]
        public virtual List<Author> Authors { get; set; }
    }
}
