using System;
using AP2_Refatorar_Estacionamento;
//Laço for para que sejam criadas a quantia de vagas (54) no banco
//Apenas uma única vez, por isso não está no construtor de VagaRepository
/*
for (int i = 0; i < 54; i++)
{

    var vagaAdd = new Vaga {Id = i+1};
    vagaRep.Save(vagaAdd);
}
*/


var db = new DataContext();         //Instância do Banco
//{     REPOSITÓRIOS        }
var vagaRep = new VagaRepository(db);
var motoRepo = new MotoRepository(db);
var carRepo = new CarroRepository(db);


//{     VARIÁVEIS PARA OPERAÇÃO DO MENU         }
int loopMenu = 1;
int selectOpt;
int typeVehicle;
//Navegação menu ^

int idVehicle;
string placaVehicle;
string modelVehicle;
double gasVehicle;
//Criação/Atualização veículo ^

// P R O G R A M
while(loopMenu != 0)
{
    
    menuIntro();
    selectOpt = Convert.ToInt32(Console.ReadLine());

    switch (selectOpt)
    {
        case 1:

            switch(selectTypeVehicle()){

                case 1:
                
                    Console.WriteLine("Insira a placa da moto:");
                    placaVehicle = Console.ReadLine();
                    Console.WriteLine("Insira o modelo da moto:");
                    modelVehicle = Console.ReadLine();
                    Console.WriteLine("Insira a quantia de gasolina no tanque (Medida de segurança):");
                    gasVehicle = Convert.ToDouble(Console.ReadLine());

                    createMoto(placaVehicle, modelVehicle, gasVehicle);
                    break;
                case 2:

                    Console.WriteLine("Insira a placa do carro:");
                    placaVehicle = Console.ReadLine();
                    Console.WriteLine("Insira o modelo do carro:");
                    modelVehicle = Console.ReadLine();
                    Console.WriteLine("Insira a quantia de gasolina no tanque (Medida de segurança):");
                    gasVehicle = Convert.ToDouble(Console.ReadLine());

                    createCarro(placaVehicle, modelVehicle, gasVehicle);
                    break;
                default:

                    Console.WriteLine("Veículo não suportado");
                    break;
            }
            break;
        case 2:

            switch(selectTypeVehicle()){

                case 1:
                
                    listAllVehiclesSystem();
                    
                    Console.WriteLine("Exibindo todos os veículos cadastrados...");
                    Console.WriteLine("Insira a placa da moto:");
                    placaVehicle = Console.ReadLine();
                    Console.WriteLine("Insira o modelo da moto:");
                    modelVehicle = Console.ReadLine();
                    Console.WriteLine("Insira a quantia de gasolina no tanque (Medida de segurança):");
                    gasVehicle = Convert.ToDouble(Console.ReadLine());

                    updateMoto(placaVehicle, modelVehicle, gasVehicle);
                    break;
                case 2:

                    listAllVehiclesSystem();
                    
                    Console.WriteLine("Exibindo todos os veículos cadastrados...");
                    
                    Console.WriteLine("Insira a placa do carro:");
                    placaVehicle = Console.ReadLine();
                    Console.WriteLine("Insira o modelo do carro:");
                    modelVehicle = Console.ReadLine();
                    Console.WriteLine("Insira a quantia de gasolina no tanque (Medida de segurança):");
                    gasVehicle = Convert.ToDouble(Console.ReadLine());

                    updateCarro(placaVehicle, modelVehicle, gasVehicle);
                    break;
                default:

                    Console.WriteLine("Veículo não suportado");
                    break;
            }
            break;
        case 3:

            switch(selectTypeVehicle()){

                case 1:
                
                    listAllVehiclesSystem();
                    
                    Console.WriteLine("Insira o Id do veículo que deseja deletar:");

                    idVehicle = Convert.ToInt32(Console.ReadLine());
                    liberarVaga(idVehicle);
                    deleteMoto(idVehicle);
                    break;
                case 2:

                    listAllVehiclesSystem();
                    
                    Console.WriteLine("Insira o Id do veículo que deseja deletar:");

                    idVehicle = Convert.ToInt32(Console.ReadLine());
                    liberarVaga(idVehicle);
                    deleteCarro(idVehicle);
                    break;
                default:

                    Console.WriteLine("Veículo não suportado");
                    break;
            }
            break;


        case 4:

            listAllVehiclesSystem();

            Console.WriteLine("Qual dos veículos cadastrados deve ser estacionado?");
            idVehicle = Convert.ToInt32(Console.ReadLine());

            ocuparVaga(idVehicle);
            break;
        case 5:

            
            listAllVehiclesSystem();

            Console.WriteLine("Qual dos veículos cadastrados será liberado?(Id)");
            idVehicle = Convert.ToInt32(Console.ReadLine());
            
            liberarVaga(idVehicle);
            break;


        case 6:
            
            Console.WriteLine("Econtrando vagas livres...");
            
            System.Threading.Thread.Sleep(1500);
            getEmpty();
            break;
        case 7:

            Console.WriteLine("Econtrando vagas ocupadas...");
            
            System.Threading.Thread.Sleep(1500);
            getOccupied();
            break;
        case 8:

            Console.WriteLine("Esses são os veículos cadastrados(Não necessariamente estacionados):");
            System.Threading.Thread.Sleep(1000);

            listAllVehiclesSystem();
            break;


        case 9:
            loopMenu = 0;
            break;
        default:

            Console.WriteLine("Opção não suportada!");
            break;
    }
}










