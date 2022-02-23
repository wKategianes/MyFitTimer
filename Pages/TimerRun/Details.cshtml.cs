using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Data;
using MyFitTimer.Models;

namespace MyFitTimer.Pages.TimerRun
{
    public class DetailsModel : PageModel
    {
        private readonly MyFitTimer.Data.MyFitTimerContext _context;

        public DetailsModel(MyFitTimer.Data.MyFitTimerContext context)
        {
            _context = context;
        }

        public MyFitTimer.Models.TimerRun TimerRun { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TimerRun = await _context.TimerRuns.FirstOrDefaultAsync(m => m.ID == id);

            if (TimerRun == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
