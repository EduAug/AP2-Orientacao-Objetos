using AP2_Refatorar_Estacionamento;

var db = new DataContext();         //Instância do Banco

//{     REPOSITÓRIOS        }
var vagaRep = new VagaRepository(db);



//Laço for para que sejam criadas a quantia de vagas (54) no banco
//Apenas uma única vez, por isso não está no construtor de VagaRepository
/*
for (int i = 0; i < 54; i++)
{

    var vagaAdd = new Vaga {Id = i+1};
    vagaRep.Save(vagaAdd);
}
*/