using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP.NetRunStoredProcedures;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetRunStoredProcedures.Pages
{
    public class IndexModel : PageModel
    {
      private readonly ASP.NetRunStoredProcedures.TestDbContext _context;

      public IndexModel(ASP.NetRunStoredProcedures.TestDbContext context)
      {
        _context = context;
      }


        public virtual IList<Test> Test { get; set; }

        public virtual async Task OnGetAsync()
        {
          //Test = await _context.Set<Test>(_context.Query<Test>.FromSql("[dbo].[sp_Proc1]"));
          Test = await _context.Query<Test>().FromSql("Exec [dbo].[sp_Proc1]").ToListAsync();
          //Test = await _context.Test.ToListAsync();
        }

        /* public void OnGet()
         {

         } */
        public async Task<IActionResult> OnPostAsync()
        {
           int temp = await _context.Database.ExecuteSqlCommandAsync("[dbo].[sp_Proc3]");
           return RedirectToPage("./Index");
        }
    }
}
