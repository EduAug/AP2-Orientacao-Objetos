using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP2_Refatorar_Estacionamento
{
    public class MotoRepository : IMotoRepository
    {
        
        private readonly DataContext dcontext;

        public MotoRepository(DataContext cntxt)
        {

            this.dcontext = cntxt;
        }
        // -------------------------
        public Moto GetById(int entityId)
        {

            return dcontext.Motos.SingleOrDefault(b => b.Id == entityId);
        }
        public Moto GetByPlaca(string placa)
        {

            return dcontext.Motos.SingleOrDefault(e=>e.Placa==placa);
        }
        public IList<Moto> GetAll()
        {

            return dcontext.Motos.ToList();
        }
        // ---------------------------
        public void Save(Moto entity)
        {

            dcontext.Add(entity);
            dcontext.SaveChanges();
        }

        public void Update(Moto newEntity)
        {

            dcontext.Motos.Update(newEntity);
            dcontext.SaveChanges();
        }

        public void Delete(int entityId)
        {

            var toDelete = GetById(entityId);

            dcontext.Remove(toDelete);
            dcontext.SaveChanges();
        }
    }
}