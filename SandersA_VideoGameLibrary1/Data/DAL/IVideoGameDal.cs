using SandersA_VideoGameLibrary1.Data.Models;

namespace SandersA_VideoGameLibrary1.Data.DAL
{
    public interface IVideoGameDal
    {
        public IEnumerable<VideoGame> GetCollection();
        public IEnumerable<VideoGame> SearchForGames(string key);
        public IEnumerable<VideoGame> FilterCollection(string? genre = null, string? platform = null, string? esrbRating = null);
        public void AddGame(VideoGame game);
        public void DeleteGame(int id);
        public void LoanGame(int id, string? loanTo, DateOnly? loanDate);
        public void ReturnGame(int id);
    }
}
