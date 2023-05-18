using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP2_Refatorar_Estacionamento
{
    public class CarroRepository : ICarroRepository
    {

        private readonly DataContext dcontext;

        public CarroRepository(DataContext cntxt)
        {

            //Injeção de dependência(?)
            this.dcontext = cntxt;
        }

        // ------------------------

        public Carro GetById(int entityId)
        {

            return dcontext.Carros.SingleOrDefault(a => a.Id == entityId);
        }
        public Carro GetByPlaca(string placa)
        {
            //A intenção original era conferir se já existia uma plca
            //(Unique) cadastrada no banco igual a uma nova inserida
            //porém o EFCore já trata desses problemas de unicidade

            //Então agora esse método é utilizado para pegar por placa
            //como que por Id
            return dcontext.Carros.SingleOrDefault(d=>d.Placa==placa);
        }

        public IList<Carro> GetAll()
        {

            return dcontext.Carros.ToList();
        }

        // --------------------------

        public void Save(Carro entity)
        {
            
            dcontext.Add(entity);
            dcontext.SaveChanges();
        }

        public void Delete(int entityId)
        {

            var toDelete = GetById(entityId);

            dcontext.Remove(toDelete);
            dcontext.SaveChanges();
        }

        public void Update(Carro newEntity)
        {

            dcontext.Carros.Update(newEntity);
            dcontext.SaveChanges();
        }
    }
}