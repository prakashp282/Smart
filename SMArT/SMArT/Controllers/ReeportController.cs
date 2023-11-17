using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMArT.Controllers
{
    using Helpers;
    using Integrations;
    using Models;

    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            var model = SearchViewModelHelper.GetModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ReportByCustomer(SearchModel searchModel)
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
                            name = "Lumina Impacted clients",
                            data = new List<DataPoint>()
                        }
                    }
                };

                var clients = rootObject.Issues.SelectMany(x => x.Fields.Customfield.Select(y => y.Value));
                var distClients = clients.Distinct().ToArray();
                for (var i = 0; i < distClients.Count(); i++)
                {
                    var notickets =
                        rootObject.Issues.Count(
                            x => x.Fields.Customfield.Any(y => y.Value.Equals(distClients[i])));
                    viewModel.series[0].data.Add(new DataPoint { name = distClients[i], y = notickets });

                }
                viewModel.series[0].data = viewModel.series[0].data.OrderByDescending(x => x.y).ToList();

                viewModel.series[0].data[0].selected = true;
                viewModel.series[0].data[0].sliced = true;

                return Json(new Result<ChartViewModel> { Success = true, Object = viewModel }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Result<object> { Success = false, ErrorMessage = "Invalid request" }, JsonRequestBehavior.AllowGet);

        }
    }
}