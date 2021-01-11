using System;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;
using ZemApp.Domain.Repository;

namespace ZemApp.Application.GenerateSampleData
{
    public interface ISampleDataUtil
    {
        void GenerateData();
        bool HasDataLoad();
    }

    public class SampleDataUtil : ISampleDataUtil
    {
        public readonly IUserRepository _userRepository;
        public readonly IPostRepository _postRepository;
        public readonly IRoleRepository _roleRepository;
        public readonly IPostStatusRepository _postStatusRepository;

        public SampleDataUtil(IUserRepository userRepository,
            IPostRepository postRepository,
            IRoleRepository roleRepository,
            IPostStatusRepository postStatusRepository
            )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _postRepository = postRepository;
            _postStatusRepository = postStatusRepository;
        }

        public bool HasDataLoad()
        {
            return _postRepository.GetPostByStateAsync(StatusEnum.Approve).Result.Count >0;
        }

        public void GenerateData()
        {
            Role roleWriter = new Role { Active = true, Rol_Name = "Writer" };
            Role roleEditor = new Role { Active = true, Rol_Name = "Editor" };

            _roleRepository.CreateRole(roleEditor);
            _roleRepository.CreateRole(roleWriter);

            User userWriter = new User { Active = true, FirstName = "Jhon", LastName = "Connor", Password = "AB1234", Username = "Jhon.connor@gmail.com", Role = roleWriter };
            User userEditor = new User { Active = true, FirstName = "T", LastName = "-1000", Password = "AB1234", Username = "terminator@gmail.com", Role = roleEditor };

            _userRepository.CreateUser(userWriter);
            _userRepository.CreateUser(userEditor);

            Post_Status post_Status_p = new Post_Status { Active = true, State = "Pending" };
            Post_Status post_Status_r = new Post_Status { Active = true, State = "Rejected" };
            Post_Status post_Status_d = new Post_Status { Active = true, State = "Done" };

            _postStatusRepository.CreatePostStatus(post_Status_p);
            _postStatusRepository.CreatePostStatus(post_Status_r);
            _postStatusRepository.CreatePostStatus(post_Status_d);

            Blog_Post blog_Post = new Blog_Post { Title = "Post A", Author = userWriter, Creation_Date = DateTime.Now, Update_Date = DateTime.Now, Post_Content = "<h2>The three greatest things you learn from traveling</h2><p>Like all the great things on earth traveling teaches us by example. Here are some of the most precious lessons I’ve learned over the years of traveling.</p>", State = StatusEnum.Approve, Active = true };
            Blog_Post blog_Post0 = new Blog_Post { Title = "Post A", Author = userWriter, Creation_Date = DateTime.Now, Update_Date = DateTime.Now, Post_Content = "<h3> Improvisation </h3><p> Life doesn't allow us to execute every single plan perfectly. This especially seems to be the case when you travel.&nbsp;</p>", State = StatusEnum.Approve, Active = true };
            Blog_Post blog_Post1 = new Blog_Post { Title = "Post B", Author = userWriter, Creation_Date = DateTime.Now, Update_Date = DateTime.Now, Post_Content = "Lorem Ipsum is simply dummy text of the printing and typesetting", State = StatusEnum.Pending, Active = true };
            Blog_Post blog_Post2 = new Blog_Post { Title = "Post C", Author = userEditor, Creation_Date = DateTime.Now, Update_Date = DateTime.Now, Post_Content = "Lorem Ipsum is simply dummy text of the printing and typesetting", State = StatusEnum.Rejected, Active = true };
            Blog_Post blog_Post3 = new Blog_Post { Title = "Post D", Author = userWriter, Creation_Date = DateTime.Now, Update_Date = DateTime.Now, Post_Content = "Lorem Ipsum is simply dummy text of the printing and typesetting", State = StatusEnum.Approve, Active = true };

            _postRepository.CreatePost(blog_Post);
            _postRepository.CreatePost(blog_Post0);
            _postRepository.CreatePost(blog_Post1);
            _postRepository.CreatePost(blog_Post2);
            _postRepository.CreatePost(blog_Post3);
        }
    }
}