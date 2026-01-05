using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPMS2026_Web_R1.Data;
using RPMS2026_Web_R1.DTOs;

namespace RPMS2026_Web_R1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodlinesController : ControllerBase
    {
        private Rpms2026WebContext _context;

        public BloodlinesController(Rpms2026WebContext context)
        {
            _context = context;
        }

        // GET: api/bloodline
        //[HttpGet]
       // public async Task<ActionResult<IEnumerable<Bloodline>>> GetBloodlines()
       // {
       //     var items = await _context.Bloodlines
         //       .OrderBy(b => b.Desc) // optional
         //       .ToListAsync();

         //   return Ok(items);
        //}

        [HttpGet]
        public async Task<ActionResult> GetBloodlines()
        {
            var queryString = Request.Query;
            
            var skip = queryString.ContainsKey("$skip") ? int.Parse(queryString["$skip"]) : 0;
            var take = queryString.ContainsKey("$top") ? int.Parse(queryString["$top"]) : 12;
            
            var query = _context.Bloodlines.AsQueryable();
            
            var totalCount = await query.CountAsync();
            
            var items = await query
                .Skip(skip)
                .Take(take)
                .Select(b => new Bloodline_ALLDTO
                {
                    Id = b.Id,
                    Code = b.Code,
                    Desc = b.Desc,
                    Type = b.Type,
                    Status = b.Status,
                    BirdCount = _context.Birds.Count(bird => bird.IdBloodline == b.Id)
                })
                .ToListAsync();

            return Ok(new { result = items, count = totalCount });
        }


        //[HttpGet]

        //public async Task<ActionResult<IEnumerable<Bloodline>>> GetByCode(string code)
        //{
        //var bloodlines = await _context.Bloodlines.ToList;
        //return Ok(bloodlines);
        // }

        //public object GetBloodlines()
        //{
        //  return GetBloodlines new{ Items = _context.Bloodlines.ToList() };
        //return new { Items = _context.Bloodlines, Count = _context.Bloodlines.Count() };
        //}

        [HttpPost]

        public void Post([FromBody] Bloodline newbloodline)
        {
            _context.Bloodlines.Add(newbloodline);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Bloodline updatedbloodline)
        {
            //Add more here as per 'Connecting SQL Data to Blazor DataGrid using Web API Adaptor and EF with Syncfusion
            // Video 6:47 Create API Service
            
            _context.Bloodlines.Update(updatedbloodline);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            var bloodlineToDelete = _context.Bloodlines.Find(id);

            //Will need to confirm no Birds have this Bloodline before deleting or it would corrupt integrity
            //Another way would be to cascade delete all Birds with this Bloodline, but that is not desired here
            // or set status to Deleted instead of actually deleting
            // alternative code
            //Bloodline deleteingBloodline = _context.Bloodlines.Where(b => b.Id.Equals(id)).FirstOrDefault();
            //Video 7:16


            if (bloodlineToDelete != null)
            {
                _context.Bloodlines.Remove(bloodlineToDelete);
                _context.SaveChanges();
            }
        }

        

    }
}
