using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
         public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }
    }
}