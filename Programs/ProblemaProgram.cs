using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace mysqlefcore
{
    class ProblemaProgram
    {
        static void Main(string[] args, string nomeUsuario, string desc,  DateTime data)
        {
            InsertData(nomeUsuario, desc, data);
            PrintData();
        }

        public static void InsertData(string? nomeUsuario, string? desc, DateTime data)
        {
            using (var context = new ClientContext())
            {
                
                context.Database.EnsureCreated();

            
                var usuario = new Usuario
                {
                    nome = nomeUsuario
                };

                context.Usuario?.Add(usuario);
                context.SaveChanges();

                var problema = new Problema
                {
                    desc = desc,
                    data = data,
                    Usuario = usuario,
                    id_usuario_problema = usuario.id
                };

                context.Problema?.Add(problema);
                context.SaveChanges();
            }
        }

        public static void PrintData()
        {
            
        
            using (var context = new ClientContext())
            {
                var problemas = context.Problema?
                  .Include(p => p.Usuario);
                foreach (var problema in problemas ?? Enumerable.Empty<Problema>())
                {
                    var data = new StringBuilder();
                    data.AppendLine("---------------------\\-------------------");
                    data.AppendLine($"desc: {problema.desc}");
                    data.AppendLine($"data: {problema.data}");
                    data.AppendLine($"Usuario: {problema.Usuario?.nome}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}