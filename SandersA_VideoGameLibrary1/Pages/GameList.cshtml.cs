using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SandersA_VideoGameLibrary1.Data.DAL;
using SandersA_VideoGameLibrary1.Data.Models;

namespace SandersA_VideoGameLibrary1.Pages
{
    public class GameListModel : PageModel
    {
        public IVideoGameDal Dal { get; private set; }
        public List<VideoGame>? Games;

        [BindProperty(SupportsGet = true)]
        public string? SearchKey { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? FilterGenre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? FilterPlatform { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? FilterRating { get; set; }

        [BindProperty]
        public VideoGame NewGame { get; set; }

        public GameListModel(IVideoGameDal dal)
        {
            Dal = dal;
        }


        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchKey))
            {
                Games = Dal.SearchForGames(SearchKey).ToList();
            }

            if (!string.IsNullOrEmpty(FilterGenre) || !string.IsNullOrEmpty(FilterPlatform) || !string.IsNullOrEmpty(FilterRating))
            {
                FilterGenre = (FilterGenre == "") ? null : FilterGenre;
                FilterPlatform = (FilterPlatform == "") ? null : FilterPlatform;
                FilterRating = (FilterRating == "") ? null : FilterRating;

                Games = Games?.Intersect(Dal.FilterCollection(FilterGenre, FilterPlatform, FilterRating)).ToList() ?? Dal.FilterCollection(FilterGenre, FilterPlatform, FilterRating).ToList();
            }

            if (Games == null) Games = Dal.GetCollection().ToList();

            NewGame = new VideoGame();
        }

        //public void OnGet(string search)
        //{
        //    Games = Dal.SearchForGames(search).ToList();
        //}

        public IActionResult OnPostSearch()
        {
            return RedirectToAction("Get", new { SearchKey=SearchKey});
        }

        public IActionResult OnPostFilter()
        {
            return RedirectToAction("Get", new { FilterGenre=FilterGenre, FilterPlatform=FilterPlatform, FilterRating = FilterRating });
        }

        public IActionResult OnPostLoan(int id, VideoGame game)
        {
            Dal.LoanGame(id, game.NewLoan, game.NewLoanDate);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostReturn(int id)
        {
            Dal.ReturnGame(id);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostAdd()
        {
            if (NewGame != null) Dal.AddGame(NewGame);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            Dal.DeleteGame(id);

            return RedirectToAction("Get");
        }
    }
}
