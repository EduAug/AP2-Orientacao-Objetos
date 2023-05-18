using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP2_Refatorar_Estacionamento
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        
        Entity GetById(int entityId);
        IList<Entity> GetAll();
        void Save(Entity entity);
        void Delete(int entityId);
        void Update(Entity newEntity);
    }
}