//CREATE
void createMoto(string cPlaca, string cModel, double cGas){

    if (! motoRepo.Save(new Moto()
    {

        Placa = cPlaca,
        Modelo = cModel,
        Combustivel = cGas
    }
    )){
        // Caso não seja possível salvar (!Save) retorna onde tá o erro
        Console.WriteLine("Já existe um veiculo com essa placa cadastrada!");
    }else{

        Console.WriteLine("Moto inserida com sucesso!");
    }
}
// ^ Adicionar moto | v Adicionar carro
void createCarro(string cPlaca, string cModel, double cGas){

    if (! carRepo.Save(new Carro()
    {

        Placa = cPlaca,
        Modelo =  cModel,
        Combustivel = cGas
    })){

        Console.WriteLine("Já existe um veiculo com essa placa cadastrada!");
    }else{

        Console.WriteLine("Carro Adicionado com sucesso!");
    }
}


//UPDATE


void updateMoto(string ePlaca, string nModel, double nGas){

    if (! motoRepo.Update(new Moto()
    {

        Placa = ePlaca,
        Modelo = nModel,
        Combustivel = nGas
    })){

        Console.WriteLine("Não existe moto com essa placa no sistema");
    }else{

        Console.WriteLine("Moto alterada com sucesso!");
    }
}
// ^ Atualizar moto | v Atualizar carro

void updateCarro(string ePlaca, string nModel, double nGas){
    
    if(! carRepo.Update(new Carro(){

        Placa = ePlaca,
        Modelo = nModel,
        Combustivel = nGas
    })){

        Console.WriteLine("Não existe carro com essa placa no sistema");
    }else{

        Console.WriteLine("Carro alterado com sucesso!");
    }
}


//DELETE -- Lembrete: Ao deletar veículo, REMOVER ELE DA VAGA ANTES


void deleteMoto(int idVehicle){

    if(! motoRepo.Delete(idVehicle))
    {

        Console.WriteLine("Essa moto já foi apagada ou não existe no sistema");
    }else{

        Console.WriteLine("Moto apagada com sucesso");
    }
}
// ^ Deletar moto | v Deletar carro

void deleteCarro(int idVehicle){

    if(! carRepo.Delete(idVehicle))
    {

        Console.WriteLine("Esse carro já foi apagado ou não existe no sistema");
    }else{

        Console.WriteLine("Carro apagado com sucesso");
    }
}
//
//CRUD EM VEÍCULOS ^
//


