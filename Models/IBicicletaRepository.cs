using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bike.Models
{
    public interface IBicicletaRepository : IDisposable
    {
        IEnumerable<Bicicleta> GetBike();
        Bicicleta GetBikePorID(int BicicletaId);
        void InserirBike(Bicicleta bike);
        void DeletarBike(int BicicletaId);
        void AtualizaBike(Bicicleta bike);
        void Salvar();
    }
}
