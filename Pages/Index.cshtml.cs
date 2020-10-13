using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public _BookTableModel _bookTableModel { get; set; }
        //get DB from DI services
        public IndexModel(ILogger<IndexModel> logger, BookShop.DataAccess.AppDbContext DB)
        {
            try
            {
                //init data table model            
                _bookTableModel = new _BookTableModel(DB);
                _logger = logger;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException.ToString());
            }

        }

        public void OnGet()
        {

        }
    }
}
