using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;
using ZemApp.Domain.Services;

namespace ZemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostAppService _blogPostAppService;
        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(IBlogPostAppService blogPostAppService, ILogger<BlogPostController> logger)
        {
            _blogPostAppService = blogPostAppService;
            _logger = logger;
        }

        /// <summary>
        /// Return Pending Post
        /// </summary>
        [HttpGet]
        [Route("query")]
        public List<Blog_PostDTO> GetPendingPost()
        {
            return _blogPostAppService.GetPendingBlogPost();
        }

        [HttpGet]
        [Route("queryByState")]
        public List<Blog_PostDTO> GetPostByState(string state)
        {
            return _blogPostAppService.GetPendingBlogPostbyState((StatusEnum)Enum.Parse(typeof(StatusEnum), state));
        }

        [HttpPut]
        [Route("approval")]
        public void UpdatePost(string id)
        {
            _blogPostAppService.UpdatePostState(id, StatusEnum.Approve.ToString());
        }

        [HttpPut]
        [Route("updateState")]
        [Authorize(Role = "Editor")]
        public void UpdatePostState(string id, [FromBody] UpdateState update)
        {
            _blogPostAppService.UpdatePostState(id, update.State);
        }

        [HttpPut]
        [Route("updateContent")]
        [Authorize(Role = "Writer")]
        public void UpdatePostContent(string id, [FromBody] string value)
        {
            _blogPostAppService.UpdatePostContent(id, value);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Role = "Writer")]
        public void AddPost(ZemApp.Domain.Entities.AddPostDto value)
        {
            _blogPostAppService.AddPost(value);
        }

        [HttpPost]
        [Route("delete")]
        [Authorize(Role = "Editor")]
        public void deletePost(string id)
        {
            _blogPostAppService.DeletePost(id);
        }
    }
}