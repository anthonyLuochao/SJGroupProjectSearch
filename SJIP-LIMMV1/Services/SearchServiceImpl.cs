using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PagedList;
using SJIP_LIMMV1.Models;
using SJIP_LIMMV1.SearchRepository;
using SJIP_LIMMV1.Helper;
using System.Collections;

namespace SJIP_LIMMV1.Services
{
    public class SearchServiceImpl:ISearchService
    {
        ISearchRepo searchRepo = new SearchRepoImpl();

        public async Task<PagedList<SearchDTO>> LoadInitSearchPageAsync()
        {
            IList queryResult = await searchRepo.GetAllQeuryResultAsync();
            List<SearchDTO> searchDTO = SearchHelper.ConvertQueryResultToSearchDTO(queryResult);
            return  SearchHelper.ConvertSearchDTOToPagedList(null,null, searchDTO);
        }

        public async Task<PagedList<SearchDTO>> SearchByAllFieldAsync(int? pageNumber,int? pageSize,SearchViewModel searchViewModel)
        {
            IList queryResult =await searchRepo.GetQueryResultFromSearchAsync(searchViewModel);
            var searchDTO = SearchHelper.ConvertQueryResultToSearchDTO(queryResult);
            return SearchHelper.ConvertSearchDTOToPagedList(pageNumber, pageSize, searchDTO);
        }
    }
}