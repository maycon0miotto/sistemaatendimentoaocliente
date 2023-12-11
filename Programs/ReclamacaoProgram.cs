using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace mysqlefcore
{
    class ReclamacaoProgram
    {
        static void Main(string[] args, string nomeUsuario, string desc, DateTime data)
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

                var reclamacao = new Reclamacao
                {
                    desc = desc,
                    data = data,
                    Usuario = usuario,
                    id_usuario_reclamacoes = usuario.id
                };

                context.Reclamacao?.Add(reclamacao);
                context.SaveChanges();
            }
        }

        public static void PrintData()
        {
        
        
            using (var context = new ClientContext())
            {
                var reclamacoes = context.Reclamacao?
                  .Include(p => p.Usuario);
                foreach (var reclamacao in reclamacoes ?? Enumerable.Empty<Reclamacao>())
                {
                    var data = new StringBuilder();
                    data.AppendLine($"\n--------------------\\---------------------");
                    data.AppendLine($"desc: {reclamacao.desc}");
                    data.AppendLine($"data: {reclamacao.data}");
                    data.AppendLine($"Usuario: {reclamacao.Usuario?.nome}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}