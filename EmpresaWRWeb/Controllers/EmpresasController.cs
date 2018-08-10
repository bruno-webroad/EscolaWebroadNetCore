using AutoMapper;
using EmpresaWRWeb.Data;
using EmpresaWRWeb.Domain;
using EmpresaWRWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpresaWRWeb.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context, IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _context = context;
        }

        public IActionResult Index()
        {
            var enterprisesDomain = _context.Enterprises.ToList();
            var enterprisesVM = _autoMapper.Map<List<Enterprise>, List<EnterpriseVM>>(enterprisesDomain);
            return View(enterprisesVM);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(EnterpriseVM enterpriseVM)
        {
            if (ModelState.IsValid)
            {
                var enterpriseDomain = _autoMapper.Map<EnterpriseVM, Enterprise>(enterpriseVM);
                _context.Enterprises.Add(enterpriseDomain);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Editar(int id)
        {
            var enterpriseDomain = _context.Enterprises.FirstOrDefault(x => x.Id == id);
            if (enterpriseDomain == null) return RedirectToAction("Index");

            var enterpriseVM = _autoMapper.Map<Enterprise, EnterpriseVM>(enterpriseDomain);
            return View(enterpriseVM);
        }

        [HttpPost]
        public IActionResult Editar(EnterpriseVM enterpriseVM)
        {
            if (ModelState.IsValid)
            {
                var enterpriseDomain = _autoMapper.Map<EnterpriseVM, Enterprise>(enterpriseVM);
                _context.Enterprises.Update(enterpriseDomain);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enterpriseVM);
        }

        public IActionResult Deletar(int id)
        {
            var enterpriseDomain = _context.Enterprises.FirstOrDefault(x => x.Id == id);
            if (enterpriseDomain == null) return RedirectToAction("Index");

            var enterpriseVM = _autoMapper.Map<Enterprise, EnterpriseVM>(enterpriseDomain);
            return View(enterpriseVM);
        }

        [HttpPost]
        public IActionResult Deletar(EnterpriseVM enterpriseVM)
        {
            try
            {
                var enterpriseDomain = _autoMapper.Map<EnterpriseVM, Enterprise>(enterpriseVM);
                _context.Enterprises.Remove(enterpriseDomain);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(enterpriseVM);
            }            
        }
    }
}