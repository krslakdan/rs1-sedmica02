using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MojaApp.API.Controllers.Dtos;
using MojaApp.API.Data;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(MyDbContext db) : ControllerBase
    {
        [HttpGet("{id}")]
        public StudentGetByIdResponse GetById(int id)
        {
            var s = db.Students.Where(x => x.Id == id).Select(x => new StudentGetByIdResponse(
                x.Id,
                x.Ime,
                x.Prezime,
                x.SlikaStudenta,
                x.OpstinaRodjenja == null ? null : new StudentGetByIdResponseOpstina(x.OpstinaRodjenja.description, "123"))).FirstOrDefault();

            if (s == null)
                throw new Exception("nema studenta");
            return s;
        }

        [HttpPost]
        public int Add([FromBody]StudentDodajRequest request)
        {
            var maxID = db.Students.Max(x => x.Id);

            var s = new Student
            {
                Id = maxID + 1,
                Ime = request.Ime,
                Prezime = request.Prezime,
                BrojIndeksa="",
                OpstinaRodjenjaId=request.OpstinaRodjenjaId,
                DatumRodjenja=request.DatumRodjenja,
                CreatedTime=DateTime.UtcNow,
                SlikaStudenta="/nesto.jpg"
            };
            db.Students.Add(s);
            db.SaveChanges();
            return s.Id;
        }

        [HttpDelete]
        public IActionResult Obrisi(int studentId)
        {
            var s=db.Students.FirstOrDefault(x=>x.Id == studentId);
            if (s is null)
                return BadRequest();
            db.Students.Remove(s);
            db.SaveChanges();
            return Ok();
        }
        
        [HttpGet]
        public List<StudentGetAllResponse> GetAll()
        {
            return db.Students.Select(x => new StudentGetAllResponse(
                x.Id,
                x.Ime,
                x.Prezime,
                x.OpstinaRodjenja == null ? null : new StudentGetAllResponseOpstina(x.OpstinaRodjenja.description, "123")
                )).ToList();
        }
    }
}
