
using ClinicService.Services;
using ClinicService.Services.Implementation;
using System.Data.SQLite;

namespace ClinicService
{
    public class Program
    {
        /// https://sqlitestusio.pl
        /// https://www.sqlite.org
        public static void Main(string[] args)
        {
            //ConfigureSqliteConnection();


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(config =>
            {
                config.EnableAnnotations();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        /// <summary>
        /// connectionString - строка соединения с БД
        /// </summary>
        private static void ConfigureSqliteConnection()
        {
            string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private static void PrepareSchema(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = "DROP TABLE IF EXISTS Consultations";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Pets";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Clients";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Doctors";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Treatments";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Clients(
                ClientId INTEGER PRIMARY KEY,
                Document TEXT,
                Surname TEXT,
                FirstName TEXT,
                Patronymic TEXT,
                Birthday INTEGER)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Pets(
                PetId INTEGER PRIMARY KEY,
                ClientId INTEGER,
                Name TEXT,
                Kind TEXT,
                Age INTEGER)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Consultations(
                ConsultationId INTEGER PRIMARY KEY,
                ClientId INTEGER,
                PetId INTEGER,
                ConsultationDate INTEGER,
                Description TEXT)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Doctors(
                DoctorId INTEGER PRIMARY KEY,
                Surname TEXT,
                FirstName TEXT,
                Patronymic TEXT,
                Birthday INTEGER)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE Treatments(
                TreatmentId INTEGER PRIMARY KEY,
                ConsultationId INTEGER,
                DoctorId INTEGER,
                Prescription TEXT,
                Price INTEGER)";
            command.ExecuteNonQuery();
        }
    }
}