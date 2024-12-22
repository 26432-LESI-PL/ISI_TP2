using Npgsql;
using Terra.Utils;

namespace Terra.Services
{
    public class BeneficiarioTurnoService : IDoaMaisTerraService
    {
        public void AddBeneficiario(Beneficiario beneficiario)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeneficiario(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeneficiario(Beneficiario beneficiario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beneficiario> GetAllBeneficiarios()
        {
            DbConnector db = new();
            List<Beneficiario> beneficiarios = [];

            using var dataSource = db.GetDataSource();

            using (var cmd = dataSource.CreateCommand("SELECT id, nome_representante, contacto, nacionalidade, dimensao_agregado FROM doamais.beneficiario"))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    beneficiarios.Add(new Beneficiario
                    {
                        Id = reader.GetInt32(0),
                        NomeRepresentante = reader.GetString(1),
                        Contacto = reader.GetString(2),
                        Nacionalidade = reader.GetString(3),
                        DimensaoAgregado = reader.GetInt32(4)
                    });
                }
            }

            return beneficiarios;
        }
        public Beneficiario GetBeneficiarioById(int id)
        {
            DbConnector db = new();
            Beneficiario? beneficiario = null;

            using var dataSource = db.GetDataSource();
            using var conn = dataSource.OpenConnection();
            using var cmd = new NpgsqlCommand("SELECT id, nome_representante, contacto, nacionalidade, dimensao_agregado FROM doamais.beneficiario WHERE id = $1", conn)
            {
                Parameters =
                {
                    new() { Value = id },
                }
            };
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                beneficiario = new Beneficiario
                {
                    Id = reader.GetInt32(0),
                    NomeRepresentante = reader.GetString(1),
                    Contacto = reader.GetString(2),
                    Nacionalidade = reader.GetString(3),
                    DimensaoAgregado = reader.GetInt32(4)
                };
            }
            else
            {
                // No data found, handle accordingly
                throw new Exception("Beneficiario not found");
            }
            
            conn.Close();
           

            return beneficiario;
        }

        public void AddTurno(Turno turno)
        {
            throw new NotImplementedException();
        }

        public void DeleteTurno(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Turno> GetAllTurnos()
        {
            throw new NotImplementedException();
        }


        public Turno GetTurnoById(int id)
        {
            throw new NotImplementedException();
        }


        public void UpdateTurno(Turno turno)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beneficiario> GetAllBeneficiariosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
