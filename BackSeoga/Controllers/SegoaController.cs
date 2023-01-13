using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegoaController : ControllerBase
    {
        [HttpGet]
        [Route("meteogalicia")]
        public async Task<string> GetTest(int idConcello)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://servizos.meteogalicia.gal/mgrss/predicion/jsonPredConcellos.action?idConc={idConcello}");

            var continentList = JsonConvert.DeserializeObject<Seoga>(json);

            var str = impPant(continentList);


            return str;
        }

        private string? impPant(Seoga seoga)
        {
            string res = "Nombre de la ciudad: " + seoga.predConcello.nome +"\n \n";

            foreach (var dia in seoga.predConcello.listaPredDiaConcello)
            {
                res = res + "Dia: " + dia.dataPredicion.ToString("dd/MM/yyyy") + "\n";

                res = res + "\t Mañana: " + conversionTiempo(dia.ceo.manha) + "\n";
                res = res + "\t Tarde: " + conversionTiempo(dia.ceo.tarde) + "\n";
                res = res + "\t Noche: " + conversionTiempo(dia.ceo.noite) + "\n";

                res = res + "\t Temperatura Maxima: " + dia.tMax + "ºC \n";
                res = res + "\t Temperatura Minima: " + dia.tMin + "ºC \n";

                res = res + "\t Porcentaje de lluvia por la mañana: " + revisionPorcentaje(dia.pchoiva.manha) + " \n";
                res = res + "\t Porcentaje de lluvia por la tarde: " + revisionPorcentaje(dia.pchoiva.tarde) + " \n";
                res = res + "\t Porcentaje de lluvia por la noche: " + revisionPorcentaje(dia.pchoiva.noite) + " \n \n";

            }

            return res;
        }

        private string revisionPorcentaje(int porcentaje)
        {
            string res;

            if (porcentaje == -9999) {
                res = "*No Disponible*";
            }
            else
            {
                res = porcentaje + " %";
            }

            return res; 
        }
        private string conversionTiempo(int id)
        {
            var state = new Dictionary<int, string>()
            {
                { 101, "Despejado" },
                { 102, "Nubes altas" },
                { 103, "Nubes y claros" },
                { 104, "Nublado (75%)" },
                { 105, "Cubierto" },
                { 106, "Nieblas" },
                { 107, "Chubasco" },
                { 108, "Chubasco (75%)" },
                { 109, "Chubasco nieve" },
                { 110, "Llovizna" },
                { 111, "Lluvia" },
                { 112, "Nieve" },
                { 113, "Tormenta" },
                { 114, "Bruma" },
                { 115, "Bancos de niebla" },
                { 116, "Nubes medias" },
                { 117, "Lluvia débil" },
                { 118, "Chubascos débiles" },
                { 119, "Tormenta con pocas nubes" },
                { 120, "Agua nieve" },
                { 121, "Granizo" },
                { 201, "Despejado" },
                { 202, "Nubes altas" },
                { 203, "Nubes y claros" },
                { 204, "Nublado (75%)" },
                { 205, "Cubierto" },
                { 206, "Nieblas" },
                { 207, "Chubasco" },
                { 208, "Chubasco (75%)" },
                { 209, "Chubasco nieve" },
                { 210, "Llovizna" },
                { 211, "Lluvia" },
                { 212, "Nieve" },
                { 213, "Tormenta" },
                { 214, "Bruma" },
                { 215, "Bancos de niebla" },
                { 216, "Nubes medias" },
                { 217, "Lluvia débil" },
                { 218, "Chubascos débiles" },
                { 219, "Tormenta con pocas nubes" },
                { 220, "Agua nieve" },
                { 221, "Granizo Calma" },
                { -9999, "No disponible" },
            };

            return state[id];
        }

    }
}
