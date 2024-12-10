using Microsoft.AspNetCore.Mvc;
using CallApi.tool;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace CallApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController
    {
        private readonly DeSerialisation _deSerialisation;

        public ApiController()
        {
            _deSerialisation = new DeSerialisation();
        }

        string connextion =
            "Server=.;" +
           "DataBase=CallApi;" +
           "user=EFcore;" +
           "password=azerty@123;" +
           "TrustServerCertificate=true";

        SqlConnection _connection;


        [HttpUpdate("")]
        public IActionResult InsertUrl(string url) {
           _connection.Open();
           string query = "";
           _connection.Close();
            
        }

        [HttpGet]
        public Models.ApiModels GetGen(string url)
        { 
            var catImages = _deSerialisation.GetCall<List<CatImg>>(url);

            var apiModels = new Models.ApiModels
            {
                catImgs = catImages
            };

            return apiModels;

        }
    }
}
