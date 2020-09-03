using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace authors
{
    public class AuthorsLib
    {
        private static readonly string apiUrl = "https://jsonmock.hackerrank.com/api/article_users/search?page=";

        public static List<string> GetUsernames(int threshold)
        {
            var allAuthors = GetAllAuthors(apiUrl, 1).Result;
            if(allAuthors == null)
            {
                return null;
            }
            var activeAuthors = allAuthors.OrderByDescending(a => a.submission_count).Select(a => a.username).Take(threshold).ToList();

            return activeAuthors;
        }

        public static string GetUsernameWithHighestCommentCount()
        {
            var allAuthors = GetAllAuthors(apiUrl, 1).Result;
            if(allAuthors == null)
            {
                return null;
            }
            var authorWithHighestCommentCount = allAuthors.Aggregate((result, item) => result.comment_count > item.comment_count ? result : item);

            return authorWithHighestCommentCount.username;
        }

        public static List<string> GetUsernamesSortedByRecordDate(int threshold)
        {
            var allAuthors = GetAllAuthors(apiUrl, 1).Result;

            if (allAuthors == null)
            {
                return null;
            }

            var authorsByRecordDate = allAuthors.OrderBy(a => a.created_at).Select(a => a.username).Take(threshold).ToList();

            return authorsByRecordDate;
        }

        private static async Task<List<Author>> GetAllAuthors(string apiUrl, int pageNumber, List<Author> authors = null)
        {
            try
            {
                string urlToGet = apiUrl + pageNumber.ToString();
                

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlToGet);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(urlToGet);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var totalNoOfPagesInfo = JObject.Parse(responseContent)["total_pages"];
                        int totalNoOfPages = totalNoOfPagesInfo.ToObject<int>();

                        var data = JObject.Parse(responseContent)["data"];
                        var result = data.ToObject<List<Author>>();
                        if (authors == null)
                        {
                            authors = result;
                        }

                        if (pageNumber < totalNoOfPages + 1)
                        {
                            pageNumber++;
                            if (pageNumber == totalNoOfPages + 1)
                            {
                                authors.AddRange(result);
                                return authors;
                            }
                            else
                            {
                                await GetAllAuthors(apiUrl, pageNumber, authors);
                            }
                        }

                        return authors;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
