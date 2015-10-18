using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace ExGame
{
    public partial class PerfilPage : PhoneApplicationPage

    {

        public PerfilPage()
        {
            InitializeComponent();
            IniciarPhoneSettings();
            LerPerfilPhoneSettings();
        }

        private void IniciarPhoneSettings()
        {
            PerfilHelper.IniciarPerfilPhoneSettings();

        }
        private void btCadastrarPerfil_Click(object sender, RoutedEventArgs e)
        {
            SalvarPerfil();
            MessageBox.Show("Cadastro Realizado com Sucesso");
        }

        private void SalvarPerfil()
        {
            Perfil atual = PerfilHelper.RecuperarPerfilPhoneSettings();
            DateTime nascimento = (DateTime)dpNascimento.Value;
            atual.Nome = tbNome.Text;
            atual.Email = tbEmail.Text;
            atual.DataNascimento = nascimento;
            atual.Senha = pbSenha.Password;
            atual.Cidade = tbCidade.Text;
            atual.Estado = tbEstado.Text;
            SalvarPerfilServidor(atual);
            
        }

        private void LerPerfilPhoneSettings()
        {
            Perfil perfil = PerfilHelper.RecuperarPerfilPhoneSettings();

            tbNome.Text = perfil.Nome;
            tbEmail.Text = perfil.Email;
            dpNascimento.Value = perfil.DataNascimento;
            //tbCidade.Text = perfil.Cidade;
            //tbEstado.Text = perfil.Estado;
            pbSenha.Password = perfil.Senha;

        }

        private void SalvarPerfilServidor(Perfil perfil) {
            PerfilHelper.SalvarPerfilServidor(perfil);
            
        }

    }
}