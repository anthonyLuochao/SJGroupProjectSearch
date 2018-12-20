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

        static public String[] ConvertListSearchDTOtoStringList(List<SearchDTO> inputList)
        {
            String[] arr = new String[inputList.Count()];
            for(int i=0;i<inputList.Count();i++)
            {
                
                String option = inputList[i].ID.ToString()
                    + "," + inputList[i].PostalCode.ToString()
                    + "," + inputList[i].TownCouncil
                    + "," + inputList[i].BlockNo
                    + "," + inputList[i].SIMCard
                    + "," + inputList[i].LMPD;
                arr[i] = option;
            }
            return arr;
        }

    }
}