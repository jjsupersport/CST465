using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Assignment3;
using Microsoft.Extensions.Configuration;
using Assignment3Namespace.DataModels;

namespace Assignment3Namespace.Repositories
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        private readonly IConfiguration _Config;

        public BlogDBRepository(IConfiguration configuration)
        {
            _Config = configuration;
        }

        public List<BlogPost> GetAll()
        {
            var posts = new List<BlogPost>();
            using (var connection = new SqlConnection(_Config["ConnectionStrings:DB_BlogPosts"]))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM BlogPost", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new BlogPost
                            {
                                ID = reader.GetInt32(0),
                                Author = reader.GetString(1),
                                Title = reader.GetString(2),
                                Content = reader.GetString(3),
                                Timestamp = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return posts;
        }

        public void Save(BlogPost post)
        {
            using (var connection = new SqlConnection(_Config["ConnectionStrings:DB_BlogPosts"]))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO BlogPosts (Author, Title, Content, Timestamp) VALUES (@Author, @Title, @Content, @Timestamp)", connection);
                command.Parameters.AddWithValue("@Author", post.Author);
                command.Parameters.AddWithValue("@Title", post.Title);
                command.Parameters.AddWithValue("@Content", post.Content);
                command.Parameters.AddWithValue("@Timestamp", post.Timestamp);
                command.ExecuteNonQuery();
            }
        }

        public BlogPost GetById(int id)
        {
            BlogPost post = null;
            using (var connection = new SqlConnection(_Config["ConnectionStrings:DB_BlogPosts"]))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM BlogPost WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        post = new BlogPost
                        {
                            ID = reader.GetInt32(0),
                            Author = reader.GetString(1),
                            Title = reader.GetString(2),
                            Content = reader.GetString(3),
                            Timestamp = reader.GetDateTime(4)
                        };
                    }
                }
            }
            return post;
        }

        public BlogPost Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
