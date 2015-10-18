using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    [DataContract]
    class Perfil
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "senha")]
        public string Senha { get; set; }

        [DataMember(Name = "dt_nasc")]
        public string DataNascimento { get; set; }

        [DataMember(Name = "endereco")]
        public string Endereco { get; set; }

        [DataMember(Name = "cidade")]
        public string Cidade { get; set; }

        [DataMember(Name = "estado")]
        public string Estado { get; set; }
    }
}
