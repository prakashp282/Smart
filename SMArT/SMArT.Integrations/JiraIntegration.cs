using System;
using System.Configuration;

namespace SMArT.Integrations
{
    using System.IO;
    using System.Net;
    using Contract;
    using Contract.Dtos;
    using Newtonsoft.Json;

    public class JiraIntegration
    {
        public RootObject LoadData(SearchModelDto searchModel)
        {
            var jiraUrl = ConfigurationManager.AppSettings["JIRAUrl"].ToString();
            if (!string.IsNullOrWhiteSpace(searchModel.SelectedProject))
            {
                jiraUrl += "project = '" + searchModel.SelectedProject + "' AND ";
            }
            if (!string.IsNullOrWhiteSpace(searchModel.SelectedIssueType))
            {
                jiraUrl += "issuetype in ('" + searchModel.SelectedIssueType + "') AND ";
            }
            if (searchModel.StartDate != DateTime.MinValue && searchModel.EndDate != DateTime.MinValue)
            {
                jiraUrl += "(createdDate >='" + searchModel.StartDate.ToString("yyyy-MM-dd") +
                           "' AND createdDate <= '" +
                           searchModel.EndDate.ToString("yyyy-MM-dd") + "')";
            }
            jiraUrl += "&startAt=0&maxResults=500";
            jiraUrl +=
                "&fields=key,issuetype,summary,assignee,reporter,labels,priority,status,fixversions,created,updated,resolutiondate,components,customfield_12922,customfield_19921";

            var auth = $"{searchModel.UserName}:{searchModel.Password}";

            var response1 = string.Empty;
            var request = WebRequest.Create(jiraUrl) as HttpWebRequest;
            request.ContentType = "application/json";
            var encodedAuth = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(auth));
            request.Headers.Add("Authorization", "Basic " + encodedAuth);
            try
            {
                var webResponse = request.GetResponse() as HttpWebResponse;
                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    response1 = reader.ReadToEnd();
                    // Response.Write("<script LANGUAGE='JavaScript' >alert('Record added Successful')</script>");

                    var result = JsonConvert.DeserializeObject<RootObject>(response1);
                    return result;
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}
