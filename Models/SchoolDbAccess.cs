using MySql.Data.MySqlClient;


namespace MySchoolAPI.Models
{
    public class SchoolDbAccess
    {
        private string connectionString = "server=localhost;user=root;password=;database=MySchoolDB";

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Teachers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    teachers.Add(new Teacher
                    {
                        TeacherId = reader.GetInt32("teacherid"),
                        TeacherFname = reader.GetString("teacherfname"),
                        TeacherLname = reader.GetString("teacherlname"),
                        EmployeeNumber = reader.GetString("employeenumber"),
                        HireDate = reader.GetDateTime("hiredate"),
                        Salary = reader.GetDecimal("salary")
                    });
                }
            }

            return teachers;
        }

        public Teacher? GetTeacherById(int id)
        {
            Teacher? teacher = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Teachers WHERE teacherid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    teacher = new Teacher
                    {
                        TeacherId = reader.GetInt32("teacherid"),
                        TeacherFname = reader.GetString("teacherfname"),
                        TeacherLname = reader.GetString("teacherlname"),
                        EmployeeNumber = reader.GetString("employeenumber"),
                        HireDate = reader.GetDateTime("hiredate"),
                        Salary = reader.GetDecimal("salary")
                    };
                }
            }
            return teacher;
        }

        public void AddTeacher(Teacher teacher)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Teachers (teacherfname, teacherlname, employeenumber, hiredate, salary)
                                 VALUES (@fname, @lname, @empno, @hiredate, @salary)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fname", teacher.TeacherFname);
                cmd.Parameters.AddWithValue("@lname", teacher.TeacherLname);
                cmd.Parameters.AddWithValue("@empno", teacher.EmployeeNumber);
                cmd.Parameters.AddWithValue("@hiredate", teacher.HireDate);
                cmd.Parameters.AddWithValue("@salary", teacher.Salary);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacher(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Teachers WHERE teacherid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
