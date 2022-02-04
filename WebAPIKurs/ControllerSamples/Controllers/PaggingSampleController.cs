using ControllerSample.SharedLib;
using ControllerSamples.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaggingSampleController : ControllerBase
    {
        private readonly MovieDbContext context;

        public PaggingSampleController(MovieDbContext context)
        {
            this.context = context;
        }

        [HttpGet("EasyPaggingList")]
        public async Task<ActionResult<IEnumerable<Movie>>> PaggingSample1(int pageNumber = 1, int pageSize = 3)
        {
            return await context.Movie.OrderBy(o => o.Title)
                                      .Skip((pageNumber - 1) * pageSize) //Skip -> wieviele Elemente ignoriere ich 
                                      .Take(pageSize).ToListAsync(); //Take nehme ab Position die nächsten z.b 3 Datensätze
        }

        [HttpGet("WithPageParameterObj")]
        public async Task<ActionResult<IEnumerable<Movie>>> PaggingSample2([FromQuery] PageParameter parameter)
        {
            return await context.Movie.OrderBy(o => o.Title)
                                      .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                                      .Take(parameter.PageSize).ToListAsync();
        }
    }


    public class PageParameter
    {
        const int maxPageSize = 5;


        public int PageNumber { get; set; } = 1;
        private int pageSize = 3;

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
