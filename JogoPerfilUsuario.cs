using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    [DataContract]
    class JogoPerfilUsuario
    {

        [DataMember(Name = "jogo_id")]
        public int JogoId { get; set; }

        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        [DataMember(Name = "console")]
        public string Console { get; set; }

        //url da imagem da foto
        [DataMember(Name = "foto")]
        public string Foto { get; set; }
    }

}
