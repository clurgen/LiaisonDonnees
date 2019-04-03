using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librairieGesper
{
    public class Diplome
    {
        private int id;
        private string libelle;
        private List<Employe> lesEmployes;

        public Diplome(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
            this.lesEmployes = new List<Employe>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        public List<Employe> LesEmployes
        {
            get { return lesEmployes; }
            set { lesEmployes = value; }
        }

        public new string ToString()
        {
            return String.Format("id: {0}\n libelle:{1}\n ", id, libelle);
        }
    }
}
