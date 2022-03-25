using System;
using Controllers;
using Models;

namespace Views
{
    public class EspecialidadeView
    {
        public static void InserirEspecialidade()
        {
            Console.WriteLine("Digite a Descricao da Especialidade: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Digite os Detalhamento da Especialidade: ");
            string Equipamentos = Console.ReadLine();

            EspecialidadeController.InserirEspecialidade(
                Numero,
                Equipamentos
            );

        }

        public static void AlterarEspecialidade()
        {
            int Id = 0;
            DateTime DataNascimento = DateTime.Now;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite a Descricao da Especialidade: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Digite os Detalhamento da Especialidade: ");
            string Equipamentos = Console.ReadLine();

            EspecialidadeController.AlterarEspecialidade(
                Id,
                Numero,
                Equipamentos
            );

        }

        public static void ExcluirEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            EspecialidadeController.ExcluirEspecialidade(
                Id
            );

        }
        public static void ListarEspecialidades()
        {
            foreach (Especialidade item in EspecialidadeController.VisualizarEspecialidades())
            {
                Console.WriteLine(item);
            }
        }
    }
}