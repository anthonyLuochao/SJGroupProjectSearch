using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SJIP_LIMMV1.Models;
using PagedList;
using System.Threading.Tasks;

namespace SJIP_LIMMV1.Services
{
    public interface ISearchService
    {
        Task<PagedList<SearchDTO>> LoadInitSearchPageAsync();

        Task<PagedList<SearchDTO>> SearchByAllFieldAsync(int? pageNumber, int? pageSize, SearchViewModel searchViewModel);
    }
}