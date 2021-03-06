﻿using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExGame
{
    class PerfilHelper
    {
        private const string CHAVE_ID = "id";
        private const string CHAVE_NOME = "nome";
        private const string CHAVE_EMAIL = "email";
        private const string CHAVE_DATA = "data";
        private const string CHAVE_CIDADE = "cidade";
        private const string CHAVE_ESTADO = "estado";
        private const string CHAVE_SENHA = "senha";

        public static void IniciarPerfilPhoneSettings()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            //no primeiro acesso criar as phonesettings vazias para que o usuário 
            //possa voltar pra tela inicial mesmo sem salvar seu perfil

            if (!PerfilCriado())
            {
                settings[CHAVE_ID] = "";
                settings[CHAVE_EMAIL] = "";
                settings[CHAVE_NOME] = "";
                settings[CHAVE_SENHA] = "";
                settings[CHAVE_CIDADE] = "";
                settings[CHAVE_DATA] = DateTime.Now;
                settings[CHAVE_ESTADO] = "";
                settings.Save();
            }
            
        }

        public static bool PerfilCriado()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            return settings.Contains(CHAVE_ID);
        }

        public static void SalvarPerfilPhoneSettings(Perfil perfil)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            settings[CHAVE_ID] = perfil.Id;
            settings[CHAVE_NOME] = perfil.Nome;
            settings[CHAVE_EMAIL] = perfil.Email;
            //settings[CHAVE_DATA] = perfil.DataNascimento;
            settings[CHAVE_SENHA] = perfil.Senha;
            settings[CHAVE_CIDADE] = perfil.Cidade;
            settings[CHAVE_ESTADO] = perfil.Estado;
            settings.Save();
        }

        public static Perfil RecuperarPerfilPhoneSettings()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            Perfil perfil = new Perfil();

            perfil.Id = settings[CHAVE_ID].ToString();
            perfil.Nome = settings[CHAVE_NOME].ToString();
            perfil.Email = settings[CHAVE_EMAIL].ToString();
            //perfil.DataNascimento = settings[CHAVE_DATA].ToString();
            perfil.Cidade = settings[CHAVE_CIDADE].ToString();
            perfil.Estado = settings[CHAVE_ESTADO].ToString();
            perfil.Senha = settings[CHAVE_SENHA].ToString();

            return perfil;
        }

        public static void SalvarPerfilServidor(Perfil perfil, UploadStringCompletedEventHandler callback)
        {
            string metodo = perfil.Id == "" ? "POST" : "PUT";
            string url = perfil.Id == "" ? HttpHelper.URL_PERFILS :HttpHelper.URL_PERFILS + "/" + perfil.Id;
            string json = HttpHelper.serializar(perfil);

            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.UploadStringCompleted += callback;
            client.UploadStringAsync(new Uri(url, UriKind.Absolute), metodo, json);

        }
    }
}
