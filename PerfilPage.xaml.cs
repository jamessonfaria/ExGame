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
            DateTime nascimento = (DateTime)dpNascimento.Value;
            Perfil perfil = new Perfil();
            perfil.Nome = tbNome.Text;
            perfil.Email = tbEmail.Text;
            perfil.DataNascimento = nascimento;
            perfil.Senha = pbSenha.Password;
            perfil.Cidade = tbCidade.Text;
            perfil.Estado = tbEstado.Text;

            SalvarPerfilServidor(perfil);
            
        }

        private void LerPerfilPhoneSettings()
        {
            Perfil perfil = PerfilHelper.RecuperarPerfilPhoneSettings();

            tbNome.Text = perfil.Nome;
            tbEmail.Text = perfil.Email;
            dpNascimento.Value = perfil.DataNascimento;
            tbCidade.Text = perfil.Cidade;
            tbEstado.Text = perfil.Estado;
            pbSenha.Password = perfil.Senha;

        }

        private bool SalvarPerfilServidor(Perfil perfil) {
            Perfil atual = PerfilHelper.RecuperarPerfilPhoneSettings();
            bool sucesso = true;
            if(atual.Id == 0)
            {
                //POST
                MessageBox.Show("Enviar POST para o servidor");
                perfil.Id = 1000;
            }
            else
            {
                //PUT
                perfil.Id = atual.Id;
                MessageBox.Show("Enviar PUT para o servidor");

            }

            if (sucesso)
            {
                PerfilHelper.SalvarPerfilPhoneSettings(perfil);
            }
            
            return sucesso;
        }

    }
}