using PagedList;
using SJIP_LIMMV1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SJIP_LIMMV1.SearchRepository
{
    public interface ISearchRepo
    {
        Task<IList> GetAllQeuryResultAsync();


        Task<IList> GetQueryResultFromSearchAsync(SearchViewModel searchViewModel);
        

    }
}