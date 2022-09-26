using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ONG_ANIMAL {
    internal class Animal {

        public int Chip { get; set; }
        public String Especie { get; set; }
        public String Raca { get; set; }
        public char Sexo { get; set; }

        public Banco bd;

        public Animal() { }

        public Animal( String especie, String raca, char sexo) {

            this.Especie = especie;
            this.Raca = raca;
            this.Sexo = sexo;
        }
        #region Inserir Animal
        public void InserirAnimal(SqlConnection conecta) {
           
            Banco bd = new Banco();

            Console.Write("Especie: ");
            this.Especie = Console.ReadLine();

            Console.Write("Raca: ");
            this.Raca = Console.ReadLine();

            Console.Write("Sexo: ");
            this.Sexo = char.Parse(Console.ReadLine().ToUpper());

            bd = new Banco();
            
            bd.InserirAnimal(conecta, this.Especie, this.Raca, this.Sexo);
            
            Console.WriteLine("\n\nAnimal Cadastrado com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Deletar Animal
        public void Deletarnaimal(SqlConnection conecta) {
            
            Console.WriteLine("\nInforme o Chip do animal que deseja Deletar");
            Console.Write("CHIP: ");
            this.Chip = int.Parse(Console.ReadLine());
            bd = new Banco();
            bd.DeletarAnimal(conecta,this.Chip);

            Console.WriteLine("\n\nAnimal Deletado com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion

        #region Localizar Animal
        public void LocalizarAnimal(SqlConnection conecta) {

            Console.WriteLine("\nInforme o Chip do Animal que Deseja Localizar");
            Console.Write("CHIP: ");
            this.Chip = int.Parse(Console.ReadLine());

            bd = new Banco();
            bd.LocalizarAnimal(conecta,this.Chip);
            Thread.Sleep(3000);
            Console.Clear();

        }
        #endregion

        #region Editar Animais
        public void EditaAnimal(SqlConnection conecta) {
            int op = 0;
            string sql = "";
            
            Console.WriteLine("Informe o CHIP do Animal que deseja Editar");
            Console.Write("CHIP: ");
            int chip = int.Parse(Console.ReadLine());


            Console.WriteLine("\n*** Editar Animal ***");
            Console.WriteLine("\n1-Especie" +
                              "\n2-Raca" +
                              "\n3-Sexo");
            Console.Write("\nDigite: ");
            op = int.Parse(Console.ReadLine());

            switch (op) {

                case 1:
                    sql = "Update ANIMAL Set ESPECIE=@ESPECIE Where CHIP=@CHIP";
                    Console.WriteLine("Editar Especie: ");
                    this.Especie = Console.ReadLine();
                    break;

                case 2:
                    sql = "Update ANIMAL Set RACA=@RACA Where CHIP=@CHIP";
                    Console.WriteLine("Editar Raca: ");
                    this.Raca = Console.ReadLine();
                    break;
                case 3:
                    sql = "Update ANIMAL Set SEXO=@SEXO Where CHIP=@CHIP";
                    Console.WriteLine("Editar Especie: ");
                    this.Sexo = char.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Opcao Inválida!!!");
                    break;

            }

            bd = new Banco();
            bd.EditarAnimal(conecta,this.Chip,this.Especie,this.Raca,this.Sexo,sql);

            Console.WriteLine("\n\nAnimal Editado com Sucesso...");
            Thread.Sleep(3000);
            Console.Clear();
        }
        #endregion 



    }
}
