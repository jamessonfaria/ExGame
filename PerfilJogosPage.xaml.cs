using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Runtime.Serialization.Json;
using ExGame.database;

namespace ExGame
{
    public partial class PerfilJogosPage : PhoneApplicationPage
    {
        private Perfil perfil;

        private bool configurado = false;

        public PerfilJogosPage()
        {
            perfil = PerfilHelper.RecuperarPerfilPhoneSettings();
            InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            BaixarJogosPerfil();
        }

        private void BaixarJogosPerfil()
        {
            if (perfil.Id != "")
            {
                string url = HttpHelper.URL_JOGOS_USUARIO + "/" + perfil.Id;
                WebClient client = new WebClient();
                client.OpenReadCompleted += Client_OpenReadCompleted;
                client.OpenReadAsync(new Uri(url, UriKind.Absolute));
            }
            else
            {
                tbMensagem.Text = "Perfil não configurado!";
                MessageBox.Show("Perfil não configurado!");
            }
            
        }


        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null) {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<JogoPerfilUsuario>));
                List<JogoPerfilUsuario> jogos = (List<JogoPerfilUsuario>)serializer.ReadObject(e.Result);
                if(jogos.Count == 0)
                {
                    CarregarJogos();
                }
                else
                {
                    configurado = true;
                    List<Jogo> lista = new List<Jogo>();
                    foreach (var item in jogos)
                    {
                        Jogo jogo = new Jogo();
                        jogo.Console = item.Console;
                        jogo.Descricao = item.Descricao;
                        jogo.Foto = item.Foto;
                        jogo.Id = item.JogoId;

                        lista.Add(jogo);
                    }
                    lbJogos.ItemsSource = lista;
                }
                
            }

        }

        private void CarregarJogos()
        {
            // recupera lista de jogos do banco local
            using (var bd = new DBDataContext())
            {
                var res = (from jogos in bd.Jogos select jogos).ToList();
                lbJogos.ItemsSource = res;
            }
        }

        private void PesquisarJogos()
        {
            //string str = tbPesquisa.Text;
            string str = "";
            // pesquisa lista de jogos do banco local
            using (var bd = new DBDataContext())
            {
                var res = (from jogos in bd.Jogos where jogos.Descricao.Contains(str) select jogos).ToList();
                lbJogos.ItemsSource = res;
            }

        }

        private void tbPesquisa_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            PesquisarJogos();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!configurado)
            {
                Jogo jogo = (Jogo)((CheckBox)sender).DataContext;
                WebClient client = new WebClient();
                JogoPerfil jogoPerfil = new JogoPerfil();
                jogoPerfil.PerfilId = int.Parse(perfil.Id);
                jogoPerfil.JogoId = jogo.Id;
                string json = HttpHelper.serializar(jogoPerfil);
                client.Headers["Content-Type"] = "application/json";
                client.UploadStringAsync(new Uri(HttpHelper.URL_JOGO_PERFILS), "POST", json);
            }
            
        }

        
    }
}