using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc2_leonardo.Data;
using pc2_leonardo.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;


namespace pc2_leonardo.Controllers
{
    public class Cuenta_BancariaController : Controller
    {
        private readonly ILogger<Cuenta_BancariaController> _logger;
        private readonly ApplicationDbContext _context;

        public Cuenta_BancariaController(ILogger<Cuenta_BancariaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre_Titular,Tipo_Cuenta,SaldoInicial,Email")] CuentaBancarias cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                
                TempData["Message"] = "Cuenta creada con éxito."; // Usa TempData para almacenar el mensaje

                return RedirectToAction("Index");
            }

            return View("Index");
        }
        
        public IActionResult ListarCuentas()
        {
            var cuentas = _context.DataCuentaBancarias.ToList();
            return View("ListarCuentas", cuentas); // Asegúrate de que este nombre coincida con tu archivo .cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}