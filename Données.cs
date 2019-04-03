using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace librairieGesper
{
    public class Données
    {
        private List<Employe> LesEmployes;
        private List<Service> LesServices;
        private List<Diplome> LesDiplomes;

        public Données()
        {
            this.LesEmployes = new List<Employe>();
            this.LesServices = new List<Service>();
            this.LesDiplomes = new List<Diplome>();
        }
        public void ChargerService()
        {
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "service";
            cmdSql.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                 if (Char.Parse(reader["ser_type"].ToString()) == 'A')
                {
                    Service unService = new Service(Int32.Parse(reader.GetString(0)), (reader.GetString(1)), Char.Parse(reader.GetString(2)), Decimal.Parse(reader.GetString(5)));
                    LesServices.Add(unService);
                }
                 else if (Char.Parse(reader["ser_type"].ToString()) == 'p')
                {
                    Service unService = new Service(Int32.Parse(reader.GetString(0)), (reader.GetString(1)), Char.Parse(reader.GetString(2)), (reader.GetString(3)), Int32.Parse(reader.GetString(4)));
                    LesServices.Add(unService);
                }
                
               
            }

            cnx.Close();
        }

        public void ChargerDiplome()
        {
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "diplome";
            cmdSql.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                Diplome unDiplome = new Diplome((int)reader[0], (string)reader[1]);
                LesDiplomes.Add(unDiplome);
            }

            cnx.Close();
        }

        public void ChargerEmploye()
        {
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "employe";
            cmdSql.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                foreach (Service s in LesServices)
                {
                    if (s.Id == (int)reader[6])
                    {
                        Employe unEmploye = new Employe((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (bool)reader[4], (double)reader[5], s);
                        LesEmployes.Add(unEmploye);
                    }
                }
            }

            cnx.Close();
        }
        public string ChargerLesDiplomesDesEmploye()
        {
            string result = "";
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select dip_id, dip_libelle from employe e inner join posseder p on p.pos_employe = e.emp_id inner join diplome d on d.dip_id = p.pos_diplome order by emp_nom;";
            cmdSql.CommandType = CommandType.Text;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                foreach (Diplome d in LesDiplomes)
                {
                    Diplome unDiplome = new Diplome((int)reader[0], (string)reader[1]);
                    LesDiplomes.Add(unDiplome);
                }
            }

            cnx.Close();
            return result;
        }

        public string ChargerLesTitulairesDesDiplomes()
        {
            string result = "";
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select emp_id, emp_nom, emp_prenom, emp_sexe, emp_cadre, emp_salaire, emp_service from employe e inner join posseder p on p.pos_employe = e.emp_id order by pos_employe;";
            cmdSql.CommandType = CommandType.Text;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                foreach (Service s in LesServices)
                {
                    if (s.Id == (int)reader[6])
                    {
                        Employe unEmploye = new Employe((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (bool)reader[4], (double)reader[5], s);
                        LesEmployes.Add(unEmploye);
                    }
                }
            }

            cnx.Close();
            return result;
        }

        public string ChargerLesEmployeDesServices()
        {
            string result = "";
            MySqlConnection cnx;
            string sCnx;
            // chaîne de caractères de connexion
            sCnx = String.Format("user=root;password=siojjr;database=gesper;host=localhost");
            //création d'un objet connexion
            cnx = new MySqlConnection(sCnx);
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select * from employe order by emp_service;";
            cmdSql.CommandType = CommandType.Text;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                foreach (Service s in LesServices)
                {
                    if (s.Id == (int)reader[6])
                    {
                        Employe unEmploye = new Employe((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (bool)reader[4], (double)reader[5], s);
                        LesEmployes.Add(unEmploye);
                    }
                }

            }

            cnx.Close();
            return result;
        }

        public void AfficherServices()
        {
            foreach (Service s in LesServices)
            {
                Console.WriteLine(s.ToString());
            }
        }
        public void AfficherDiplome()
        {
            foreach (Diplome d in LesDiplomes)
            {
                Console.WriteLine(d.ToString());
            }
        }
        public void AfficherEmployes()
        {
            foreach (Employe e in LesEmployes)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}