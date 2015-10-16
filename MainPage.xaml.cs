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

namespace ExGame
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Verificar se é o primeiro acesso do usuário através de consulta ao PhoneSettings
            if (false)
            {
                Configurar_Perfil();
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

        private void Configurar_Perfil() {
            Uri destino = new Uri("/PerfilPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

    }
}