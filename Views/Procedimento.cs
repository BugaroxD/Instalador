using System;
using Controllers;
using Models;

namespace Views
{
    public class ProcedimentoView
    {
        public static void InserirProcedimento()
        {
            Console.WriteLine("Digite a Descricao da Procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite os Preco da Procedimento: ");
            double Preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Informe o Id do Agendamento associado com o Procedimento: ");
            int IdAgendamento = Convert.ToInt32(Console.ReadLine());

            ProcedimentoController.InserirProcedimento(
                Descricao,
                Preco,
                IdAgendamento
            );

        }

        public static void AlterarProcedimento()
        {
            int Id = 0;
            DateTime DataNascimento = DateTime.Now;
            Console.WriteLine("Digite o ID da Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite a Descricao da Procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite os Preco da Procedimento: ");
            double Preco = Convert.ToDouble(Console.ReadLine());

            ProcedimentoController.AlterarProcedimento(
                Id,
                Descricao,
                Preco
            );

        }

        public static void ExcluirProcedimento()
        {
            int Id = 0;

            ListarProcedimentos();
            Console.WriteLine("Digite o ID da Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            ProcedimentoController.ExcluirProcedimento(
                Id
            );

        }
        public static void ListarProcedimentos()
        {
            foreach (Procedimento item in ProcedimentoController.VisualizarProcedimentos())
            {
                Console.WriteLine(item);
            }
        }
    }
}