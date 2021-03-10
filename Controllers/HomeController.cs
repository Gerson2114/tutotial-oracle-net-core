using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using OracleApplication.Intefaces;
using OracleApplication.Models;

namespace OracleApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuario _usuario;
        public HomeController(ILogger<HomeController> logger, IUsuario usuario)
        {
            _logger = logger;
            _usuario = usuario;
        }

        public IActionResult Index()
        {
            try
            {
                //OracleConfiguration.TnsAdmin = @"C:\Users\gerson.alonso\Downloads\Wallet_DB202101231546\tnsnames.ora";
                //OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
                var users = _usuario.usuarios();
                //var users = _contex.usuario.ToList();
            }
            catch (Exception ex)
            {
                var msn = ex.Message;
                throw;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
