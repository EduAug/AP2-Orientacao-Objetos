using AP2_Refatorar_Estacionamento;

var db = new DataContext();         //Instância do Banco

//{     REPOSITÓRIOS        }
var vagaRep = new VagaRepository(db);
var motoRepo = new MotoRepository(db);
var carRepo = new CarroRepository(db);


//Laço for para que sejam criadas a quantia de vagas (54) no banco
//Apenas uma única vez, por isso não está no construtor de VagaRepository
/*
for (int i = 0; i < 54; i++)
{

    var vagaAdd = new Vaga {Id = i+1};
    vagaRep.Save(vagaAdd);
}
*/

//CREATE
if (! motoRepo.Save(new Moto()
{

    Placa = "GHI9012",
    Modelo = "Ninja",
    Combustivel = 7
}
)){
    // Caso não seja possível salvar (!Save) retorna onde tá o erro
    Console.WriteLine("Já existe um veiculo com essa placa cadastrada!");
}else{

    Console.WriteLine("Moto inserida com sucesso!");
}
// ^ Adicionar moto | v Adicionar carro
if (! carRepo.Save(new Carro()
{
    Id = 6,
    Placa = "MNO7890",
    Modelo =  "Uno",
    Combustivel = 9.34
})){

    Console.WriteLine("Já existe um veiculo com essa placa cadastrada!");
}else{

    Console.WriteLine("Carro Adicionado com sucesso!");
}

//UPDATE

if (! motoRepo.Update(new Moto()
{

    Placa = "DEF5678",
    Modelo = "CG",
    Combustivel = 4
})){

    Console.WriteLine("Não existe moto com essa placa no sistema");
}else{

    Console.WriteLine("Moto alterada com sucesso!");
}
// ^ Atualizar moto | v Atualizar carro

if(! carRepo.Update(new Carro(){

    Placa = "ABC1234",
    Modelo = "Toro",
    Combustivel = 15
})){

    Console.WriteLine("Não existe carro com essa placa no sistema");
}else{

    Console.WriteLine("Carro alterado com sucesso!");
}

//DELETE -- Lembrete: Ao deletar veículo, REMOVER ELE DA VAGA ANTES

if(! motoRepo.Delete(165))
{

    Console.WriteLine("Essa moto já foi apagada ou não existe no sistema");
}else{

    Console.WriteLine("Moto apagada com sucesso");
}
// ^ Deletar moto | v Deletar carro

if(! carRepo.Delete(6))
{

    Console.WriteLine("Esse carro já foi apagado ou não existe no sistema");
}else{

    Console.WriteLine("Carro apagado com sucesso");
}

//
//CRUD EM VEÍCULOS ^
//

//Inserir veículo na vaga
if(! vagaRep.EstacionarVeiculo(5))
{

    Console.WriteLine("O veículo não foi encontrado, não há vagas disponíveis, ou já está estacionado");
}else{

    Console.WriteLine("Veículo estacionado com sucesso");
}

//Remover veículo na vaga
if(! vagaRep.LiberarVaga(1))
{

    Console.WriteLine("Esse veículo não se encontra no estacionamento");
}else{

    Console.WriteLine("Vaga liberada com sucesso");
}

//Check vaga
//A variavel deve ser atribuida o "mais tarde possível"
//Para garantir que está atualizada, decorrente às mudanças
Vaga checkVaga = vagaRep.FindVaga();
if (checkVaga != null)
{

    Console.WriteLine("Número da vaga: "+checkVaga.Id);
}else{

    Console.WriteLine("Vagas ocupadas.");
}

//Ver todas as vagas ocupadas
var getParkedVagas = vagaRep.GetAllParked();

foreach (Vaga vagasOcupadas in getParkedVagas)
{

    Console.WriteLine($"Vaga: {vagasOcupadas.Id}\t|Placa do Veículo: {vagasOcupadas.Estacionado.Placa}\t|Modelo do Veículo: {vagasOcupadas.Estacionado.Modelo}");
}