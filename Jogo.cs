using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    [Table]
    [DataContract]
    public class Jogo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated=true)]
        public int Seq { get; set; }

        [Column]
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        [Column]
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        [Column]
        [DataMember(Name = "console")]
        public string Console { get; set; }

        //url da imagem da foto
        [Column]
        [DataMember(Name = "foto")]
        public string Foto { get; set; }
    }
}
