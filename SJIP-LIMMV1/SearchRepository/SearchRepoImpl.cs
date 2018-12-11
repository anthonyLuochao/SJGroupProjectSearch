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
using System.Data.Entity;
using System.Threading.Tasks;

namespace SJIP_LIMMV1.SearchRepository
{
    public class SearchRepoImpl:ISearchRepo
    {
        
        LiftInstallationDataDBEntities1 db = new LiftInstallationDataDBEntities1();

        public async Task<IList> GetAllQeuryResultAsync()        
        {
            return await db.SensorBoxInfoes.Select(x => new { x.TownCouncil, x.BlockNo, x.SIMCard, x.LMPD }).ToListAsync();
        }

       
        public async Task<IList> GetQueryResultFromSearchAsync(SearchViewModel searchViewModel)
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
            
            return await db.SensorBoxInfoes.Where(predicate).Select(i => new { i.TownCouncil, i.BlockNo, i.SIMCard, i.LMPD }).ToListAsync();
          
        }

     
    }
}