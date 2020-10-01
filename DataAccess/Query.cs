using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.DataAccess
{
    public class Query
    {

        [Column("QueryID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AuthorID { get; set; }

        [Column("AuthorQueryName")]
        [Required]
        [StringLength(50)]
        public String AuthorName { get; set; }

        [Column("BookQueryName")]
        [Required]
        [StringLength(40)]
        public String BookName { get; set; }

        [Column("Query")]
        [Required]
        [StringLength(500)]
        public String QueryText { get; set; }

    }
}
