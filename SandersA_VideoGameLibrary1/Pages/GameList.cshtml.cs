using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SandersA_VideoGameLibrary1.Data.Models;

namespace SandersA_VideoGameLibrary1.Pages
{
    public class GameListModel : PageModel
    {
        public static List<VideoGame> Games { get; set; } = new List<VideoGame>
        {
            new VideoGame("Helldivers 2", 2024, new string[] { "PC", "PS5" }, "Third-Person Shooter", "Mature 17+", "https://th.bing.com/th/id/OIP.bIaeDWRfcP0aDr15eHvDFAAAAA?rs=1&pid=ImgDetMain"),
            new VideoGame("Throne & Liberty", 2024, new string[] { "PC", "PS5", "Xbox Series X" }, "MMORPG", "T (Teen)", "https://images.igdb.com/igdb/image/upload/t_cover_big_2x/co8j6b.jpg"),
            new VideoGame("Marvel Rivals", 2024, new string[] { "PC", "PS5", "Xbox Series X" }, "Hero Shooter", "T (Teen)", "https://upload.wikimedia.org/wikipedia/en/5/50/Marvel_Rivals_cover_art.jpg"),
            new VideoGame("Bloons TD 6", 2018, new string[] { "PC", "PS4", "Xbox One", "Xbox Series X/S", "Mobile" }, "Tower Defense", "E (Everyone)", "https://cdn1.epicgames.com/spt-assets/764b2d57552c436590f50318bd7587f9/download-bloons-td-6-offer-100fo.jpg"),
            new VideoGame("Barony", 2015, new string[] { "PC", "Nintendo Switch" }, "Roguelike", "T (Teen)", "https://cdn1.epicgames.com/offer/b79cdb6e07ea4ce9a82c00a0fb079ca5/EGS_Barony_TurningWheelLLC_S2_1200x1600-e71ba57b3bc17f4aae5aab41d6830758"),
            new VideoGame("The Planet Crafter", 2024, new string[] { "PC" }, "Open-world Survival", "Not Rated", "https://images.igdb.com/igdb/image/upload/t_cover_big/co4l0t.webp"),
        };

        public void OnGet()
        {
        }

        public IActionResult OnPostLoan(int id, VideoGame game)
        {
            var matchingGame = Games.FirstOrDefault(g => g.Id == id);
            if (matchingGame != null && game != null)
            {
                matchingGame.LoanGame(game.NewLoan, game.NewLoanDate);
            }

            return RedirectToAction("Get");
        }

        public IActionResult OnPostReturn(int id)
        {
            var matchingGame = Games.FirstOrDefault(g => g.Id == id);
            if (matchingGame != null)
            {
                matchingGame.ReturnGame();
            }

            return RedirectToAction("Get");
        }
    }

}
