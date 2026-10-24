using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Dominio
{
    public class Escola
    {
        public List<string> Alunos;
        public string nome;
        public int AnoCriacao;
        public List<string> Professores;

        public void ExibirDados()
        {
            Console.WriteLine($"Minha escola é {nome}");
            Console.WriteLine("Meus alunos são: ");
            foreach (string aluno in Alunos)
            {
                Console.WriteLine($"- {aluno}");
            }
        }
    }
}
