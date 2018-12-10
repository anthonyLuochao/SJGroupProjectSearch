using PagedList;
using SJIP_LIMMV1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJIP_LIMMV1.SearchRepository
{
    public interface ISearchRepo
    {
        IList GetAllQeuryResult();

        List<SearchDTO> ConvertQueryResultToSearchDTO(IList queryResult);
        
        PagedList<SearchDTO> ConvertSearchDTOToPagedList(int? pageNumber, int? pageSize, List<SearchDTO> result);
                
        IList GetQueryResultFromSearch(SearchViewModel searchViewModel);
        

    }
}