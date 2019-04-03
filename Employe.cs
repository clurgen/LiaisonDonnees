using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librairieGesper
{
    public class Employe
    {
        private bool cadre;
        private int id;
        private string nom;
        private string prenom;
        private double salaire;
        private string sexe;
        private List<Diplome> lesDiplomes;
        private Service leService;

        public Employe(int id, string nom, string prenom, string sexe, bool cadre, double salaire, Service leService)
        {
            this.cadre = cadre;
            this.id = id;
            this.sexe = sexe;
            this.nom = nom;
            this.prenom = prenom;
            this.salaire = salaire;
            this.leService = leService;
            this.lesDiplomes = new List<Diplome>();
        }

        public bool Cadre
        {
            get { return cadre; }
            set { cadre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }
        public new string ToString()
        {
            return String.Format("id: {0}\n nom:{1}\n prenom:{2}\n cadre:{3}\n salaire: {4}\n sexe: {5}\n", id, nom, prenom, cadre, salaire, sexe);
        }
    }
}
