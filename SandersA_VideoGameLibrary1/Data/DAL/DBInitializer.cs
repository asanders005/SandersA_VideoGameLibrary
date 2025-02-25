using SandersA_VideoGameLibrary1.Data.Models;

namespace SandersA_VideoGameLibrary.Data.DAL
{
    public class DBInitializer
    {
        public static void Init(VideoGameDBContext context)
        {
            if (context.VideoGames.Any()) return;

            var videoGames = new VideoGame[]
            {
                new VideoGame("Helldivers 2", 2024, new string[] { "PC", "PS5" }, "Third-Person Shooter", "M", "https://th.bing.com/th/id/OIP.bIaeDWRfcP0aDr15eHvDFAAAAA?rs=1&pid=ImgDetMain"),
                new VideoGame("Throne & Liberty", 2024, new string[] { "PC", "PS5", "Xbox Series X" }, "MMORPG", "T", "https://images.igdb.com/igdb/image/upload/t_cover_big_2x/co8j6b.jpg"),
                new VideoGame("Marvel Rivals", 2024, new string[] { "PC", "PS5", "Xbox Series X" }, "Hero Shooter", "T", "https://upload.wikimedia.org/wikipedia/en/5/50/Marvel_Rivals_cover_art.jpg"),
                new VideoGame("Bloons TD 6", 2018, new string[] { "PC", "PS4", "Xbox One", "Xbox Series X/S", "Mobile" }, "Tower Defense", "E", "https://cdn1.epicgames.com/spt-assets/764b2d57552c436590f50318bd7587f9/download-bloons-td-6-offer-100fo.jpg"),
                new VideoGame("Barony", 2015, new string[] { "PC", "Nintendo Switch" }, "Roguelike", "T", "https://cdn1.epicgames.com/offer/b79cdb6e07ea4ce9a82c00a0fb079ca5/EGS_Barony_TurningWheelLLC_S2_1200x1600-e71ba57b3bc17f4aae5aab41d6830758"),
                new VideoGame("The Planet Crafter", 2024, new string[] { "PC" }, "Open-world Survival", "Not Rated", "https://images.igdb.com/igdb/image/upload/t_cover_big/co4l0t.webp"),
            };

            context.VideoGames.AddRange(videoGames);
            context.SaveChanges();
        }
    }
}
