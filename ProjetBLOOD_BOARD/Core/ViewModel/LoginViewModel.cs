using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetBLOOD_BOARD.Core;
using System.Windows.Input;
using ProjetBLOOD_BOARD.Core.Model; 
using System.Windows;
//using System.Windows.Navigation;
using ProjetBLOOD_BOARD.Core.Utilities;
using ProjetBLOOD_BOARD.Services;
using ProjetBLOOD_BOARD.Modules.ModuleSelection;
using ProjetBLOOD_BOARD.Modules.ModuleSecretaire;
using ProjetBLOOD_BOARD.Modules.ModuleAdministrateur;
using ProjetBLOOD_BOARD.Modules.ModulePrelevement;
using ProjetBLOOD_BOARD.Modules.ModuleLaboratoire;
//using System.Data.SqlClient;
using ProjetBLOOD_BOARD.Helpers;

namespace ProjetBLOOD_BOARD.Core.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            // Le nom d'utilisateur ou le mot de passe est vide ou ne contient que des espaces
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe vide.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (IsValidCredentials(Username, Password))
            {
               if (IsSecretaireModule(Username))
                {
                    NavigationService.NavigateTo(new SecretaireMainWindow());
                }
                else if (IsSelectionModule(Username))
                {
                    NavigationService.NavigateTo(new SelectionMainWindow());
                }
                else if (IsAdministrateurModule(Username))
                {
                    NavigationService.NavigateTo(new AdministrateurMainWindow());
                }
                else if (IsLaboratoireModule(Username))
                {
                    NavigationService.NavigateTo(new LaboratoireMainWindow());
                }
                else if (IsPrelevementModule(Username))
                {
                    NavigationService.NavigateTo(new PrelevementMainWindow());
                }
            }
            else
            {
                // Affichez un message d'erreur si les informations d'identification sont invalides
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidCredentials(string Username, string Password)
        {
            // Remplacez cette logique avec une vérification réelle en base de données     
            if (DatabaseHelper.testeLOGIN(Username, Password))
            {
                return true;
            }
            else return false;
        }

        private bool IsSecretaireModule(string Username)
        {
            // Vérifiez si le nom d'utilisateur commence par "secretaire"
            return Username.StartsWith("secretaire", StringComparison.OrdinalIgnoreCase);
        }


        private bool IsSelectionModule(string Username)
        {
            // Vérifiez si le nom d'utilisateur commence par "selection"
            return Username.StartsWith("selection", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsAdministrateurModule(string Username)
        {
            // Vérifiez si le nom d'utilisateur commence par "administrateur"
            return Username.StartsWith("administrateur", StringComparison.OrdinalIgnoreCase);
        }


        private bool IsLaboratoireModule(string Username)
        {
            // Vérifiez si le nom d'utilisateur commence par "laboratoire"
            return Username.StartsWith("laboratoire", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsPrelevementModule(string Username)
        {
            // Vérifiez si le nom d'utilisateur commence par "prelevement"
            return Username.StartsWith("prelevement", StringComparison.OrdinalIgnoreCase);
        }


    }

}
