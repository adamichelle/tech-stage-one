using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace authors
{
    class Author
    {
        public int id { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public int submitted { get; set; }
        public int submission_count { get; set; }
        public int comment_count { get; set; }
        public DateTime updated_at { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime created_at { get; set; }
    }
}
