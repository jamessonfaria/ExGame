using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExGame
{
    
    class HttpHelper
    {
        public const string URL_JOGOS    = "https://srvwebservice.herokuapp.com/api/v1/jogos";
        public const string URL_PERFILS  = "https://srvwebservice.herokuapp.com/api/v1/perfils";
        public const string URL_JOGO_PERFILS   = "https://srvwebservice.herokuapp.com/api/v1/jogo_perfils";
        public const string URL_TROCA_JOGOS    = "https://srvwebservice.herokuapp.com/api/v1/trocajogos";
        public const string URL_PROPOSTA_JOGOS = "https://srvwebservice.herokuapp.com/api/v1/propostajogos";
        public const string URL_JOGOS_USUARIO = "https://srvwebservice.herokuapp.com/api/v1/jogos_por_usuario";

        public static string serializar<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static T deserializar<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;
            return (T)serializer.ReadObject(stream);
        }

    }
}
