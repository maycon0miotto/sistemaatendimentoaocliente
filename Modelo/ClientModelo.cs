using System.ComponentModel.DataAnnotations;

namespace mysqlefcore
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string? nome { get; set; }
        public virtual ICollection<Duvida>? Duvidas { get; set; }
        public virtual ICollection<Reclamacao>? Reclamacoes { get; set; }
        public virtual ICollection<Problema>? Problemas { get; set; }
    }
}


//armazena um nome e mantem uma lista de duvidas, reclamação e problemas.
//virtual permite ter subclasses dela.