using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SJIP_LIMMV1.Models;
using PagedList;
using AutoMapper;
using SJIP_LIMMV1;
using SJIP_LIMMV1.Services;

namespace SJIP_LIMMV1.Controllers
{
    public class SearchController : Controller
    {
        LiftInstallationDataDBEntities1 db = new LiftInstallationDataDBEntities1();
        static SearchViewModel currentSearchField=new SearchViewModel();//current search returned result
        SearchViewModel searchViewModel;

        ISearchService searchService=new SearchServiceImpl();

        

        // GET: Search
        public ActionResult CreateView()
        {
            searchViewModel = new SearchViewModel();
            currentSearchField = searchViewModel;
            searchViewModel.PagedSensorBoxInfo = searchService.LoadInitSearchPage();
            return View(searchViewModel);
        }

        [HttpPost]        
        public ActionResult SubmitSearch(SearchViewModel searchfield)
        {
            searchViewModel = new SearchViewModel();
            currentSearchField = searchfield;
            searchViewModel.PagedSensorBoxInfo= searchService.SearchByAllField(null,null, searchfield);  
            return PartialView("_SearchResult", searchViewModel.PagedSensorBoxInfo);                
            
        }

        [HttpGet]
        public ActionResult PagedResult(int? page, int? size)
        {
            searchViewModel = new SearchViewModel();
            searchViewModel.PagedSensorBoxInfo = searchService.SearchByAllField(page, size, currentSearchField);
            return PartialView("_SearchResult", searchViewModel.PagedSensorBoxInfo);           
        }



    }
}