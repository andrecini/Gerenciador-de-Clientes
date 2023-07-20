using GerenciamentoDeClientes.Infra.Dal;
using GerenciamentoDeClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GerenciamentoDeClientes.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (!cliente.ValidarCliente())
            {
                return BadRequest("Cliente cadastrado incorretamente!");
            }

            DalHelper.Add(cliente);

            return RedirectToAction("Index", "Home");
        }
    }
}
