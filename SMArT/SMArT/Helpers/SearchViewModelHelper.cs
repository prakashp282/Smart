using System;
using System.Collections.Generic;

namespace SMArT.Helpers
{
    using System.Web.Mvc;
    using Models;

    public static class SearchViewModelHelper
    {
        public static SearchModel GetModel()
        {
            var projects = new List<SelectListItem>
            {
                new SelectListItem {Text = "Lumina", Value = "LUM"},
                new SelectListItem {Text = "Prisma", Value = "IAPP"}
            };

            var issueTypes = new List<SelectListItem>
            {
                new SelectListItem {Text = "Support Ticket", Value = "Support Ticket"},
                new SelectListItem {Text = "Configuration", Value = "Configuration"},
                new SelectListItem {Text = "Bug", Value = "Bug"},
                new SelectListItem {Text = "Story", Value = "Story"}
            };

            var seachModel = new SearchModel
            {
                Projects = projects,
                IssueTypes = issueTypes,
                StartDate = DateTime.Now.Date.AddDays(-10),
                EndDate = DateTime.Now.Date,
            };

            return seachModel;
        }

    }   
}