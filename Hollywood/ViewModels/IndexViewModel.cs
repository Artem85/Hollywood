using Hollywood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hollywood.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<MovieModel> Movies { get; set; }

    }
}
