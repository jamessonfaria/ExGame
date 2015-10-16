using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ExGame
{
    public partial class PerfilPage : PhoneApplicationPage
    {
        public PerfilPage()
        {
            InitializeComponent();
            Iniciar_PhoneSettings();
        }

        private void Iniciar_PhoneSettings()
        {
            //no primeiro acesso criar as phonesettings vazias para que o usuário possa voltar pra tela inicial mesmo sem salvar seu perfil
        }
        private void btCadastrarPerfil_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cadastro Realizado com Sucesso");
        }
    }
}