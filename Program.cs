using System;

namespace DotnetLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria um array de inteiros com 3 elementos
            var arr = new int[3];

            try
            {
                // Tenta acessar índices fora do array,
                // o que causaria uma IndexOutOfRangeException
                // for (var index = 0; index < 10; index++)
                // {
                //     // IndexOutOfRangeException
                //     Console.WriteLine(arr[index]);
                // }

                // Tenta cadastrar um texto
                Cadastrar("akjshdkjahsd");
            }
            catch (IndexOutOfRangeException ex)
            {
                // Captura e trata a exceção IndexOutOfRangeException
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Não encontrei o índice na lista");
            }
            catch (ArgumentNullException ex)
            {
                // Captura e trata a exceção ArgumentNullException
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha ao cadastrar texto");
            }
            catch (MinhaException ex)
            {
                // Captura e trata a exceção personalizada MinhaException
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Exceção customizada");
            }
            catch (Exception ex)
            {
                // Captura e trata qualquer outra exceção não específica
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, algo deu errado!");
            }
            finally
            {
                // Bloco finally, executado sempre, independentemente de uma exceção ter sido lançada ou não
                Console.WriteLine("Chegou ao fim!");
            }
        }

        // Método que tenta cadastrar um texto
        private static void Cadastrar(string texto)
        {
            // Verifica se o texto é nulo ou vazio e lança uma exceção personalizada se for o caso
            if (string.IsNullOrEmpty(texto))
                throw new MinhaException(DateTime.Now);
        }

        // Definição de uma exceção personalizada
        public class MinhaException : Exception
        {
            // Construtor da exceção personalizada que recebe a data/hora do acontecimento
            public MinhaException(DateTime date)
            {
                QuandoAconteceu = date;
            }

            // Propriedade que armazena a data/hora do acontecimento da exceção
            public DateTime QuandoAconteceu { get; set; }
        }
    }
}