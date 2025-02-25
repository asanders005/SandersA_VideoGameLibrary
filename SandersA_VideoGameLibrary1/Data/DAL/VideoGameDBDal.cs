using Humanizer;
using SandersA_VideoGameLibrary1.Data.DAL;
using SandersA_VideoGameLibrary1.Data.Models;

namespace SandersA_VideoGameLibrary.Data.DAL
{
    public class VideoGameDBDal : IVideoGameDal
    {
        private readonly VideoGameDBContext _context;
        public VideoGameDBDal(VideoGameDBContext context)
        {
            _context = context;
        }

        public void AddGame(VideoGame game)
        {
            _context.VideoGames.Add(game);
            _context.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            var game = _context.VideoGames.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                _context.VideoGames.Remove(game);
                _context.SaveChanges();
            }
        }

        public IEnumerable<VideoGame> GetCollection()
        {
            return _context.VideoGames.AsEnumerable();
        }

        public IEnumerable<VideoGame> FilterCollection(string? genre = null, string? platform = null, string? esrbRating = null)
        {
            var currentCollection = _context.VideoGames.AsEnumerable();
            if (genre != null) currentCollection = currentCollection.Where(g => g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            if (platform != null) currentCollection = currentCollection.Where(g => g.Platforms.Any(p => p.Equals(platform, StringComparison.OrdinalIgnoreCase)));
            if (esrbRating != null) currentCollection = currentCollection.Where(g => g.Rating.Equals(esrbRating, StringComparison.OrdinalIgnoreCase));
            return currentCollection;
        }

        public IEnumerable<VideoGame> SearchForGames(string key)
        {
            if (key == null) return _context.VideoGames;
            return _context.VideoGames.AsEnumerable().Where(g => g.Title.Contains(key, StringComparison.OrdinalIgnoreCase));
        }

        public void LoanGame(int id, string? loanTo, DateOnly? loanDate)
        {
            if (_context.VideoGames.AsEnumerable().FirstOrDefault(g => g.Id == id) is VideoGame game)
            {
                game.LoanGame(loanTo, loanDate);
                _context.SaveChanges();
            }
        }

        public void ReturnGame(int id)
        {
            if (_context.VideoGames.AsEnumerable().FirstOrDefault(g => g.Id == id) is VideoGame game)
            {
                game.ReturnGame();
                _context.SaveChanges();
            }
        }
    }
}
