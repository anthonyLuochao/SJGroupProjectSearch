using AutoMapper;
using PagedList;
using SJIP_LIMMV1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SJIP_LIMMV1.Helper
{
    public class SearchHelper
    {
        static public  List<SearchDTO> ConvertQueryResultToSearchDTO(IList queryResult)
        {
            return  Mapper.Map<List<SearchDTO>>( queryResult);
        }

        static public  PagedList<SearchDTO> ConvertSearchDTOToPagedList(int? pageNumber, int? pageSize, List<SearchDTO> result)
        {
            int pageNo = (pageNumber ?? Constant.DefaultPageNumber);
            int pageScale = (pageSize ?? Constant.DefaultPageSize);
            PagedList<SearchDTO> pagedList =  new PagedList<SearchDTO>( result, pageNo, pageScale);
            return  pagedList;

        }

    }
}