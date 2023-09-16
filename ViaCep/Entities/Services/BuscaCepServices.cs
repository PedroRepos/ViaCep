using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaCep.Entities.Services
{
    /// <summary>
    /// Faz a conexão com a API e retornar os dados Json, realizando um tratamento de um possível erro de digitação do cliente
    /// </summary>
    class BuscaCepServices
    {
        public async Task<BuscaCep> GetCepBrasil(int cep)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");

                var jsonString = await response.Content.ReadAsStringAsync();

                BuscaCep objetoJson = JsonConvert.DeserializeObject<BuscaCep>(jsonString);

                return objetoJson;
            }
            catch (Exception ex)
            { 
                Console.WriteLine("OCORREU ALGUM ERRO AO CONSULTAR. POR FAVOR, VERIFIQUE SE O CEP ESTÁ CORRETO", ex);
            }

            return null;
        }
    }
}
