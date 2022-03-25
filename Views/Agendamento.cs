using System;
using Controllers;
using Models;

namespace Views
{
    public class AgendamentoView
    {
        public static void InserirAgendamento()
        {
            int IdPaciente;
            int IdDentista;
            int IdSala;
            int IdProcedimento;
            DateTime Data = DateTime.Now;
            Console.WriteLine("Digite o ID do Paciente do Agendamento: ");
            try
            {
                IdPaciente = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id do Dentista do Agendamento: ");
            try
            {
                IdDentista = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            Console.WriteLine("Digite os Procedimentos do Agendamento: ");
            try
            {
                IdProcedimento = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            AgendamentoController.InserirAgendamento(
                IdPaciente,
                IdDentista,
                IdSala,
                Data
            );

        }

        public static void AlterarAgendamento()
        {
            int Id = 0;
            DateTime Data = DateTime.Now;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            AgendamentoController.AlterarAgendamento(
                Id,
                Data
            );
        }

        public static void ExcluirAgendamento()
        {
            int Id = 0;

            ListarAgendamentos();
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            AgendamentoController.ExcluirAgendamento(
                Id
            );

        }

        public static void ListarAgendamentos()
        {
            foreach (Agendamento item in AgendamentoController.VisualizarAgendamentos())
            {
                Console.WriteLine(item);
            }
        }

        public static void GetAgendamentosPorPaciente(int IdPaciente)
        {
            foreach (Agendamento item in AgendamentoController.GetAgendamentosPorPaciente(IdPaciente))
            {
                Console.WriteLine(item);
            }
        }

        public static void ConfirmarAgendamento()
        {
            int Id = 0;

            ListarAgendamentos();
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Agendamento agendamento = AgendamentoController.ConfirmarAgendamento(Id);

            Console.WriteLine("Agendamento Confirmado: ");
            Console.WriteLine(agendamento);
        }
    }
}