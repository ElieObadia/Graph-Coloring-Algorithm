using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Graphe
    {
        List<Sommet> compographe;

        public Graphe(List<Sommet> compographe)
        {
            this.compographe = compographe;
        }

        public List<Sommet> Compographe { get { return this.compographe; } set { this.compographe = value; } }

        public override string ToString()
        {
            string retour = "";
            foreach(Sommet s in compographe)
            {
                retour += s.Nom + " " + s.Couleur+"\n";
            }
            return "Le graphe est : " + retour;
        }
    }
}
