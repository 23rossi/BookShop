using Microsoft.AspNetCore.Mvc;
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
        // model of Queries mapped into DB

        [Column("QueryID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AuthorID { get; set; }

        //AuthorQueryName must be restricted maxLength = 50
        [Column("AuthorQueryName")]
        [Required]
        [StringLength(50)]
        public String AuthorName { get; set; }

        //BookQueryName must be restricted maxLength = 40
        [Column("BookQueryName")]
        [Required]
        [StringLength(40)]
        public String BookName { get; set; }

        //query must be restricted maxLength = 500
        [Column("Query")]
        [Required]
        [StringLength(500)]
        public String QueryText { get; set; }

    }
}
