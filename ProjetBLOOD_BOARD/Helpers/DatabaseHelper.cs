using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Diagnostics;
using ProjetBLOOD_BOARD.Core.Model;
using System.Collections.ObjectModel;
using System.Data;


namespace ProjetBLOOD_BOARD.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = "Data Source=DESKTOP-FAKAJVL\\SQLEXPRESS;Initial Catalog = testemaivana; Integrated Security = True;";

       /* public static void EnregistrerDonnees(string donnee1, string donnee2)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Utilisateurs (nom, mot_de_passe) VALUES (@nom, @mot_de_passe);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", donnee1);
                    command.Parameters.AddWithValue("@mot_de_passe", donnee2);
                    Debug.WriteLine(query);
                    command.ExecuteNonQuery();
                }
            }
        }*/

        /*public static string recuperationDonnee(string donnee1)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT nom FROM Utilisateurs WHERE id = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", donnee1);
                    Debug.WriteLine(query);
                    return (string)command.ExecuteScalar();
                }
            }
        }*/

        public static bool testeLOGIN(string nom, string mdp)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Utilisateurs WHERE nom = @nom AND mot_de_passe = @mot_de_passe;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@mot_de_passe", mdp);
                    Debug.WriteLine(query);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }


        /* public static ObservableCollection<LoginModel> ObtenirDonneeDepuisLaBaseDeDonnees()
         {
             ObservableCollection<LoginModel> Donnees;
             using (SqlConnection connection = new SqlConnection(ConnectionString))
             {
                 connection.Open();
                 string query = "SELECT * FROM Utilisateurs";                // Remplacez VotreTable par le nom de votre table
                 using (SqlCommand command = new SqlCommand(query, connection))
                 {
                     DataTable dt = new DataTable();
                     SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                     DataSet dataSet = new DataSet();
                     dataAdapter.Fill(dataSet, "Donnee");
                     Donnees = new ObservableCollection<LoginModel>();

                     foreach (DataRow dr in dataSet.Tables[0].Rows)
                     {
                         Donnees.Add(new LoginModel((int)dr[0], dr[1].ToString(), dr[2].ToString()));
                     }
                 }
             }
             return Donnees;
         }*/

        /*public static void SupprimmeDonneeDeLaBaseDeDonnees(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Utilisateurs WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int i = command.ExecuteNonQuery();//retourne le nombre de ligne supprimmer dans notre cas.
                }
            }
        }*/
    }
}
