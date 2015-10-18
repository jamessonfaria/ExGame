using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExGame.database
{
    public class DBDataContext : DataContext
    {
        // construtor
        public DBDataContext() : base("isostore:/banco.sdf") { }

        // tabelas usadas
        public Table<Jogo> Jogos;
    }
}
