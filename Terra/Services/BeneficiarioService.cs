using Npgsql;
using Terra.Utils;

namespace Terra.Services
{
    public class BeneficiarioTurnoService : IDoaMaisTerraService
    {
        public void AddBeneficiario(Beneficiario beneficiario)
        {
            DbConnector db = new();
            using var dataSource = db.GetDataSource();
            using var conn = dataSource.OpenConnection();
            //conn.Open();
            using var tx = conn.BeginTransaction();
            NpgsqlCommand query = new("INSERT INTO doamais.beneficiario (nome_representante, contacto, nacionalidade, dimensao_agregado) VALUES ($1, $2, $3, $4)", conn, tx)
            {
                Parameters =
                {
                    new() { Value = beneficiario.NomeRepresentante },
                    new() { Value = beneficiario.Contacto },
                    new() { Value = beneficiario.Nacionalidade },
                    new() { Value = beneficiario.DimensaoAgregado },
                }
            };
            query.ExecuteNonQuery();
            tx.Commit();
            conn.Close();
        }

        public void DeleteBeneficiario(int id)
        {
            DbConnector db = new();
            using var dataSource = db.GetDataSource();
            using var conn = dataSource.OpenConnection();
            using var tx = conn.BeginTransaction();
            NpgsqlCommand query = new("DELETE FROM doamais.beneficiario WHERE id = $1", conn, tx)
            {
                Parameters =
                {
                    new() { Value = id },
                }
            };
            query.ExecuteNonQuery();
            tx.Commit();
            conn.Close();
        }

        public void UpdateBeneficiario(Beneficiario beneficiario)
        {
            DbConnector db = new();
            using var dataSource = db.GetDataSource();
            using var conn = dataSource.OpenConnection();
            using var tx = conn.BeginTransaction();

            NpgsqlCommand query = new("UPDATE doamais.beneficiario SET nome_representante = $1, contacto = $2, nacionalidade = $3, dimensao_agregado = $4 WHERE id = $5", conn, tx)
            {
                Parameters =
                {
                    new() { Value = beneficiario.NomeRepresentante },
                    new() { Value = beneficiario.Contacto },
                    new() { Value = beneficiario.Nacionalidade },
                    new() { Value = beneficiario.DimensaoAgregado },
                    new() { Value = beneficiario.Id },
                }
            };
            query.ExecuteNonQuery();
            tx.Commit();
            conn.Close();
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
            Beneficiario? beneficiario;
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
