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

namespace ExGame
{
    public partial class JogoPage : PhoneApplicationPage
    {
        // objeto geral
        private Object obj;
        private static Jogo jogo;

        public JogoPage()
        {
            InitializeComponent();          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // recebe objeto
            obj = (App.Current as App).ToPass;           
            jogo = (Jogo)obj;

            pv1.Header = jogo.Descricao;
            
            // foto do jogo
            ImageSource imgSource = new BitmapImage(new Uri(jogo.Foto.ToString(), UriKind.Absolute));            
            foto.Source = imgSource;

            // descricao do console
            jogoConsole.Text = "Console: " + jogo.Console;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            jogo = (Jogo)obj;

            MessageBox.Show(jogo.Descricao + " - " + jogo.Id.ToString() + "-" + jogo.Console);
        }


       
    }

}