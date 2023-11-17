using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMArT.Controllers
{
    using System.Configuration;
    using System.IO;
    using System.Net;
    using Contract;
    using Helpers;
    using Integrations;
    using Microsoft.Ajax.Utilities;
    using Models;
    using Newtonsoft.Json;

    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            var model = SearchViewModelHelper.GetModel();
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReportbyService(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                var jrl = new JiraIntegration();
                var rootObject = jrl.LoadData(searchModel.To());
                var viewModel = new ChartViewModel
                {
                    series = new List<Series>
                    {
                        new Series
                        {
                            colorByPoint = true,
                            name = "Services",
                            data = new List<DataPoint>()
                        }
                    }
                };

                var components = rootObject.Issues.SelectMany(x => x.Fields.Components.Select(y => y.Name));
                var distComponents = components.Distinct().ToArray();
                for (var i = 0; i < distComponents.Count(); i++)
                {
                    var notickets =
                        rootObject.Issues.Count(
                            x => x.Fields.Components.Any(y => y.Name.Equals(distComponents[i])));
                    viewModel.series[0].data.Add(new DataPoint {name = distComponents[i], y = notickets});
                }
                viewModel.series[0].data = viewModel.series[0].data.OrderByDescending(x => x.y).ToList();

                viewModel.series[0].data[0].selected = true;
                viewModel.series[0].data[0].sliced = true;


                return Json(new Result<ChartViewModel>{ Success = true, Object = viewModel }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Result<object> { Success = false, ErrorMessage = "Invalid request"}, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Reports()
        {

            return View();
        }
    }
}