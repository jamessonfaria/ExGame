using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Json;

namespace ExGame
{
    public partial class JogoPage : PhoneApplicationPage
    {
        // objeto geral
        private Object obj;
        private static Jogo jogo;
        ProgressIndicator progress;

        public JogoPage()
        {
            progress = new ProgressIndicator();
            InitializeComponent();          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // recebe objeto
            obj = (App.Current as App).ToPass;
            jogo = (Jogo)obj;

            // foto do jogo
            ImageSource imgSource = new BitmapImage(new Uri(jogo.Foto.ToString(), UriKind.Absolute));
            foto.Source = imgSource;

            // descricao do console
            jogoConsole.Text = jogo.Console;
            // descricao do jogo
            jogoDesc.Text = jogo.Descricao;

            ListaUsuarios(jogo.Id.ToString());

        }

        protected void ListaUsuarios(String id)
        {
            progress.IsVisible = true;
            progress.IsIndeterminate = true;
            progress.Text = "Atualizando Usuários...";

            SystemTray.SetProgressIndicator(this, progress);

            string url = "http://srvwebservice.herokuapp.com/api/v1/usuarios_por_jogo/" + id;

            WebClient client = new WebClient();
            client.OpenReadCompleted += Client_OpenReadCompleted;
            client.OpenReadAsync(new Uri(url, UriKind.Absolute));         
           
        }

        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<JogoPerfil>));
            List<JogoPerfil> jogoPerfils = (List<JogoPerfil>)serializer.ReadObject(e.Result);

            lbUsuarios.ItemsSource = jogoPerfils;
            progress.IsVisible = false;

        }
       
    }

}