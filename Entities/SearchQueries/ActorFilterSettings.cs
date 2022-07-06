using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SearchQueries
{
    public class ActorFilterSettings
    {
        public int? decadesSearch { get; set; }

        public string genresSearch { get; set; }

        public string countriesSearch { get; set; }

    }
}
