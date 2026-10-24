using Revisao.Infraestrutura;
using Revisao.Services;
ProvaRepository.Inicializar();
int opcao = 0;
while (opcao != -1)
{
    Console.WriteLine("Digite a operação que deseja realizar:");
    Console.WriteLine("1- Adicionar");
    Console.WriteLine("2- Listar");
    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        break;
    }
    if (opcao == 1)
    {
        ProvaService.Adicionar();
    }
    else if (opcao == 2)
    {
        ProvaService.ListarProvas();
    }
    else
    {
        opcao = -1;
    }
}











