using Revisao.Dominio;
using Revisao.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Services
{
    public static class ProvaService
    {
        public static List<Prova> BancoDados =  new List<Prova>();
        public static void Adicionar()
        {
            Prova prova = new Prova();
            prova.Id = BancoDados.Count > 0? BancoDados.Count + 1 : 1;
            Console.WriteLine("Usuário digite uma disciplina");
            prova.Disciplina = Console.ReadLine();
            Console.WriteLine("Digite o valor da prova");
            prova.Nota = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja adicionar mais questões? Digite sim ou nao?");
            string resposta = Console.ReadLine();
            while(resposta.ToLower() == "sim")
            {
                Console.WriteLine("Digite a pergunta da questão que deseja adicionar");
                prova.Questoes.Add(Console.ReadLine());
                Console.WriteLine("Deseja adicionar mais questões? Digite sim ou nao?");
                resposta = Console.ReadLine();
            }
            Console.WriteLine("Deseja adicionar o gabarito? Digite sim ou nao?");
            resposta = Console.ReadLine();
            while (resposta.ToLower() == "sim")
            {
                Console.WriteLine("Digite a pergunta da questão que deseja adicionar");
                prova.Gabarito.Add(char.Parse(Console.ReadLine()));
                Console.WriteLine("Deseja adicionar mais questões? Digite sim ou nao?");
                resposta = Console.ReadLine();
            }
            ProvaRepository.Adicionar(prova);
        }
        public static void ListarProvas()
        {
            List<Prova> list = ProvaRepository.Listar();
            foreach (Prova item in list)
            {
                item.ExibirDados();
            }
        }
    }
}
