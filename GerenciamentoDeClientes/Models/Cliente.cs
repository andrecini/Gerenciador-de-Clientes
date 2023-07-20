using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.FileProviders;
using System.Reflection.PortableExecutable;

namespace GerenciamentoDeClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Embarque { get; set; }

        public string Descricao { get; set; }

        public int Encontrado { get; set; }

        public bool ValidarCliente()
        {
            if (!string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Embarque))
            {
                return true;
            }

            return false;
        }

    }
}
