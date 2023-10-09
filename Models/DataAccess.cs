using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PFSSITEWITHOUTENTITY.Models
{
    public class ClassDataAccess
    {
        private readonly IConfiguration _configuration;
        string _connectionString = "";
        public ClassDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PFSSITEDB");
        }

        public List<Class> GetAllClasses()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Class c inner join Session s on c.SessionId=s.SessionId", connection);
                using (var reader = command.ExecuteReader())
                {
                    var data = new List<Class>();

                    while (reader.Read())
                    {
                        var obj = new Class();
                        obj.ClassId = Convert.ToInt32(reader["ClassId"]);
                        obj.ClassName = reader["ClassName"].ToString();
                        obj.Description = reader["Description"].ToString();
                        obj.Session = reader["SessionName"].ToString();
                        data.Add(obj); // Change this to match your table schema.
                    }

                    return data;
                }
            }
        }
        public Class GetClass(int? ClassId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using var command = new SqlCommand("SELECT * FROM Class c inner join Session s on c.SessionId=s.SessionId where c.ClassId=" + ClassId, connection);
                using (var reader = command.ExecuteReader())
                {
                    var objClass = new Class();
                    while (reader.Read())
                    {
                        objClass.ClassId = Convert.ToInt32(reader["ClassId"]);
                        objClass.ClassName = reader["ClassName"].ToString();
                        objClass.Description = reader["Description"].ToString();
                        objClass.Session = reader["SessionName"].ToString();
                        objClass.SessionId = Convert.ToInt32(reader["SessionId"]);
                    }
                    return objClass;
                }
            }
        }
        public Class CreateClass(Class objClass)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("Insert into Class(ClassName,SessionId,Description)Values('" + objClass.ClassName + "'," + objClass.SessionId + ",'"+objClass.Description+"')", connection);
            command.ExecuteNonQuery();
            connection.Close();

            return objClass;
        }
        public Class UpdateClass(Class objClass)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("Update Class set ClassName='" + objClass.ClassName + "',SessionId =" + objClass.SessionId + ",Description='"+objClass.Description+"' where ClassId=" + objClass.ClassId, connection);
            command.ExecuteNonQuery();
            connection.Close();

            return objClass;
        }
        public List<Session> GetSessions()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Session", connection);
                using (var reader = command.ExecuteReader())
                {
                    var SessionList = new List<Session>();
                    while (reader.Read())
                    {
                        var objSession = new Session();
                        objSession.SessionId = Convert.ToInt32(reader["SessionId"]);
                        objSession.SessionName = reader["SessionName"].ToString();
                        SessionList.Add(objSession);
                    }
                    return SessionList;
                }
            }
        }
        public void DeleteClass(int? ClassId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("Delete FROM Class where ClassId=" + ClassId, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        // Add more methods for CRUD operations as needed.
    }
}
