using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
namespace Biblioteca.Models
{
    public class UsuarioService
    {
         public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                u.Senha = Criptografia.GerarMD5 (u.Senha);
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }
         public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.Login = u.Login;
                usuario.Senha = Criptografia.GerarMD5 (u.Senha);

                bc.SaveChanges();
            }
        }
       public ICollection<Usuario> ListarTodos(FiltroUsuario filtro = null)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Login":
                            query = bc.Usuarios.Where(u => u.Login.Contains(filtro.Filtro));
                        break;


                        default:
                            query = bc.Usuarios;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }
                
                //ordenação padrão
                return query.OrderBy(u => u.Login).ToList();
            }
        }
         public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
          public void DeleteUsuario(int id)
        {
         using (var context = new BibliotecaContext())
            {   
          Usuario registro = context.Usuarios.Find(id);
          context.Usuarios.Remove(registro);
          context.SaveChanges();
            }
        }
       
    }
}