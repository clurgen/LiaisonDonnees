using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librairieGesper
{
    public class Service
    {
        private decimal budget;
        private int capacite;
        private int dernierId;
        private string designation;
        private int id;
        private string produit;
        private char type;
        private List<Employe> lesEmployeDuServices;

        public Service(int id, string designation, char type, string produit, int capacite)
        {
            this.capacite = capacite;
            this.designation = designation;
            this.id = id;
            this.type = type;
            this.produit = produit;
            this.lesEmployeDuServices = new List<Employe>();
        }

        public Service(int id, string designation, char type, decimal budget)
        {
            this.budget = budget;
            this.designation = designation;
            this.id = id;
            this.type = type;
            this.lesEmployeDuServices = new List<Employe>();
        }

        public decimal Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        public int Capacite
        {
            get { return capacite; }
            set { capacite = value; }
        }

        public int DernierId
        {
            get { return dernierId; }
            set { dernierId = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Produit
        {
            get { return produit; }
            set { produit = value; }
        }

        public char Type
        {
            get { return type; }
            set { type = value; }
        }

        public List<Employe> LesEmployeDuServices
        {
            get { return lesEmployeDuServices; }
            set { lesEmployeDuServices = value; }
        }

        public new string ToString()
        {
            if (type == 'p')
            {
                return String.Format("id: {0}\n designation:{1}\n  type:{2}\n produit:{3}\n capacité: {4}", id, designation, type, produit, capacite);
            }
            else 
            {
                return String.Format("id: {0}\n designation:{1}\n  type:{2}\n buget:{3}", id, designation, type, budget);
            }
        }
    }
}
