using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Number_Guessing.Data;
using Number_Guessing.Data.Entities;
using System.Reflection.Metadata;

namespace Number_Guessing.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyWorldDbContext _myWorldDbContext;

        public string Message { get; set; }

        [TempData]
        public int Counter { get; set; } = 0;
        public string Hint { get; set; }

        [TempData]
        public int NumberToGuess { get; set; }

        [BindProperty]
        public int GuessedNumber { get; set; }
        public IndexModel(ILogger<IndexModel> logger, MyWorldDbContext myWorldDbContext)
        {
            _logger = logger;
            _myWorldDbContext = myWorldDbContext;

        }

        public void OnGet()
        {
            Random random = new Random();
            NumberToGuess = random.Next(1, 101);
        }

        public void OnPost()
        {
            if (NumberToGuess == GuessedNumber)
            {
                Message = "You guessed it!";
            }

            else
            {
                Message = "Try again :(";
            }

            if (GuessedNumber > NumberToGuess)
            {
                Hint = "You guessed too high";
            }
            else if (GuessedNumber < NumberToGuess)
            {
                Hint = "You guessed too low";
            }

            Counter++;
            TempData.Keep("Counter");
            TempData.Keep("NumberToGuess");

            var entry = _myWorldDbContext.Add(new TableData(GuessedNumber, Counter, Message));
            _myWorldDbContext.SaveChanges();
        }
    }

}