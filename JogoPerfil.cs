using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    [DataContract]
    class JogoPerfil
    {
        [DataMember(Name = "jogo_id")]
        public int JogoId { get; set; }

        [DataMember(Name = "perfil_id")]
        public int PerfilId { get; set; }
    }
}
