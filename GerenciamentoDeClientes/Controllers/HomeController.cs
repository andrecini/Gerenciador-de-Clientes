using GerenciamentoDeClientes.Infra.Dal;
using GerenciamentoDeClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;

namespace GerenciamentoDeClientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                //DalHelper.CriarBancoSQLite();
                //DalHelper.CriarTabelaSQlite();

                var clientes = ConverteDataTableClientes(DalHelper.GetClientes());

                return View(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult MudarStatusEncontrado([FromBody]Cliente cliente)
        {
            DalHelper.Update(cliente.Id, cliente.Encontrado);
            var clientes = DalHelper.GetClientes();

            return View("Index", clientes);
        }

        [HttpPost]
        public IActionResult Deletar([FromBody] Cliente cliente)
        {
            DalHelper.Delete(cliente.Id);
            var clientes = DalHelper.GetClientes();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public static List<Cliente> ConverteDataTableClientes(DataTable dt)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string nome = row["nome"].ToString();
                    string embarque = row["embarque"].ToString();
                    string descricao = row["descricao"].ToString();
                    int encontrado = Convert.ToInt32(row["encontrado"]);

                    Cliente cliente = new Cliente 
                    {
                        Id = id,
                        Nome = nome,
                        Embarque = embarque,
                        Descricao = descricao,
                        Encontrado = encontrado
                    };
                    clientes.Add(cliente);
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}