using RM_WEB.Models;
using RM_WEB.WebMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RM_WEB.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(FormCollection collection)
        {
            var res1 = collection["lalala"];
            List<Models.Type> typeList = ServiceRepository.GetTypeList();
            IEnumerable<SelectListItem> sList = typeList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
            ViewData["ResType"] = sList;


            List<Models.ResourceModel> resourceList = ServiceRepository.GetResourceDetails();
            resourceList = resourceList.GroupBy(x => x.ResourceId).Select(g => g.First()).ToList();
            IEnumerable<SelectListItem> resList = resourceList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ResourceDisplayName,
                                      Value = x.ResourceId.ToString()
                                  }).ToList();
            ViewData["ResLst"] = resList;

            List<Tag> tagList = ServiceRepository.GetTagNamesDetails();
            IEnumerable<SelectListItem> tagLists = tagList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.TagName,
                                      Value = x.TagId.ToString()
                                  }).ToList();
            ViewData["TagLst"] = tagLists;            

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}