//
//CONTROLE DE VAGAS v
//

//Inserir veículo na vaga
void ocuparVaga(int idVehicle){

    if(! vagaRep.EstacionarVeiculo(idVehicle))
    {

        Console.WriteLine("O veículo não foi encontrado, não há vagas disponíveis, ou já está estacionado");
    }else{

        Console.WriteLine("Veículo estacionado com sucesso");
    }
}

//Remover veículo na vaga
void liberarVaga(int idVehicle){

    if(! vagaRep.LiberarVaga(idVehicle))
    {

        Console.WriteLine("Esse veículo não se encontra no estacionamento");
    }else{

        Console.WriteLine("Vaga liberada com sucesso");
    }
}

//Check vaga

//Procura a primeira vaga Livre 
//(LEGACY) ~Não tem o porquê listar a primeira livre se pode listar todas
/*Vaga checkVaga = vagaRep.FindVaga();
if (checkVaga != null)
{

    Console.WriteLine("Número da vaga: "+checkVaga.Id);
}else{

    Console.WriteLine("Vagas ocupadas.");
}*/

//Ver todas as vagas ocupadas
void getOccupied(){

    listAllVehiclesSystem();    //Gambiarra do G maíusculo
    Console.Clear();
    var getParkedVagas = vagaRep.GetAllParked();

    foreach (Vaga vagasOcupadas in getParkedVagas)
    {

        if(vagasOcupadas.Estacionado != null)
            Console.WriteLine($"Vaga: {vagasOcupadas.Id}\t|Placa do Veículo: {vagasOcupadas.Estacionado.Placa}\t|Modelo do Veículo: {vagasOcupadas.Estacionado.Modelo}");
        else   
            Console.WriteLine("teste");
    }
}
//Ver todas as vagas livres
void getEmpty(){

    Console.Clear();
    var getEmptyVagas = vagaRep.GetAllEmpty();
    int lnBrk = 0;
    foreach (Vaga vagasLivres in getEmptyVagas)
    {

        Console.Write($"|Vaga: {vagasLivres.Id}\t|Status: Livre |");
        if(lnBrk == 2){

            Console.Write("\n");
            lnBrk = 0;//Reseta a cada 3 pra deixar 8 linhas
        }else{

            Console.Write("\t");
            lnBrk++;
        }
    }
}

//OPÇÕES DO MENU v


void menuIntro()
{

    Console.WriteLine("\n\nSistema de gerenciamento de estacionamento v2.0");
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1- Criar veículo\t2- Editar veículo\t3- Apagar veículo");
    Console.WriteLine("4- Estacionar veículo\t5- Liberar vaga");
    Console.WriteLine("6- Listar vagas livres\t7- Listar vagas ocupadas");
    Console.WriteLine("8- Listar veículos cadastrados");
    Console.WriteLine("9 - Encerrar");
}

int selectTypeVehicle()
{

    Console.Clear();
    Console.WriteLine("O veículo é uma moto(1) ou um carro(2)?");
    typeVehicle = Convert.ToInt32(Console.ReadLine());

    switch (typeVehicle){

        case 1:

            return 1;
        case 2:
            
            return 2;
        default:

            return 0;
    }
}

void listAllVehiclesSystem()
{

    Console.Clear();
    Console.WriteLine("Motos no sistema:");
    var motosRegistradas = motoRepo.GetAll();
    foreach(Moto motoSis in motosRegistradas)
    {

        Console.WriteLine($"Id: {motoSis.Id}\t|Placa: {motoSis.Placa}\t|Modelo: {motoSis.Modelo}");
    }
    Console.WriteLine("Carros no sistema:");            
    var carrosRegistrados = carRepo.GetAll();
    foreach(Carro carroSis in carrosRegistrados)
    {

        Console.WriteLine($"Id: {carroSis.Id}\t|Placa: {carroSis.Placa}\t|Modelo: {carroSis.Modelo}");
    }
}