using System;
using System.Collections.Generic;
using System.Text;
namespace Projet
{
    class Program
    //Les commentaires sont là pour informer sur les calculs de complexités et éventuelles optimisations possibles
    {
        static void DeuxColorationGraphe(Graphe g) //N le nombre de sommets et M le nombre d'arrêtes
        {
            foreach(Sommet s in g.Compographe) //N fois
            {      
                if(s.Couleur == null) 
                {
                    s.Couleur = "rouge";
                }
                if (s.Couleur != null) //M-1 fois
                {
                    foreach(Sommet sl in s.Lien) //M fois
                    {
                        if(sl.Couleur == null && s.Couleur == "rouge") //2
                        {
                            sl.Couleur = "bleu"; //1
                        }
                        if (sl.Couleur == null && s.Couleur == "bleu") //2
                        {
                            sl.Couleur = "rouge"; //1
                        }
                    }
                }
            } //Compléxité : 3 * M * (M-1) * N => L'algorithme a une complexité en O(M²*N)
        }

        static List<string> Voisin(List<Sommet> sl)
        {
            List<string> voisin = new List<string>();
            foreach (Sommet s in sl)
            {
                if (s.Couleur == "bleu" && !voisin.Contains("bleu"))
                {
                    voisin.Add("bleu");
                }
                if (s.Couleur == "rouge" && !voisin.Contains("rouge"))
                {
                    voisin.Add("rouge");
                }
                if (s.Couleur == "vert" && !voisin.Contains("vert"))
                {
                    voisin.Add("vert");
                }
            }
            return voisin;
        }

        static string ChoixCouleur(string couleur1)
        {
            string retour = "";
            if (couleur1 == "vert" || couleur1 == "rouge")
            {
                retour = "bleu";
            }
            return retour;
        }

        static void TroisColoration2(Graphe g)
        {
            List<string> col = new List<string> { "bleu", "rouge", "vert" };
            int couleurusage = 0; 

            g.Compographe.Sort();
            g.Compographe.Reverse();

            g.Compographe[0].Couleur = "bleu";
            Sommet curseur = g.Compographe[0];

            List<Sommet> acolorier = new List<Sommet>();
            foreach(Sommet s in g.Compographe)     
            {
                acolorier.Add(s);                   
            }

            List<Sommet> fixe = new List<Sommet>();
            foreach (Sommet s in g.Compographe)    
            {
                fixe.Add(s);
            }

            acolorier.Remove(curseur); 
            List<Sommet> coloactu = new List<Sommet>();
            coloactu.Add(curseur);

            while(acolorier.Count != 0)
            {
                foreach (Sommet s in fixe)
                {
                    int afaire = 1;
                    foreach(Sommet actu in coloactu)
                    {
                        if (afaire != 0 && s.Lien.Contains(actu))
                        {
                            afaire = 0;
                        }
                    }
                    if (afaire == 1 && s.Couleur == null && !s.Lien.Contains(curseur))
                    {
                        s.Couleur = col[couleurusage];
                        coloactu.Add(s);
                        acolorier.Remove(s);
                    }
                }

                coloactu = new List<Sommet>();

                couleurusage++;
                if (couleurusage == 3)
                {
                    couleurusage = 0;
                }

                if(acolorier.Count!=0)
                {
                    curseur = acolorier[0];
                    coloactu.Add(curseur);
                }
            }

            g.Compographe = fixe;
        }

        #region Vérification
        static int TroisCouleurs(Graphe g) //Vérification qu'il y a bien 3 couleurs maximum
        {
            int retour = 0;
            List<string> couleurpresente = new List<string>();
            foreach(Sommet s in g.Compographe)
            {
                if (!couleurpresente.Contains(s.Couleur))
                {
                    couleurpresente.Add(s.Couleur);
                }
            }
            if(couleurpresente.Count > 3)
            {
                retour = 1;
            }
            return retour;
        }

        static int BienColore(Graphe g) //Verification de la bonne coloration du graphe
        {
            int retour = 0;
            foreach(Sommet s in g.Compographe)
            {
                foreach(Sommet lie in s.Lien)
                {
                    if(retour == 0 && lie.Couleur == s.Couleur)
                    {
                        retour = 2;
                    }
                }
            }
            return retour;
        }

        static int Verificateur(Graphe g)
        {
            return BienColore(g) + TroisCouleurs(g);
        }
        #endregion

        static void Main(string[] args)
        {
            // Création et initialisation des sommets : Sommet nom = new Sommet("nom")
            Sommet a1 = new Sommet("a");
            Sommet b1 = new Sommet("b");
            Sommet c1 = new Sommet("c");
            Sommet d1 = new Sommet("d");
            Sommet e1 = new Sommet("e");
            Sommet f1 = new Sommet("f");
            Sommet g1 = new Sommet("g");
            Sommet h1 = new Sommet("h");
            Sommet i1 = new Sommet("i");
            Sommet j1 = new Sommet("j");
            Sommet k1 = new Sommet("k");

            // Création de la liste des sommets présent dans le graphe
            List<Sommet> sommetgraphe2colo = new List<Sommet> { a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1};

            // Génération de l'instance graphe à partir de la liste précédente
            Graphe graphe2colo = new Graphe(sommetgraphe2colo);

            // Création des arrêtes (liens) : List<Sommet> nom = new List<Sommet> { sommet1, ..., sommetn }
            List<Sommet> liena1 = new List<Sommet> { b1, c1, d1, g1 };
            List<Sommet> lienb1 = new List<Sommet> { a1 , e1, f1};
            List<Sommet> lienc1 = new List<Sommet> { a1, j1 };
            List<Sommet> liend1 = new List<Sommet> { a1 , e1, h1 };
            List<Sommet> liene1 = new List<Sommet> { b1, d1, i1 };
            List<Sommet> lienf1 = new List<Sommet> { b1, i1, k1 };
            List<Sommet> lieng1 = new List<Sommet> { a1, h1 };
            List<Sommet> lienh1 = new List<Sommet> { d1, g1, i1 };
            List<Sommet> lieni1 = new List<Sommet> { e1, f1, h1, j1 };
            List<Sommet> lienj1 = new List<Sommet> { c1, i1, k1 };
            List<Sommet> lienk1 = new List<Sommet> { f1, j1 };

            // Attribution des liens à chaque sommet
            a1.Lien = liena1;
            b1.Lien = lienb1;
            c1.Lien = lienc1;
            d1.Lien = liend1;
            e1.Lien = liene1;
            f1.Lien = lienf1;
            g1.Lien = lieng1;
            h1.Lien = lienh1;
            i1.Lien = lieni1;
            j1.Lien = lienj1;
            k1.Lien = lienk1;

            // Création et initialisation des sommets : Sommet nom = new Sommet("nom")
            Sommet a2 = new Sommet("1");
            Sommet b2 = new Sommet("2");
            Sommet c2 = new Sommet("3");
            Sommet d2 = new Sommet("4");
            Sommet e2 = new Sommet("5");
            Sommet f2 = new Sommet("6");
            Sommet g2 = new Sommet("7");
            Sommet h2 = new Sommet("8");
            Sommet i2 = new Sommet("9");
            Sommet j2 = new Sommet("10");

            // Création de la liste des sommets présent dans le graphe
            List<Sommet> sommetgraphe3colo = new List<Sommet> { a2, b2, c2, d2, e2, f2, g2, h2, i2, j2 };

            // Génération de l'instance graphe à partir de la liste précédente
            Graphe graphe3colo = new Graphe(sommetgraphe3colo);

            // Création des arrêtes (liens) : List<Sommet> nom = new List<Sommet> { sommet1, ..., sommetn }
            List<Sommet> liena2 = new List<Sommet> { b2, f2, e2 };
            List<Sommet> lienb2 = new List<Sommet> { a2, c2, g2 };
            List<Sommet> lienc2 = new List<Sommet> { b2, d2, h2 };
            List<Sommet> liend2 = new List<Sommet> { c2, e2, i2 };
            List<Sommet> liene2 = new List<Sommet> { a2, d2, j2 };
            List<Sommet> lienf2 = new List<Sommet> { a2, h2, i2 };
            List<Sommet> lieng2 = new List<Sommet> { b2, i2, j2 };
            List<Sommet> lienh2 = new List<Sommet> { c2, f2, j2 };
            List<Sommet> lieni2 = new List<Sommet> { d2, f2, g2 };
            List<Sommet> lienj2 = new List<Sommet> { e2, g2, h2 };

            // Attribution des liens à chaque sommet
            a2.Lien = liena2;
            b2.Lien = lienb2;
            c2.Lien = lienc2;
            d2.Lien = liend2;
            e2.Lien = liene2;
            f2.Lien = lienf2;
            g2.Lien = lieng2;
            h2.Lien = lienh2;
            i2.Lien = lieni2;
            j2.Lien = lienj2;

            // On colorie le graphe
            DeuxColorationGraphe(graphe2colo);
            // On affiche le graphe colorié
            Console.WriteLine(graphe2colo);
            string situation = "";
            switch (Verificateur(graphe2colo))
            {
                case 0:
                    situation = "Correct";
                    break;
                case 1:
                    situation = "Erreur nombre de couleurs\n";
                    break;
                case 2:
                    situation = "Erreur de coloration\n";
                    break;
                case 3:
                    situation = "Erreur de coloration et du nombre de couleurs";
                    break;
            }
            Console.WriteLine("Situation du graphe 2 coloration : " + situation+"\n");

            // On colorie le graphe
            TroisColoration2(graphe3colo);
            // on affiche le graphe colorié
            Console.WriteLine(graphe3colo);
            
            //On vérifie que le graphe est bien colorié et avec au maximum 3 couleurs
            situation = "";
            switch (Verificateur(graphe3colo))
            {
                case 0:
                    situation = "Correct";
                    break;
                case 1:
                    situation = "Erreur nombre de couleurs\n";
                    break;
                case 2:
                    situation = "Erreur de coloration\n";
                    break;
                case 3:
                    situation = "Erreur de coloration et du nombre de couleurs";
                    break;
            }
            Console.WriteLine("Situation du graphe 3 coloration : " + situation+"\n");

            Console.ReadKey();
        }
    }
}
