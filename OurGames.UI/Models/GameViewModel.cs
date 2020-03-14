using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurGames.UI.Models
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            Plataforms = new List<int>();

            Videos = new List<string>();

            Categories = new List<int>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailLink { get; set; }
        public IFormFile Thumbnail { get; set; }

        public string BackgroundLink { get; set; }
        public IFormFile BackgroundImage { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Developer { get; set; }
        public string Rating { get; set; }
        public string Publisher { get; set; }
        public bool Active { get; set; }
        public IEnumerable<int> Plataforms  { get; set; }
        public IEnumerable<string> Videos { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public IEnumerable<string> CategoriesView { get; set; }
        public IEnumerable<string> PlataformsView { get; set; }

    }
}
