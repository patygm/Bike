
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Bike.Models
{
    public class BicicletaRepository : IBicicletaRepository
    {
        private BicicletaDbContext _context;
        

        public BicicletaRepository(BicicletaDbContext ctx) {
            _context = ctx;
        }

        public IEnumerable<Bicicleta> GetBike()
        {
            return _context.Bicicletas.ToList();
        }

        public Bicicleta GetBikePorID(int id)
        {
            return _context.Bicicletas.Find(id);
        }

        public void InserirBike(Bicicleta bicicleta)
        {
           _context.Bicicletas.Add(bicicleta);
        }

        public void DeletarBike(int BicicletaId)
        {
            Bicicleta bicicleta = _context.Bicicletas.Find(BicicletaId);
            _context.Bicicletas.Remove(bicicleta);
        }

        public void AtualizaBike(Bicicleta bicicleta)
        {
            _context.Entry(bicicleta).State = EntityState.Modified;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public IQueryable<Bicicleta> Bicicletas => _context.Bicicletas;
    }
}
