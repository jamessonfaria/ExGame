using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ExGame.Resources;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;

namespace ExGame
{
    public partial class MainPage : PhoneApplicationPage
    {

        ProgressIndicator progress;

        // Constructor
        public MainPage()
        {
            progress = new ProgressIndicator();
            InitializeComponent();
            BaixarJogos();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Verificar se é o primeiro acesso do usuário através de consulta ao PhoneSettings
            if (false)
            {
                ConfigurarPerfil();
            }
        }


        private void ApplicationBarIconButton_Perfil_Click(object sender, EventArgs e)
        {
            Uri destino = new Uri("/PerfilPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        private void ApplicationBarIconButton_Jogos_Click(object sender, EventArgs e)
        {
            Uri destino = new Uri("/PerfilJogosPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        private void ApplicationBarIconButton_Configuracoes_Click(object sender, EventArgs e)
        {
            Uri destino = new Uri("/ConfiguacoesPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        private void ConfigurarPerfil() {
            Uri destino = new Uri("/PerfilPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        

        private void BaixarJogos()
        {
            progress.IsVisible = true;
            progress.IsIndeterminate = true;
            progress.Text = "Baixando Jogos...";

            SystemTray.SetProgressIndicator(this, progress);

            string url = "https://srvwebservice.herokuapp.com/api/v1/jogos";

            WebClient client = new WebClient();
            client.OpenReadCompleted += Client_OpenReadCompleted;
            client.OpenReadAsync(new Uri(url, UriKind.Absolute));

        }

        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Jogo>));
            List<Jogo> jogos = (List<Jogo>)serializer.ReadObject(e.Result);
            lbJogos.ItemsSource = jogos;
            progress.IsVisible = false;

        }

    }
}