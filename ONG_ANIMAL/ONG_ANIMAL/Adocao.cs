using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONG_ANIMAL {
    internal class Adocao {

        public int ID { get; set; }
        public char Resposta { get; set; }
        public String Situacao { get; set; }

        public Banco bd;
        public Pessoa pessoa;
        public Animal animal;
        public Adocao() { }

        public Adocao(char resposta, String situacao) {

            this.Situacao = situacao;
            this.Resposta = resposta;
        }

        #region Fazer adocao 
        public void FazerAdocao(SqlConnection conecta) {


            String sql = "Insert Into ADOCOES(CPF,CHIP,SITUACAO) Values (@CPF,@CHIP,@SITUACAO)";

            Console.WriteLine("\n*** Deseja Fazer a Adocao de um Animal de Estimação? ***");
            Console.WriteLine("SIM - S / NÂO - N ");
            this.Resposta = char.Parse(Console.ReadLine().ToUpper());

            if (Resposta.Equals('S')) {
                pessoa = new Pessoa();
                animal = new Animal();
                this.Situacao = "ADOTADO";

                Console.Write("\nInforme o seu CPF: ");
                this.pessoa.Cpf = int.Parse(Console.ReadLine());
                
                Console.Write("\nInforme o seu CHIP: ");
                this.animal.Chip = int.Parse(Console.ReadLine());

            }
            else {
                Console.WriteLine("\nAnimal Continua Disponivel para Adoção!!!");

            }
            bd = new Banco();
            bd.FazerAdocao(conecta, sql, this.ID, this.pessoa.Cpf, this.animal.Chip, this.Situacao);


            Console.WriteLine("\n\nAdoção Feito com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();


        }
        #endregion

        #region Consultar Adocao
        public void ConsultarAdocao(SqlConnection conecta) {

            this.Situacao = "ADOTADO";
            bd = new Banco();
            bd.ConsultarAdotado(conecta, this.Situacao);
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Deletar Adocao 
        public void DeletarAdocao(SqlConnection conecta) {
            pessoa = new Pessoa();
            animal = new Animal();

            String sql = "Delete from ADOCOES where ID=@ID and CPF=@CPF and CHIP=@CHIP";

            Console.Write("\nInforme o Numero de Indetificação Registrado no Cadastro da Adoção: ");
            Console.Write("ID: ");
            this.ID = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o seu CPF: ");
            this.pessoa.Cpf = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o seu CHIP: ");
            this.animal.Chip = int.Parse(Console.ReadLine());

            bd = new Banco();
            bd.DeletarAdocao(conecta, sql, this.pessoa.Cpf, this.animal.Chip, this.ID);


            Console.WriteLine("\n\n Cadastro de Adoção Deletado com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Editar Adocao
        public void EditarAdocao(SqlConnection conecta) {
            pessoa = new Pessoa();
            animal = new Animal();
        

            String sql = "Update ADOCOES Set SITUACAO=@SITUACAO Where  ID=@ID and CPF=@CPF and CHIP=@CHIP ;";

            Console.Write("\nInforme o Numero de Indetificação Registrado no Cadastro da Adoção: ");
            Console.Write("ID: ");
            this.ID = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o seu CPF: ");
            this.pessoa.Cpf = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o seu CHIP: ");
            this.animal.Chip = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o Tipo de Situação que Deseja Alterar");
            Console.WriteLine("A-ADOTADO / D-DISPONIVEL");
            char status = char.Parse(Console.ReadLine().ToUpper());

            if (status.Equals('A')) {
                this.Situacao = "ADOTADO";
            }
            else {
                this.Situacao = "DISPONIVEL";
            }

            bd = new Banco();
            bd.EditarAdocao(conecta, sql, this.ID,this.pessoa.Cpf, this.animal.Chip, this.Situacao);


            Console.WriteLine("\n\nSituação Aditada com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();

        }
        #endregion
    }
}
