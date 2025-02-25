using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SandersA_VideoGameLibrary1.Data.Models
{
    public class VideoGame
    {
        public int Id { get; }
        [Required]
        public string Title { get; set; }
        [Range(1958, 2040)]
        public int Year { get; set; }
        [MinLength(1, ErrorMessage = "At least one platform is required.")]
        public string[] Platforms { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public string Image { get; set; }
        public string? LoanedTo { get; set; }
        public DateOnly? LoanDate { get; set; }

        [BindProperty]
        public string? NewLoan { get; set; }
        [BindProperty]
        public DateOnly? NewLoanDate { get; set; }

        public VideoGame()
        {
            //    Title = "Title";
            //    Year = 0;
            //    Platforms = new string[] { "null" };
            //    Genre = "none";
            //    Rating = "Not Rated";
            //    Image = "null";
        }

        public VideoGame(string title, int year, string[] platforms, string genre, string rating, string image)
        {
            Title = title;
            Year = year;
            Platforms = platforms;
            Genre = genre;
            Rating = rating;
            Image = image;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Title: {Title}");
            sb.Append($"Year: {Year}");
            sb.Append($"Platform: {Platforms.ToString}");
            sb.Append($"Genre: {Genre}");
            sb.Append($"Rating: {Rating}");
            return sb.ToString();
        }

        public void LoanGame(string? loanTo, DateOnly? loanDate)
        {
            if (LoanedTo == null)
            {
                LoanedTo = loanTo;
                LoanDate = loanDate;
            }
        }

        public void ReturnGame()
        {
            LoanedTo = null;
            LoanDate = null;
        }
    }
}
