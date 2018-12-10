using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SJIP_LIMMV1.Models;
using PagedList;

namespace SJIP_LIMMV1.Services
{
    public interface ISearchService
    {
        PagedList<SearchDTO> LoadInitSearchPage();

        PagedList<SearchDTO> SearchByAllField(int? pageNumber, int? pageSize, SearchViewModel searchViewModel);
    }
}