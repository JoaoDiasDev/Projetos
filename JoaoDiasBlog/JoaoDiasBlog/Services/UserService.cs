using JoaoDiasBlog.Entities;
using System.Data;
using System.Data.SqlClient;

namespace JoaoDiasBlog.Services
{
    public class UserService
    {
        private readonly SqlConnection _myConnection;
        private SqlCommand? _myCommand;


        public UserService(IConfiguration configuration)
        {
            ConnectionService connectionService = new ConnectionService(configuration);
            _myConnection = connectionService.DbConnection();
        }


        public User Get(int id)
        {
            User myUser = new User();
            string mySqlQuery = "select * from [user] where UserId = @id";
            _myCommand = new SqlCommand();
            _myCommand.CommandText = mySqlQuery;
            _myCommand.Connection = _myConnection;
            _myCommand.CommandType = CommandType.Text;
            _myCommand.Parameters.AddWithValue("@id", id);
            IDataReader dataReader = _myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                myUser.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                myUser.UserName = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                myUser.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();
            }

            return myUser;

        }


        public List<User> GetAll()
        {

            List<User> users = new List<User>();

            string mySqlQuery = "select * from [User]";
            _myCommand = new SqlCommand(mySqlQuery, _myConnection);
            _myCommand.CommandType = CommandType.Text;
            IDataReader dataReader = _myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                User myUser = new User();
                myUser.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                myUser.UserName = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                myUser.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();
                users.Add(myUser);
            }
            return users;
        }


        public User Login(User user)
        {
            return Login(user.UserName, user.Password);
        }

        public User Login(string? username, string? password)
        {
            User myUser = new User();
            string mySqlQuery = "select * from [User] where Username = @username and Password = @password";
            _myCommand = new SqlCommand(mySqlQuery, _myConnection);
            _myCommand.Parameters.AddWithValue("@username", username);
            _myCommand.Parameters.AddWithValue("@password", password);
            IDataReader dataReader = _myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {

                myUser.UserId = dataReader["UserId"] is DBNull ? 0 : int.Parse(dataReader["UserId"].ToString() ?? string.Empty);
                myUser.UserName = dataReader["Username"] is DBNull ? string.Empty : dataReader["Username"].ToString();
                myUser.Password = dataReader["Password"] is DBNull ? string.Empty : dataReader["Password"].ToString();

            }
            return myUser;
        }
    }
}
