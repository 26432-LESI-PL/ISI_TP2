using Microsoft.AspNetCore.Mvc;

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
            return
            [
                new() {
                    Id = 1,
                    NomeRepresentante = "João",
                    Contacto = "912345678",
                    DimensaoAgregado = 3
                },
                new() {
                    Id = 2,
                    NomeRepresentante = "Maria",
                    Contacto = "912345678",
                    DimensaoAgregado = 4
                }
            ];
        }

        public Beneficiario GetBeneficiarioById(int id)
        {
            throw new NotImplementedException();
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
    }
}
