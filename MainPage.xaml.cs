﻿using System;
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
using ExGame.database;

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
            if (!PerfilHelper.PerfilCriado())
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
            Uri destino = new Uri("/ConfiguracoesPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        private void ConfigurarPerfil() {
            Uri destino = new Uri("/PerfilPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        

        private void BaixarJogos()
        {
            //verificar se jogos já foram baixados
            if (ExisteJogos() == 0)
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
            else
            {
                // recupera lista de jogos do banco local
                using (var bd = new DBDataContext())
                {
                    var res = (from jogos in bd.Jogos select jogos).ToList();
                    lbJogos.ItemsSource = res;
                }           
            }    
                                   
        }

        private int ExisteJogos()
        {
            using (var bd = new DBDataContext())
            {
                var res = (from jogo in bd.Jogos select jogo).Count();
                return res;
            }          
        }

        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Jogo>));
            List<Jogo> jogos = (List<Jogo>)serializer.ReadObject(e.Result);

            using (var bd = new DBDataContext())
            {
                // inserir os jogos no database local
                foreach (Jogo jogo in jogos){                    
                    bd.Jogos.InsertOnSubmit(jogo);                    
                }

                bd.SubmitChanges();
            }

            lbJogos.ItemsSource = jogos;
            progress.IsVisible = false;

        }

        private void Button_Detalhe_Click(object sender, RoutedEventArgs e)
        {
            //pega o objeto selecionado.
            Jogo selecionado = (Jogo)((Button)sender).DataContext;

            (Application.Current as App).ToPass = selecionado;

            Uri destino = new Uri("/JogoPage.xaml", UriKind.Relative);
            NavigationService.Navigate(destino);
        }

        
    }
}