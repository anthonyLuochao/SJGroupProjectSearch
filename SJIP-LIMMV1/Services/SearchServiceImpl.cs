using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using SJIP_LIMMV1.Models;
using SJIP_LIMMV1.SearchRepository;

namespace SJIP_LIMMV1.Services
{
    public class SearchServiceImpl:ISearchService
    {
        ISearchRepo searchRepo = new SearchRepoImpl();

        public PagedList<SearchDTO> LoadInitSearchPage()
        {
            var searchDTO = searchRepo.ConvertQueryResultToSearchDTO(searchRepo.GetAllQeuryResult());
            return searchRepo.ConvertSearchDTOToPagedList(null,null,searchDTO);
        }

        public PagedList<SearchDTO> SearchByAllField(int? pageNumber,int? pageSize,SearchViewModel searchViewModel)
        {
            var queryResult= searchRepo.GetQueryResultFromSearch(searchViewModel);
            var searchDTO = searchRepo.ConvertQueryResultToSearchDTO(queryResult);
            return searchRepo.ConvertSearchDTOToPagedList(pageNumber, pageSize, searchDTO);
        }
    }
}