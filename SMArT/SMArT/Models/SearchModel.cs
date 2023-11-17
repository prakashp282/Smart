using System;
using System.Collections.Generic;

namespace SMArT.Models
{
    using SMArT.Contract.Dtos;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SearchModel
    {
        public SearchModel()
        {
            Projects = new List<SelectListItem>();
            IssueTypes = new List<SelectListItem>();
        }

        [DisplayName("User name")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        public List<SelectListItem> Projects { get; set; }

        [DisplayName("Project")]
        [Required]
        public string SelectedProject { get; set; }
        public List<SelectListItem> IssueTypes { get; set; }

        [DisplayName("Issue Type")]
        [Required]
        public string SelectedIssueType { get; set; }

        [DisplayName("Start Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public SearchModelDto To()
        {
            return new SearchModelDto
            {
                UserName = this.UserName,
                Password = this.Password,
                SelectedProject = this.SelectedProject,
                SelectedIssueType = this.SelectedIssueType,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };
        }
    }
}