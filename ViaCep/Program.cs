using System.Security.Cryptography.X509Certificates;
using ViaCep.Entities;
using ViaCep.Entities.Services;

namespace ViaCep
{
    /// <summary>
    /// Faz a formatação dos dados respeitando cada objeto em sua ordem e disponibilizando em tela pelo foreach.
    /// </summary>
    class Program
    {
        public static async Task Main(string[] args)
        {
            bool menu = true;

            while (menu)
            {
                Console.WriteLine("INFORME O CEP DESEJADO ");
                int cep = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(" ");

                BuscaCepServices buscaCepServices = new BuscaCepServices();

                BuscaCep cepEncontrado = await buscaCepServices.GetCepBrasil(cep);

                List<string> dados = new List<string>
                {
                   "CEP: " + cepEncontrado.Cep,
                   "LOGRADOURO: " + cepEncontrado.Logradouro,
                   "BAIRRO: " + cepEncontrado.Bairro,
                   "LOCALIDADE: " + cepEncontrado.Localidade,
                   "UF: "+ cepEncontrado.UF,
                   "DDD: " + cepEncontrado.Ddd,
                   "SIAFI: " + cepEncontrado.Siafi,
                   "IBGE: " + cepEncontrado.Ibge,
                   "GIA: " + cepEncontrado.Gia
                };

                foreach (string item in dados)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(" ");
                Console.WriteLine("PRESSIONE QUALQUER OUTRA TECLA PARA NOVA CONSULTA | CTRL + C -> ENCERRAR CONSULTA");

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
