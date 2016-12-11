using ArtUp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.Client.Services.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<ProjectViewModel> SearchFromMain(string model);
    }
}
