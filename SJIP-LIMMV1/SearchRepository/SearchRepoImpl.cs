using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SJIP_LIMMV1.Models;
using AutoMapper;
using SJIP_LIMMV1.Helper;
using PagedList;
using SJIP_LIMMV1.Services;
using System.Collections;

namespace SJIP_LIMMV1.SearchRepository
{
    public class SearchRepoImpl:ISearchRepo
    {
        
        LiftInstallationDataDBEntities1 db = new LiftInstallationDataDBEntities1();

        public IList GetAllQeuryResult()        
        {
            return db.SensorBoxInfoes.Select(x => new { x.TownCouncil, x.BlockNo, x.SIMCard, x.LMPD }).ToList();
        }

        public List<SearchDTO> ConvertQueryResultToSearchDTO(IList queryResult)
        {
            return Mapper.Map<List<SearchDTO>>(queryResult);
        }

        public PagedList<SearchDTO> ConvertSearchDTOToPagedList(int? pageNumber,int? pageSize,List<SearchDTO> result)
        {
            int pageNo=(pageNumber??Constant.DefaultPageNumber );
            int pageScale = (pageSize ?? Constant.DefaultPageSize);
            PagedList<SearchDTO> pagedList = new PagedList<SearchDTO>(result, pageNo, pageScale);
            return pagedList;

        }
       

        public IList GetQueryResultFromSearch(SearchViewModel searchViewModel)
        {
            //a LINQ helper,predicateBuilder used to create dynamic query string with LINQ function
            var predicate = PredicateBuilder.True<SensorBoxInfo>();

            //check each search field to generate query string
            if (searchViewModel.Block != null)
            {
                predicate = predicate.And(i => (i.BlockNo.ToString()).ToLower().StartsWith(searchViewModel.Block.Trim().ToLower()));
            }
            if (searchViewModel.TownCouncil != null)
            {
                predicate = predicate.And(i => i.TownCouncil.ToLower().Contains(searchViewModel.TownCouncil.Trim().ToLower()));
            }
            if (searchViewModel.SIMCard != null)
            {
                predicate = predicate.And(i => i.SIMCard.ToLower().StartsWith(searchViewModel.SIMCard.Trim().ToLower()));
            }
            if (searchViewModel.LMPD != null)
            {
                predicate = predicate.And(i => i.LMPD.ToLower().StartsWith(searchViewModel.LMPD.Trim().ToLower()));
            }
            
            return db.SensorBoxInfoes.Where(predicate).Select(i => new { i.TownCouncil, i.BlockNo, i.SIMCard, i.LMPD }).ToList();
          
        }

     
    }
}