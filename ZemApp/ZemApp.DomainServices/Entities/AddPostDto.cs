using System;
using System.Collections.Generic;
using System.Text;

namespace ZemApp.Domain.Entities
{
    public class AddPostDto
    {
        public string AuthorId { get; set; }
        public string Post_Content { get; set; }
        public string Title { get; set; }
    }
}
