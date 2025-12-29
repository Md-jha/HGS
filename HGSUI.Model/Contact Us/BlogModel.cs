using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HGS.Model
{
    
    
        public class BlogModel
        {
            public int BlogId { get; set; }
            public string AuthorName { get; set; }
            public string BlogTopic { get; set; }
            public IFormFile BlogImage { get; set; }
            public string BlogImageUrl { get; set; }
            public string BlogContent { get; set; }
            public string BlogContentData { get; set; }
            public string BlogContentDataSepration { get; set; }
            public DateTime PostedDate { get; set; }
            public string MetaDescreption { get; set; }
            public string MetaTags { get; set; }
            public string NewBlogtopic { get; set; }
        }

        public class BlogViewModel
        {
            public BlogViewModel()
            {
                BlogList = new List<BlogModel>();
            }
            public List<BlogModel> BlogList { get; set; }
            public int BlogId { get; set; }
            public string AuthorName { get; set; }
            public string BlogTopic { get; set; }
            public IFormFile BlogImage { get; set; }
            public string BlogImageUrl { get; set; }
            public string BlogContent { get; set; }
            public string BlogContentData { get; set; }
            public string BlogContentDataSepration { get; set; }
            public DateTime PostedDate { get; set; }
            public string MetaDescreption { get; set; }
            public string MetaTags { get; set; }
            public string NewBlogtopic { get; set; }
        }
    
}
