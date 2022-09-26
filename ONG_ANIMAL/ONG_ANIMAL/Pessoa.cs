using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONG_ANIMAL {
    internal class Pessoa {

        public int Cpf { get; set; }
        public String Nome { get; set; }
        public char Sexo { get; set; }
        public String DataNasc { get; set; }
        public String Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public String Bairro { get; set; }
        public String UF { get; set; }
        public String Cidade { get; set; }
        public String Complemento { get; set; }

        public Banco bd;
       
        public Pessoa() { }

        public Pessoa(int cpf, String nome, char sexo, String dataNc, String logr, int numero, int cep,
                      String bairro, String uf, String cidade, String complemento) {

            this.Cpf = cpf;
            this.Nome = nome;
            this.Sexo = sexo;
            this.DataNasc = dataNc;
            this.Logradouro = logr;
            this.Numero = numero;
            this.Cep = cep;
            this.Bairro = bairro;
            this.UF = uf;
            this.Cidade = cidade;
            this.Complemento = complemento;

        }

        #region Inserir Pessoa
        public void InserirPessoa(SqlConnection conecta) {
            
            Console.Write("CPF:");
            this.Cpf = int.Parse(Console.ReadLine());
            
            Console.Write("Nome: ");
            this.Nome = Console.ReadLine();

            Console.Write("Sexo: ");
            this.Sexo = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Data de Nascimento: ");
            this.DataNasc = Console.ReadLine();

            Console.Write("Logradouro: ");
            this.Logradouro = Console.ReadLine();

            Console.Write("Numero: ");
            this.Numero = int.Parse(Console.ReadLine());

            Console.Write("CEP: ");
            this.Cep = int.Parse(Console.ReadLine());

            Console.Write("Bairro: ");
            this.Bairro = Console.ReadLine();

            Console.Write("UF: ");
            this.UF = Console.ReadLine().ToUpper();

            Console.Write("Cidade: ");
            this.Cidade = Console.ReadLine();

            Console.Write("Complemento: ");
            this.Complemento = Console.ReadLine();


            bd = new Banco();
            bd.InserirPessoa(conecta, this.Cpf, this.Nome, this.Sexo, this.DataNasc, this.Logradouro, this.Numero,
                                this.Cep, this.Bairro, this.UF, this.Cidade, this.Complemento);

            Console.WriteLine("\n\nPessoa Cadastrada com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Deletar Pessoa
        public void DeletarPessoa(SqlConnection conecta) {
         
            Console.WriteLine("\nInforme o CPF da pessoa que deseja Deletar");
            Console.Write("CPF: ");
            this.Cpf = int.Parse(Console.ReadLine());

            bd = new Banco();
            bd.DeletarPessoa(conecta, this.Cpf);
            
            Console.WriteLine("\n\nPessoa Deletada com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Localizar Pessoa
        public void Localizarpessoa(SqlConnection conecta) {
           
            Console.WriteLine("\nInforme o CPF da pessoa que deseja Localizar");
            Console.Write("CPF: ");
            this.Cpf = int.Parse(Console.ReadLine());

            bd = new Banco();
            bd.LocalizarPessoa(conecta, this.Cpf);

        }
        #endregion

        #region Editar Pessoa
        public void EditarPessoa(SqlConnection conecta) {
           
            int op = 0;
            String sql = "";

            Console.WriteLine("Informe o CPF da pessoa que deseja Editar");
            Console.Write("CPF: ");
            this.Cpf = int.Parse(Console.ReadLine());


            Console.WriteLine("\n*** Editar Pessoa ***");
            Console.WriteLine("\n1-Nome" +
                              "\n2-Sexo" +
                              "\n3-Data de Nascimento" +
                              "\n4-Logradouro" +
                              "\n5-Numero" +
                              "\n6-CEP" +
                              "\n7-Bairro" +
                              "\n8-UF" +
                              "\n9-Cidade" +
                              "\n10-Complemento");
            Console.Write("\nDigite: ");
            op = int.Parse(Console.ReadLine());

            switch (op) {
                case 1:
                    sql = "Update PESSOA Set Nome=@Nome Where CPF=@CPF";
                    Console.WriteLine("Alterar Nome:");
                    this.Nome = Console.ReadLine();
                    break;
                case 2:
                    sql = "Update PESSOA Set Sexo=@Sexo Where CPF=@CPF";
                    Console.WriteLine("Alterar Sexo:");
                    this.Sexo = char.Parse(Console.ReadLine().ToUpper());
                    break;
                case 3:
                    sql = "Update PESSOA Set DATANASCIMENTO=@DTA Where CPF=@CPF";
                    Console.WriteLine("Alterar Data de Nascimento:");
                    this.DataNasc = Console.ReadLine();
                    break;
                case 4:
                    sql = "Update PESSOA Set LOGRADOURO=@LOGRADOURO Where CPF=@CPF";
                    Console.WriteLine("Alterar Logradouro:");
                    this.Logradouro = Console.ReadLine();
                    break;
                case 5:
                    sql = "Update PESSOA Set NUMERO=@NUMERO Where CPF=@CPF";
                    Console.WriteLine("Alterar Numero:");
                    this.Numero = int.Parse(Console.ReadLine());
                    break;
                case 6:
                    sql = "Update PESSOA Set CEP=@CEP Where CPF=@CPF";
                    Console.WriteLine("Alterar CEP:");
                    this.Cep = int.Parse(Console.ReadLine());
                    break;
                case 7:
                    sql = "Update PESSOA Set BAIRRO=@BAIRRO Where CPF=@CPF";
                    Console.WriteLine("Alterar Bairro:");
                    this.Bairro = Console.ReadLine();
                    break;
                case 8:
                    sql = "Update PESSOA Set UF=@UF Where CPF=@CPF";
                    Console.WriteLine("Alterar UF:");
                    this.UF = Console.ReadLine();
                    break;
                case 9:
                    sql = "Update PESSOA Set CIDADE=@CIDADE Where CPF=@CPF";
                    Console.WriteLine("Alterar Cidade:");
                    this.Cidade = Console.ReadLine();
                    break;
                case 10:
                    sql = "Update PESSOA Set COMPLEMENTO=@COMPLEMENTO Where CPF=@CPF";
                    Console.WriteLine("Alterar Complento:");
                    this.Complemento = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!!!");
                    break;
            }

            bd = new Banco();
            bd.EditarPessoa(conecta, this.Cpf, this.Nome, this.Sexo, this.DataNasc, this.Logradouro, this.Numero,
                             this.Cep, this.Bairro, this.UF, this.Cidade, this.Complemento, sql);
            
            Console.WriteLine("\n\nPessoa Editada com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Imprimir pessoa
        public String ImprimePessoa() {
            return "\n" + this.Cpf +
                  "\n" + this.Nome +
                  "\n" + this.Sexo +
                  "\n" + this.DataNasc +
                  "\n" + this.Logradouro +
                  "\n" + this.Numero +
                  "\n" + this.Cep +
                  "\n" + this.Bairro +
                  "\n" + this.UF +
                  "\n" + this.Cidade +
                  "\n" + this.Complemento;
        }
        #endregion
    }
}
