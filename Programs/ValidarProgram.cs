using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace mysqlefcore
{
    class ValidarProgram
    {

        private static bool VerificarUsuario(string? nomeUsuario)
        {
            
            using (var dbContext = new ClientContext())
            {
                
                var usuario = dbContext.Usuario.FirstOrDefault(e => e.nome == nomeUsuario);

                
                if (usuario != null)
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
        }
        public static bool ValidarUsuario(string? nomeUsuario)
        {
            return VerificarUsuario(nomeUsuario);
        }

    }
}