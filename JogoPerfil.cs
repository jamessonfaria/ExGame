using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    [DataContract]
    public class JogoPerfil
    {
        [DataMember(Name = "jogo_perfil_id")]
        public int JogoPerfilId { get; set; }

        [DataMember(Name = "perfil_id")]
        public int PerfilId { get; set; }

        [DataMember(Name = "jogo_id")]
        public int JogoId { get; set; }

        [DataMember(Name = "nome")]
        public String Nome { get; set; }

        [DataMember(Name = "cidade")]
        public String Cidade { get; set; }

        [DataMember(Name = "estado")]
        public String Estado { get; set; }
    
    }
}
