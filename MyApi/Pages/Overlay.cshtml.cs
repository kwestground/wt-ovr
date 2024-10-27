using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OverlayModel : PageModel
{
    private readonly AppDbContext _context;

    public OverlayModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string? Header { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Header = DateTime.Now.ToString();
        /*
        if (id == null)
        {
            return NotFound();
        }

        Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
        
        if (Customer == null)
        {
            return NotFound();
        }
        */
        return Page();
    }
}