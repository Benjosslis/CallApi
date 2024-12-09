using CallApi.tool;
using Microsoft.EntityFrameworkCore;

namespace CallApi.Api.Models
{
    public class ApiModels
    {
        public int Id { get; set; }

        public List<CatImg> catImgs { get; set; }
    }
}
