using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaWRWeb.Data;
using EmpresaWRWeb.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaWRWeb.Controllers
{
    [Route("api/[Controller]")]
    public class ApiEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApiEmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll([FromHeader] string apikey)
        {
            if (string.IsNullOrWhiteSpace(apikey)) return new ObjectResult(new { Error = "Não autenticado." });
            var enterprises = _context.Enterprises.ToList();
            return new ObjectResult(enterprises);
        }

        [HttpGet("{id}", Name = "GetEnterprise")]
        public IActionResult GetById(int id)
        {
            var enterprise = _context.Enterprises.FirstOrDefault(x => x.Id == id);
            if (enterprise == null) return new ObjectResult(new { Error = "Empresa não encontrada." });

            return new ObjectResult(enterprise);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Enterprise enterprise)
        {
            try
            {
                _context.Enterprises.Add(enterprise);
                _context.SaveChanges();
                return CreatedAtRoute("GetEnterprise", new { id = enterprise.Id }, enterprise);
            }
            catch (Exception)
            {
                return BadRequest();   
            }            
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Enterprise enterprise)

        {
            var enterpriseOriginal = _context.Enterprises.FirstOrDefault(x => x.Id == enterprise.Id);
            if (enterpriseOriginal == null) new ObjectResult(new { Error = "Empresa não encontrada." });

            try
            {
                enterpriseOriginal.Name = enterprise.Name;
                enterpriseOriginal.City = enterprise.City;
                enterpriseOriginal.Address = enterprise.Address;
                _context.Enterprises.Update(enterpriseOriginal);
                _context.SaveChanges();

                return CreatedAtRoute("GetEnterprise", new { id = enterprise.Id }, enterprise);
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enterprise = _context.Enterprises.FirstOrDefault(x => x.Id == id);
            if (enterprise == null) new ObjectResult(new { Error = "Empresa não encontrada." });

            try
            {
                _context.Enterprises.Remove(enterprise);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }
    }
}