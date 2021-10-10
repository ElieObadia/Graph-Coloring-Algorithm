using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Sommet: IComparable
    {
        string nom;
        List<Sommet> lien;
        string couleur;

        public Sommet(string nom)
        {
            this.nom = nom;
        }

        public string Couleur { get { return this.couleur; } set { this.couleur = value; } }
        public string Nom { get { return this.nom; } }
        public List<Sommet> Lien { get { return this.lien; } set { this.lien = value; } }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Sommet othersommet = obj as Sommet;
            if (othersommet != null)
            {
                return lien.Count.CompareTo(othersommet.Lien.Count);
            }
            else
            {
                throw new ArgumentException("Object is not a Sommet");
            }
        }

        public override string ToString()
        {
            string liste = "";
            foreach (Sommet s in lien)
            {
                liste += s.nom + "\n";
            }
            return this.nom + " " + this.couleur + "\nLié avec :\n" + liste;
        }
    }
}
