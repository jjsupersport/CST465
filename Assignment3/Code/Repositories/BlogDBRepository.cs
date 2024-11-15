using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
                                ID = (int)reader["ID"],
                                Author = reader["Author"].ToString(),
                                Title = reader["Title"].ToString(),
                                Content = reader["Content"].ToString(),
                                Timestamp = DateTime.Parse(reader["Timestamp"].ToString())
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
                var command = new SqlCommand("BlogPost_InsertUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                if(post.ID != 0) { command.Parameters.AddWithValue("@ID", post.ID); }
                command.Parameters.AddWithValue("@Author", post.Author);
                command.Parameters.AddWithValue("@Title", post.Title);
                command.Parameters.AddWithValue("@Content", post.Content);
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
                            ID = (int)reader["ID"],
                            Author = reader["Author"].ToString(),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            Timestamp = DateTime.Parse(reader["Timestamp"].ToString())                  
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
