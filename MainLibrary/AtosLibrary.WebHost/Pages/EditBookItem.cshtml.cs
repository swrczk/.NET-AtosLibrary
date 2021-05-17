using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.EditBookItem;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.BookItem;
using AtosLibrary.Presentation.BookItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class EditBookItemModel : PageModel
    {
        private IBookItemPresentationRepository _presentationRepository;
        private ICommandHandler<EditBookItemCommand> _commandHandler;

        public EditBookItemModel(IBookItemPresentationRepository presentationRepository, ICommandHandler<EditBookItemCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        [BindProperty]
        public BookItemModel BookItemModel { get; set; }

        public void OnGet(Guid id)
        {
            BookItemModel = _presentationRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new EditBookItemCommand(BookItemModel.Id, BookItemModel.BookId, BookItemModel.Description, BookItemModel.BookItemStatus));

            return RedirectToPage("/Index");
        }
    }
}