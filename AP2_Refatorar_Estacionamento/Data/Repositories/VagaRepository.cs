using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP2_Refatorar_Estacionamento
{
    public class VagaRepository : IVagaRepository
    {

        private readonly DataContext dcontext;

        public VagaRepository(DataContext ctxt)
        {

            this.dcontext = ctxt;
        }
        

        public Vaga GetById(int entityId)
        {

            return dcontext.Vagas.SingleOrDefault(c => c.Id == entityId);
        }
        public IList<Vaga> GetAll()
        {

            return dcontext.Vagas.ToList();
        }


        public void Save(Vaga entity)
        {

            dcontext.Add(entity);
            dcontext.SaveChanges();
        }
        public void Update(Vaga newEntity)
        {

            dcontext.Vagas.Update(newEntity);
            dcontext.SaveChanges();
        }
        public void Delete(int entityId)
        {

            // Não sei se é uma boa "CRUDar" as vagas, mas, tá na interface
            var toDelete = GetById(entityId);

            dcontext.Remove(toDelete);
            dcontext.SaveChanges();
        }
    }
}