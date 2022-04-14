using JoaoDiasBlog.Entities;
using System.Data;
using System.Data.SqlClient;

namespace JoaoDiasBlog.Services
{
    public class PostService
    {
        private SqlConnection myConnection;
        SqlCommand? myCommand;

        public PostService(IConfiguration configuration)
        {
            ConnectionService connectionService = new ConnectionService(configuration);
            myConnection = connectionService.DbConnection();
        }

        public List<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            myCommand = new SqlCommand("select Post.*, [User].Username from Post left join [User] ON [User].UserId = Post.UserId", myConnection);
            myCommand.CommandType = CommandType.Text;
            IDataReader dataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Post post = new Post();
                post.PostId = dataReader["PostId"] is DBNull ? 0 : int.Parse(dataReader["PostId"].ToString() ?? string.Empty);
                post.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                post.Title = dataReader["Title"] is DBNull ? string.Empty : dataReader["Title"].ToString();
                post.Content = dataReader["Content"] is DBNull ? string.Empty : dataReader["Content"].ToString();

                if (dataReader["Publishing_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Publishing_Date"].ToString() ?? string.Empty);
                }

                if (dataReader["Modified_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Modified_Date"].ToString() ?? string.Empty);
                }

                var myUser = new User
                {
                    UserId = post.UserId,
                    UserName = dataReader["Username"] is DBNull
                        ? "This post has been deleted!"
                        : dataReader["Username"]
                            .ToString()
                };
                post.Writer = myUser;
                posts.Add(post);
            }

            return posts;
        }

        public Post Get(int id)
        {
            var post = new Post();

            const string mySqlQuery = "select Post.*, [User].Username from Post left join [User] ON [User].UserId = Post.UserId where Post.PostId =@id";
            myCommand = new SqlCommand(mySqlQuery, myConnection);
            myCommand.CommandType = CommandType.Text;
            myCommand.Parameters.AddWithValue("@id", id);
            IDataReader dataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                post.PostId = dataReader["PostId"] is DBNull ? 0 : int.Parse(dataReader["PostId"].ToString() ?? string.Empty);
                post.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                post.Title = dataReader["Title"] is DBNull ? string.Empty : dataReader["Title"].ToString();
                post.Content = dataReader["Content"] is DBNull ? string.Empty : dataReader["Content"].ToString();

                if (dataReader["Publishing_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Publishing_Date"].ToString() ?? string.Empty);
                }

                if (dataReader["Modified_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Modified_Date"].ToString() ?? string.Empty);
                }

                var myUser = new User
                {
                    UserId = post.UserId,
                    UserName = dataReader["Username"] is DBNull
                        ? "This post has been deleted!"
                        : dataReader["Username"]
                            .ToString()
                };
                post.Writer = myUser;
            }

            return post;


        }


        public bool Create(Post post)
        {
            bool result = false;
            string mySqlQuery = "insert into Post (UserId,Title,Content,Publishing_Date,Modified_Date) values (@UserId,@Title,@Content,@Publishing_Date,@Modified_Date)";
            myCommand = new SqlCommand(mySqlQuery, myConnection);
            myCommand.Parameters.AddWithValue("@UserId", post.UserId);
            myCommand.Parameters.AddWithValue("@Title", post.Title);
            myCommand.Parameters.AddWithValue("@Content", post.Content);
            myCommand.Parameters.AddWithValue("@Publishing_Date", post.Publishing_Date);
            myCommand.Parameters.AddWithValue("@Modified_Date", post.Modified_Date);
            int success = myCommand.ExecuteNonQuery();
            result = success == 0 ? false : true;
            return result;
        }


        public bool Update(Post post)
        {
            bool result = false;
            string mySqlQuery = "update Post set Title=@title,Content=@content,Modified_Date=@modified_date where PostId=@id";
            myCommand = new SqlCommand(mySqlQuery, myConnection);
            myCommand.Parameters.AddWithValue("@title", post.Title);
            myCommand.Parameters.AddWithValue("@content", post.Content);
            myCommand.Parameters.AddWithValue("@modified_date", post.Modified_Date);
            myCommand.Parameters.AddWithValue("@id", post.PostId);
            int success = myCommand.ExecuteNonQuery();
            result = success == 0 ? false : true;
            return result;
        }


        public bool Delete(int id)
        {
            bool result = false;
            string mySqlQuery = "delete from Post where PostId=@id";
            myCommand = new SqlCommand(mySqlQuery, myConnection);
            myCommand.Parameters.AddWithValue("@id", id);
            int success = myCommand.ExecuteNonQuery();
            result = success == 0 ? false : true;
            return result;
        }

        public bool Delete(Post post)
        {
            return Delete(post.PostId);
        }


        public List<Post> GetSearch(string q)
        {

            List<Post> posts = new List<Post>();
            myCommand = new SqlCommand(@$"select Post.*, [User].Username from Post left join [User] ON [User].UserId = Post.UserId
                where Post.Title like '%" + q + "%' or Post.Content like '%" + q + "%'", myConnection); ;
            myCommand.CommandType = CommandType.Text;
            IDataReader dataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Post post = new Post();
                post.PostId = dataReader["PostId"] is DBNull ? 0 : int.Parse(dataReader["PostId"].ToString() ?? string.Empty);
                post.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                post.Title = dataReader["Title"] is DBNull ? string.Empty : dataReader["Title"].ToString();
                post.Content = dataReader["Content"] is DBNull ? string.Empty : dataReader["Content"].ToString();

                if (dataReader["Publishing_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Publishing_Date"].ToString() ?? string.Empty);
                }

                if (dataReader["Modified_Date"] != DBNull.Value)
                {
                    post.Publishing_Date = DateTime.Parse(dataReader["Modified_Date"].ToString() ?? string.Empty);
                }

                User? myUser = new User
                {
                    UserId = post.UserId,
                    UserName = dataReader["Username"] is DBNull ? "This post has been deleted!" : dataReader["Username"].ToString()
                };
                post.Writer = myUser;
                posts.Add(post);
            }

            return posts;
        }
    }
}
