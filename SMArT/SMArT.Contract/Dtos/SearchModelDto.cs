namespace SMArT.Contract.Dtos
{
    using System;

    public class SearchModelDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SelectedProject { get; set; }
        public string SelectedIssueType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}