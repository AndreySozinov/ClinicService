using ClinicService.Models;
using System.Data.SQLite;

namespace ClinicService.Services.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        public int Create(Doctor item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = @"INSERT INTO Doctors(Surname, FirstName, Patronymic, Birthday) 
                                    VALUES(@Surname, @FirstName, @Patronymic, @Birthday)";
            command.Parameters.AddWithValue("@Surname", item.Surname);
            command.Parameters.AddWithValue("@FirstName", item.FirstName);
            command.Parameters.AddWithValue("@Patronymic", item.Patronymic);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Update(Doctor item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = @"UPDATE Doctors SET 
                                    Surname = @Surname, 
                                    FirstName = @FirstName, 
                                    Patronymic = @Patronymic, 
                                    Birthday = @Birthday
                                    WHERE DoctorId = @DoctorId";
            command.Parameters.AddWithValue("@DoctorId", item.DoctorId);
            command.Parameters.AddWithValue("@Surname", item.Surname);
            command.Parameters.AddWithValue("@FirstName", item.FirstName);
            command.Parameters.AddWithValue("@Patronymic", item.Patronymic);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM Doctors WHERE DoctorId = @DoctorId";
            command.Parameters.AddWithValue("@DoctorId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<Doctor> GetAll()
        {
            List<Doctor> list = new List<Doctor>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Doctors";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = reader.GetInt32(0);
                doctor.Surname = reader.GetString(1);
                doctor.FirstName = reader.GetString(2);
                doctor.Patronymic = reader.GetString(3);
                doctor.Birthday = new DateTime(reader.GetInt64(4));

                list.Add(doctor);
            }

            connection.Close();
            return list;
        }

        public Doctor GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Doctors WHERE DoctorId = @DoctorId";
            command.Parameters.AddWithValue("@DoctorId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DoctorId = reader.GetInt32(0);
                doctor.Surname = reader.GetString(1);
                doctor.FirstName = reader.GetString(2);
                doctor.Patronymic = reader.GetString(3);
                doctor.Birthday = new DateTime(reader.GetInt64(4));

                connection.Close();
                return doctor;
            }
            else
            {
                connection.Close();
                return null;
            }



        }
    }
}
