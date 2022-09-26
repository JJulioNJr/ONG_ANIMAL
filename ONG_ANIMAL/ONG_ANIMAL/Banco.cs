using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ONG_ANIMAL {
    internal class Banco {

        string Conexao = "Data Source =localhost; Initial Catalog=ONG_ANIMAL;User Id=SA; Password=jj;";
        SqlConnection conn;

        public Banco() { }

        public string Caminho() {
            return Conexao;
        }


        #region Inserir Pessoa
        public void InserirPessoa(SqlConnection conecta, int Cpf, String Nome, char Sexo, String DataNasc, String Logradouro, int Numero,
                                 int Cep, String Bairro, String UF, String Cidade, String Complemento) {
            try {
                SqlCommand cmdp = new SqlCommand();

                conecta.Open();

                cmdp.CommandText = "Insert Into PESSOA(CPF,NOME,SEXO,DATANASCIMENTO,LOGRADOURO,NUMERO,CEP,BAIRRO,UF,CIDADE,COMPLEMENTO)" +
                                  "VALUES(@CPF,@Nome,@Sexo,@DataNascimento,@Logradouro,@Numero,@Cep,@Bairro,@Uf,@Cidade,@Complemento);";

                cmdp.Parameters.Add(new SqlParameter("@CPF", Cpf));
                cmdp.Parameters.Add(new SqlParameter("@Nome", Nome));
                cmdp.Parameters.Add(new SqlParameter("@Sexo", Sexo));
                cmdp.Parameters.Add(new SqlParameter("@DataNascimento", DataNasc));
                cmdp.Parameters.Add(new SqlParameter("@Logradouro", Logradouro));
                cmdp.Parameters.Add(new SqlParameter("@Numero", Numero));
                cmdp.Parameters.Add(new SqlParameter("@Cep", Cep));
                cmdp.Parameters.Add(new SqlParameter("@Bairro", Bairro));
                cmdp.Parameters.Add(new SqlParameter("@Uf", UF));
                cmdp.Parameters.Add(new SqlParameter("@Cidade", Cidade));
                cmdp.Parameters.Add(new SqlParameter("@Complemento", Complemento));

                cmdp.Connection = conecta;
                cmdp.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }


        }
        #endregion

        #region Inserir Animal
        public void InserirAnimal(SqlConnection conecta, String especie, String raca, char sexo) {

            try {
                SqlCommand cmda = new SqlCommand();

                conecta.Open();
                cmda.CommandText = "Insert Into ANIMAL(ESPECIE,RACA,SEXO)VALUES(@Especie,@Raca,@Sexo);";

                cmda.Parameters.Add(new SqlParameter("@Especie", especie));
                cmda.Parameters.Add(new SqlParameter("@Raca", raca));
                cmda.Parameters.Add(new SqlParameter("@Sexo", sexo));

                cmda.Connection = conecta;
                cmda.ExecuteNonQuery();
                conecta.Close();

            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);

            }
        }
        #endregion

        #region Consultar Pessoa
        public void ConsultarPessoa(SqlConnection conecta) {

            try {
                SqlDataReader reader = null;

                conecta.Open();
                SqlCommand cmd = new SqlCommand("Select CPF, NOME, SEXO, DATANASCIMENTO, LOGRADOURO, NUMERO, CEP, " +
                                               "BAIRRO, UF, CIDADE, COMPLEMENTO From PESSOA ", conecta);

                using (reader = cmd.ExecuteReader()) {


                    while (reader.Read()) {
                        Console.Write("{0}", reader.GetInt32(0));
                        Console.Write(" {0}", reader.GetString(1));
                        Console.Write(" {0}", reader.GetString(2));
                        Console.Write(" {0}", reader.GetString(3));
                        Console.Write(" {0}", reader.GetString(4));
                        Console.Write(" {0}", reader.GetInt32(5));
                        Console.Write(" {0}", reader.GetInt32(6));
                        Console.Write(" {0}", reader.GetString(7));
                        Console.Write(" {0}", reader.GetString(8));
                        Console.Write(" {0}", reader.GetString(9));
                        Console.Write(" {0}", reader.GetString(10));

                        Console.WriteLine("\n");
                    }
                }
                conecta.Close();
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Consultar Animal
        public void ConsultarAnimal(SqlConnection conecta) {

            try {
                SqlDataReader reader = null;

                conecta.Open();
                SqlCommand cmd = new SqlCommand("Select CHIP,ESPECIE,RACA, SEXO From ANIMAL", conecta);

                using (reader = cmd.ExecuteReader()) {


                    while (reader.Read()) {
                        Console.Write("{0}", reader.GetInt32(0));
                        Console.Write(" {0}", reader.GetString(1));
                        Console.Write(" {0}", reader.GetString(2));
                        Console.Write(" {0}", reader.GetString(3));


                        Console.WriteLine("\n");
                    }
                }
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);

            }

        }
        #endregion

        #region Localizar Pessoa
        public void LocalizarPessoa(SqlConnection conecta, int cpf) {
             
            try {
                conecta.Open();


                SqlCommand cmd = new SqlCommand("Select CPF, NOME, SEXO, DATANASCIMENTO, LOGRADOURO, NUMERO, CEP, " +
                                           "BAIRRO, UF, CIDADE, COMPLEMENTO From PESSOA where CPF=@cpf ", conecta);


                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));


                SqlDataReader reader = null;
                using (reader = cmd.ExecuteReader()) {


                    while (reader.Read()) {
                        Console.Write("{0}", reader.GetInt32(0));
                        Console.Write(" {0}", reader.GetString(1));
                        Console.Write(" {0}", reader.GetString(2));
                        Console.Write(" {0}", reader.GetString(3));
                        Console.Write(" {0}", reader.GetString(4));
                        Console.Write(" {0}", reader.GetInt32(5));
                        Console.Write(" {0}", reader.GetInt32(6));
                        Console.Write(" {0}", reader.GetString(7));
                        Console.Write(" {0}", reader.GetString(8));
                        Console.Write(" {0}", reader.GetString(9));
                        Console.Write(" {0}", reader.GetString(10));

                        Console.WriteLine("\n");
                    }
                }
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Localizar Animal
        public void LocalizarAnimal(SqlConnection conecta, int chip) {

            try {
                conecta.Open();

                SqlCommand cmd = new SqlCommand("Select CHIP,ESPECIE,RACA, SEXO From ANIMAL Where CHIP=@CHIP", conecta);

                cmd.Parameters.Add(new SqlParameter("@CHIP", chip));

                SqlDataReader reader = null;
                using (reader = cmd.ExecuteReader()) {


                    while (reader.Read()) {
                        Console.Write("{0}", reader.GetInt32(0));
                        Console.Write(" {0}", reader.GetString(1));
                        Console.Write(" {0}", reader.GetString(2));
                        Console.Write(" {0}", reader.GetString(3));


                        Console.WriteLine("\n");
                    }
                }
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Deletar Pessoa
        public void DeletarPessoa(SqlConnection conecta, int cpf) {
            try {
                conecta.Open();

                SqlCommand cmd = new SqlCommand("Delete From Pessoa Where CPF=@CPF");
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);

            }
        }
        #endregion
       
        #region Deletar Animal
        public void DeletarAnimal(SqlConnection conecta, int chip) {

            try {
                conecta.Open();

                SqlCommand cmd = new SqlCommand("Delete From ANIMAL Where CHIP=@CHIP");
                cmd.Parameters.Add(new SqlParameter("@CHIP", chip));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Editar Pessoa
        public void EditarPessoa(SqlConnection conecta, int cpf, String nome, char sexo, String dataNascimento, String logradouro, int numero,
                                  int cep, String bairro, String uf, String cidade, String complemento, String sql) {
            try {
                conecta.Open();

                SqlCommand cmd = new SqlCommand(sql, conecta);
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@Nome", nome));
                cmd.Parameters.Add(new SqlParameter("@Sexo", sexo));
                cmd.Parameters.Add(new SqlParameter("@DTA", dataNascimento));
                cmd.Parameters.Add(new SqlParameter("@Logradouro", logradouro));
                cmd.Parameters.Add(new SqlParameter("@Numero", numero));
                cmd.Parameters.Add(new SqlParameter("@Cep", cep));
                cmd.Parameters.Add(new SqlParameter("@Bairro", bairro));
                cmd.Parameters.Add(new SqlParameter("@Uf", uf));
                cmd.Parameters.Add(new SqlParameter("@Cidade", cidade));
                cmd.Parameters.Add(new SqlParameter("@Complemento", complemento));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Editar Animal
        public void EditarAnimal(SqlConnection conecta, int chip, String especie, String raca, char sexo, String sql) {
            try {
                conecta.Open();

                SqlCommand cmd = new SqlCommand(sql, conecta);
                cmd.Parameters.Add(new SqlParameter("@CHIP", chip));
                cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
                cmd.Parameters.Add(new SqlParameter("@RACA", raca));
                cmd.Parameters.Add(new SqlParameter("@SEXO", sexo));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();


            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Fazer Adocao
        public void FazerAdocao(SqlConnection conecta, String Sql, int id, int cpf, int chip, String situacao) {
            try {
                conecta.Open();
                SqlCommand cmd = new SqlCommand(Sql, conecta);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@CHIP", chip));
                cmd.Parameters.Add(new SqlParameter("@SITUACAO", situacao));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Consultar Adotado
        public void ConsultarAdotado(SqlConnection conecta, String situacao) {

            try {
                conecta.Open();
                SqlDataReader reader = null;


                SqlCommand cmd = new SqlCommand("Select ID,CPF,CHIP,SITUACAO From ADOCOES where SITUACAO=@SITUACAO", conecta);
                cmd.Parameters.Add(new SqlParameter("@situacao", situacao));

                using (reader = cmd.ExecuteReader()) {


                    while (reader.Read()) {
                        Console.Write("{0}", reader.GetInt32(0));
                        Console.Write(" {0}", reader.GetInt32(1));
                        Console.Write(" {0}", reader.GetInt32(2));
                        Console.Write(" {0}", reader.GetString(3));

                        Console.WriteLine("\n");
                    }
                }
                conecta.Close();

            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);

            }
        }
        #endregion
       
        #region Deletar Adocao
        public void DeletarAdocao(SqlConnection conecta, String Sql, float cpf, int chip, int id) {
            try {
                conecta.Open();
                SqlCommand cmd = new SqlCommand(Sql, conecta);
                cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                cmd.Parameters.Add(new SqlParameter("@CHIP", chip));
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Connection = conecta;
                cmd.ExecuteNonQuery();
                conecta.Close();
            } catch (SqlException ex) {

                Console.WriteLine(ex.Message);

            }
        }
        #endregion

        #region editar Adocao
         public void EditarAdocao(SqlConnection conecta, String Sql, float cpf, int chip, int id, String situacao) {

             try {
                 conecta.Open();
                 SqlCommand cmd = new SqlCommand(Sql, conecta);
                 cmd.Parameters.Add(new SqlParameter("@ID", id));
                 cmd.Parameters.Add(new SqlParameter("@CPF", cpf));
                 cmd.Parameters.Add(new SqlParameter("@CHIP", chip));
                 cmd.Parameters.Add(new SqlParameter("@SITUACAO", situacao));
                 cmd.Connection = conecta;
                 cmd.ExecuteNonQuery();
                 conecta.Close();
             } catch (SqlException ex) {

                 Console.WriteLine(ex.Message);
             }
         }
         #endregion
    }
}
