using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string NameGame { get; set; }
        public string StudioDeveloper { get; set; }
        public string GameGenre { get; set; }
    }
}
