using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactManager.Pages.Books
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ContactManager.Data.ApplicationDbContext _context;
        private Book _bookModel;

        public IndexModel(ContactManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostRent(Guid id)
        {
            _bookModel = _context.Book.FirstOrDefault(x => x.Id == id);
            if (_bookModel == null)
            {
                return NotFound();
            }

            _bookModel.Rented = true;
            _bookModel.ReturnDate = DateTime.Today.AddMonths(1);
            _bookModel.Reader = User.Identity.Name;

            _context.Update(_bookModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostReturn(Guid id, String user)
        {
            _bookModel = _context.Book.FirstOrDefault(x => x.Id == id);
            if (_bookModel == null)
            {
                return NotFound();
            }

            _bookModel.Rented = false;
            _bookModel.Reader = "";

            _context.Update(_bookModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
        
    }
}