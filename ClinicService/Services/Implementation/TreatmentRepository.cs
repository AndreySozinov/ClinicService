using ClinicService.Models;
using System.Data.SQLite;

namespace ClinicService.Services.Implementation
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(Treatment item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = @"INSERT INTO Treatments(ConsultationId, DoctorId, Prescription, Price) 
                                    VALUES(@ConsultationId, @DoctorId, @Prescription, @Price)";
            command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
            command.Parameters.AddWithValue("@DoctorId", item.DoctorId);
            command.Parameters.AddWithValue("@Prescription", item.Prescription);
            command.Parameters.AddWithValue("@Price", item.Price);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Update(Treatment item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = @"UPDATE Treatments SET 
                                    ConsultationId = @ConsultationId, 
                                    DoctorId = @DoctorId, 
                                    Prescription = @Prescription, 
                                    Price = @Price
                                    WHERE TreatmentId = @TreatmentId";
            command.Parameters.AddWithValue("@TreatmentId", item.TreatmentId);
            command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
            command.Parameters.AddWithValue("@DoctorId", item.DoctorId);
            command.Parameters.AddWithValue("@Prescription", item.Prescription);
            command.Parameters.AddWithValue("@Price", item.Price);
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
            command.CommandText = "DELETE FROM Treatments WHERE TreatmentId = @TreatmentId";
            command.Parameters.AddWithValue("@TreatmentId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<Treatment> GetAll()
        {
            List<Treatment> list = new List<Treatment>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Treatments";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Treatment treatment = new Treatment();
                treatment.TreatmentId = reader.GetInt32(0);
                treatment.ConsultationId = reader.GetInt32(1);
                treatment.DoctorId = reader.GetInt32(2);
                treatment.Prescription = reader.GetString(3);
                treatment.Price = reader.GetInt32(4);

                list.Add(treatment);
            }

            connection.Close();
            return list;
        }

        public Treatment GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Treatments WHERE TreatmentId = @TreatmentId";
            command.Parameters.AddWithValue("@TreatmentId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Treatment treatment = new Treatment();
                treatment.TreatmentId = reader.GetInt32(0);
                treatment.ConsultationId = reader.GetInt32(1);
                treatment.DoctorId = reader.GetInt32(2);
                treatment.Prescription = reader.GetString(3);
                treatment.Price = reader.GetInt32(4);

                connection.Close();
                return treatment;
            }
            else
            {
                connection.Close();
                return null;
            }
        }
    }
}
