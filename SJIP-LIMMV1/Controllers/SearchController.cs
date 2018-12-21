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
using System.Collections;
using System.Threading;

namespace SJIP_LIMMV1.Controllers
{
    public class SearchController : Controller
    {        
        static SearchViewModel currentSearchField=new SearchViewModel();//current search returned result
        SearchViewModel searchViewModel;
        ISearchService searchService=new SearchServiceImpl();        

        // GET: Search
        public async Task<ActionResult> CreateView()
        {
            searchViewModel = new SearchViewModel();
            ViewBag.InitPagedList =await searchService.LoadInitSearchPageAsync();    
            currentSearchField = searchViewModel;           
            return View(searchViewModel);
        }

        [HttpPost]        
        public async Task<ActionResult> SubmitSearch(SearchViewModel searchfield)
        {
            searchViewModel = new SearchViewModel();
            currentSearchField = searchfield;
            searchViewModel.PagedSensorBoxInfo=await searchService.SearchByAllFieldAsync(null,null, searchfield);  
            return PartialView("_SearchResult", searchViewModel.PagedSensorBoxInfo);            
        }

        [HttpGet]
        public async Task<ActionResult> PagedResult(int? page, int? size)
        {
            searchViewModel = new SearchViewModel();
            searchViewModel.PagedSensorBoxInfo =await  searchService.SearchByAllFieldAsync(page, size, currentSearchField);
            return PartialView("_SearchResult", searchViewModel.PagedSensorBoxInfo);           
        }

        [HttpGet]
        public async Task<JsonResult> GetInfoById(int id)
        {
            List<SearchDTO> result  =await searchService.FindByIDAsync(id);
            SearchDTO model = result.First();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> LoadAutocompleteData()
        {
            List<SearchDTO> modelList = await searchService.LoadAllAsync();           
            String[] arr = Helper.SearchHelper.ConvertListSearchDTOtoStringList(modelList);            
            return Json(arr, JsonRequestBehavior.AllowGet);
        }
    }
}