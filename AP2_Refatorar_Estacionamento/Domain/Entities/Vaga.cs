using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP2_Refatorar_Estacionamento
{
    public class Vaga
    {
        
        public int Id {get;set;} //Serve como o "número" da vaga
        public bool isOcupada => Estacionado != null;
        //Como a vaga será enviada para o banco sem veículo, ela já será
        //"vaga" no que diz respeito a não ter VeiculoId, logo, null
        //por isso, esse atributo não se faz necessário;
        public int? VeiculoId {get;set;}
        public Veiculo? Estacionado {get;set;}
    }
}