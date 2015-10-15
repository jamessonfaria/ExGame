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

        private void btCadastrarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Teste");
        }
    }
}