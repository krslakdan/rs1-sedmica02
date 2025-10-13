﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MojaApp.API.Data;
using MojaApp.API.Models;

namespace MojaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public Student GetById(int id)
        {
            var s = StudentStorage.Students.FirstOrDefault(x => x.Id == id);
            if (s == null)
                throw new Exception("nema studenta");
            return s;
        }

        [HttpPost]
        public Student Add(string ime, string prezime)
        {
            var maxID = StudentStorage.Students.Max(x => x.Id);
            var s = new Student
            {
                Id = maxID + 1,
                Ime = ime,
                Prezime = prezime
            };
            StudentStorage.Students.Add(s);
            return s;
        }
    }
}
