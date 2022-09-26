using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Security;
using System.Threading;

namespace ONG_ANIMAL {
    internal class Program {

        #region Menu Principal
        static void Menu(Pessoa pessoa, Animal animal, Banco bd, SqlConnection conecta, Adocao adc) {
            int op = 0;
            do {
                Console.WriteLine("\n\t\t*** Menu ***");
                Console.WriteLine("\n1-Sistema De Gerenciamento de Pessoas" +
                                  "\n2-Sistema De Gerenciamento de Animais" +
                                  "\n3-Sistema De Gerenciamento de Adoção" +
                                  "\n0-Sair do Sistema");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 1:
                        Console.Clear();
                        MenuPessoa(pessoa, bd, conecta);
                        break;
                    case 2:
                        Console.Clear();
                        MenuAnimal(animal, bd, conecta);
                        break;
                    case 3:
                        Console.Clear();
                        MenuAdocao(adc,bd, conecta);
                        break;
                    default:
                        if (op < 0 || op > 3) {

                            Console.WriteLine("\nOpção Invalida!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;
                }
            } while (op != 0);
        }
        #endregion

        #region Menu Pessoa
        static void MenuPessoa(Pessoa pessoa, Banco bd, SqlConnection conecta) {
            int op = 0;
            pessoa = new Pessoa();

            do {
                Console.WriteLine("\n*** Sistema de Gerenciamento de Cadastro de Pessoas ***");
                Console.WriteLine("\n1-Cadastrar Pessoa" +
                                  "\n2-Consultar Pessoas de forma Geral" +
                                  "\n3-Localizar Pessoa Especifica" +
                                  "\n4-Deletar Pessoa Especifica" +
                                  "\n0-Sair do Cadastro de Pessoa");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("*** Inserir Pessoa ***\n");
                        pessoa.InserirPessoa(conecta);
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("*** Consulta Geral de Pessoas ***\n");
                        bd = new Banco();
                        bd.ConsultarPessoa(conecta);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("*** Localizar uma Pessoa Especifica ***\n");
                        pessoa.Localizarpessoa(conecta);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("*** Deletar uma Pessoa Especifica ***\n");
                        pessoa.DeletarPessoa(conecta);
                        break;
                    default:
                        if (op < 0 || op > 4) {
                            Console.WriteLine("\nOpção Invalida !!!");
                            Thread.Sleep(3000);
                            Console.Clear();

                        }
                        break;


                }
            } while (op != 0);

        }
        #endregion

        #region Menu Animal
        static void MenuAnimal(Animal animal, Banco bd, SqlConnection conecta) {
            int op = 0;
            animal = new Animal();
          
            do {
                Console.WriteLine("\n*** Sistema de Gerenciamento de Cadastro de Animais ***");
                Console.WriteLine("\n1-Cadastrar Animais" +
                                  "\n2-Consultar Animais de forma Geral" +
                                  "\n3-Localizar Animal Especifico" +
                                  "\n4-Deletar Animal Especifico"+
                                  "\n0 Sair do Cadastro de Animal");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());
              
                switch (op) {

                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("*** Inserir Animais ***\n");
                        animal.InserirAnimal(conecta);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("*** Consulta Geral de Animais ***\n");
                        bd = new Banco();
                        bd.ConsultarAnimal(conecta);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("*** Localizar um Animal Especifico ***\n");
                        animal.LocalizarAnimal(conecta);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("*** Deletar um Animal Especifico ***\n");
                        animal.Deletarnaimal(conecta);
                        break;
                    default:
                        if (op < 0 || op > 4) {
                            Console.WriteLine("\nOpção Invalida!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;



                }
            } while (op!=0);
        }

        #endregion  

        #region Menu Adocao
        static void MenuAdocao(Adocao adc,Banco bd,SqlConnection conecta) {
            int op = 0;

            adc = new Adocao();

            do {
                Console.WriteLine("\n*** Sistema de Gerenciamento de Adoções ***");
                Console.WriteLine("\n1-Adotar Animal" +
                                  "\n2-Consultar Animais Adotados" +
                                  "\n3-Deletar cadastros de Animais Adotados" +
                                  "\n4-Editar Situacao do Animal" +
                                  "\n0 Sair do Cadastro de Adoção");
                Console.Write("\nDigite: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {

                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("*** Fazer Adocao de Animais ***\n");
                        adc.FazerAdocao(conecta);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("*** Consultar Adocao de Animais Adotados ***\n");
                        adc.ConsultarAdocao(conecta);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("*** Deletar Cadastro de Animal Adotado ***\n");
                        adc.DeletarAdocao(conecta);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("*** Aleterar Situação de Adoção do Animal ***\n");
                       // adc.EditarAdocao(conecta);
                        break;
                    default:
                        if (op < 0 || op > 4) {
                            Console.WriteLine("\nOpção Invalida!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;
                }
            }while (op!=0);
        }
        #endregion


        static void Main(string[] args) {


            Pessoa pessoa = new Pessoa();
            Animal animal = new Animal();
            Adocao adc = new Adocao();
           

            Banco bd = new Banco();
            SqlConnection conexaosql = new SqlConnection(bd.Caminho());
            
            Menu(pessoa, animal,bd,conexaosql,adc);

        }
    }
}
