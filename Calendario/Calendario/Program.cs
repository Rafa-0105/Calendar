using System;
using System.Collections.Generic;
using System.Threading;

namespace Calendario;


internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, Dictionary<int, List<string>>> Calendario = new Dictionary<int, Dictionary<int, List<string>>>();

        void ExibirLogo()
        {
            Console.WriteLine(@"
░█████╗░░█████╗░██╗░░░░░███████╗███╗░░██╗██████╗░░█████╗░██████╗░██╗░█████╗░
██╔══██╗██╔══██╗██║░░░░░██╔════╝████╗░██║██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗
██║░░╚═╝███████║██║░░░░░█████╗░░██╔██╗██║██║░░██║███████║██████╔╝██║██║░░██║
██║░░██╗██╔══██║██║░░░░░██╔══╝░░██║╚████║██║░░██║██╔══██║██╔══██╗██║██║░░██║
╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝██║░░██║██║░░██║██║╚█████╔╝
░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░╚════╝░
");
        }

        void ExibirCalendario()
        {
            ExibirLogo();
            Console.WriteLine("Digite as opções abaixo desejadas\n");
            Console.WriteLine("Digite 1 para agendar uma Data");
            Console.WriteLine("Digite 2 para selecionar Mês que desejar ver os agendamentos");
            Console.WriteLine("Digite 3 para mostrar a lista de agendamento");
            Console.WriteLine("Digite 4 para as tarefas do dia especifico");
            Console.WriteLine("Digite 5 para sair");

            Console.Write("\nDigite a sua opção de Agendamento: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida)!;

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    CadastrarDatas();
                    break;
                case 2:
                    MotivoDoAgendamento();
                    break;
                case 3:
                    MostrarListaCaldendario();
                    break;
                case 4:
                    Tarefa();
                    break;
                case 5:
                    Console.WriteLine("Valeu, flw tamo junto!");
                    break;
            }
        }

        void CadastrarDatas()
        {
            Console.Clear();
            Console.Write("Digita o mês: ");
            int mes = int.Parse(Console.ReadLine())!;
            Console.Write("Digita o dia que deseja agendar: ");
            int data = int.Parse(Console.ReadLine())!;
            Console.Write("Escreva o motivo do agendamento: ");
            string motivo = Console.ReadLine()!;
            if (Calendario.ContainsKey(mes))
            {
                if (Calendario[mes].ContainsKey(data))
                {
                    Calendario[mes][data].Add(motivo);
                    Console.Clear();
                    ExibirCalendario();
                }
                else
                {
                    Calendario[mes].Add(data, new List<string>() { motivo });
                }
            }
            else
            {
                Calendario.Add(mes, new Dictionary<int, List<string>>() { { data, new List<string>() { motivo } } });
            }

            Console.WriteLine($"O Dia {data} e o mês {mes} foi selecionado com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirCalendario();
        }

        void MostrarListaCaldendario()
        {
            foreach (KeyValuePair<int, Dictionary<int, List<string>>> mes in Calendario)
            {
                foreach (KeyValuePair<int, List<string>> dia in mes.Value)
                {
                    foreach (string tarefa in dia.Value)
                    {
                        Console.WriteLine($"Dia {dia.Key} do mês {mes.Key} esta {tarefa}");
                    }
                }
            }
            Console.WriteLine("Digita qualquer coisa pra voltar no incial.");
            Console.ReadKey();
            Console.Clear();
            ExibirCalendario();
        }

        void MotivoDoAgendamento()
        {
            Console.Clear();
            Console.Write("Digita o Mês que deseja visualizar: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (KeyValuePair<int, List<string>> dia in Calendario[mes])
            {
                foreach (string tarefa in dia.Value)
                {
                    Console.WriteLine($"Dia {dia.Key} do mês {mes} esta {tarefa}");
                }
            }
            Console.WriteLine("Digita qualquer coisa pra voltar no incial.");
            Console.ReadKey();
            Console.Clear();
            ExibirCalendario();
        }

        void Tarefa()
        {
            Console.Clear();
            Console.Write("Digita o Mês que deseja visualizar: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Digita o dia que deseja visualizar: ");
            int data = int.Parse(Console.ReadLine())!;
            Console.Clear();
            Console.WriteLine($"Tarefas do dia {data} do Mês {mes}: ");
            foreach (string tarefa in Calendario[mes][data])
            {
                Console.WriteLine(tarefa);
            }
            Console.WriteLine("Digita qualquer coisa pra voltar no incial.");
            Console.ReadKey();
            Console.Clear();
            ExibirCalendario();
        }
        ExibirCalendario();
    }
}