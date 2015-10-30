using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Program
    {
        public static string conservateurCode = "";
        public static string conservateurNom = "";
        public static string conservateurTotalCommission = "0";
        public static string artisteCode = "";
        public static string artisteNom = "";
        public static string oeuvreCode = "";
        public static string oeuvreNom = "";
        // liste des conservateurs avec data test - Ce data normalement serais stocké sur une Base de donnée
        public static string[,] listConservateur = {{"ABCDE", "Roger Conservateur", "0"}, 
                                                    {"BCDEF", "Steve Curateur", "0"}, 
                                                    {"CDEFG", "Pascal Musée", "0"}, 
                                                    {"DEFGH", "Stéphane Gallerie", "0"}
                                                   };
        // liste des artistes avec data test - Ici aussi ce data serais stocké sur une BD
        public static string[,] listArtiste = {{"ABC01", "Pablo Picasso", "ABCDE"},
                                               {"ABC02", "Leonardo da Vinci", "ABCDE"}, 
                                               {"ABC03", "Rembrandt van Rijn", "BCDEF"}, 
                                               {"ABC04", "Paul Cézanne", "BCDEF"},
                                               {"ABC05", "Claude Monet", "CDEFG"},
                                               {"ABC06", "Paul Gauguin", "CDEFG"},
                                               {"ABC07", "Vincent van Gogh", "DEFGH"}
                                              };
        //liste des oeuvres avec data test - encore ici, ce data devrais etre stocké dans une BD
        public static string[,] listOeuvre = {{"PAI01", "Femme à la résille", "ABC01", "1938", "67 400 000$", "0", "E"},
                                              {"PAI02", "Peasant Woman Against a Background of Wheat", "ABC02", "1890", "68 900 000$", "0", "E"},
                                              {"PAI03", "Femme aux Bras Croisés", "ABC01", "1902", "55 000 000$", "0", "E"},
                                              {"PAI04", "Rideau, Cruchon et Compotier", "ABC04", "1894", "60 500 000$", "0", "E"},
                                              {"PAI05", "Le Bassin aux Nymphéas", "ABC05", "1919", "0", "8 050 0000$", "V"},
                                              {"PAI06", "Salvator Mundi", "ABC02", "1519", "127 500 000$", "0", "E"},
                                              {"PAI07", "Portrait of Jan Six", "ABC03", "1654", "0", "180 000 000$", "V"},
                                              {"PAI08", "Judas returning the 30 pieces of silver", "ABC03", "1629", "70 000 000$", "0", "N"},
                                              {"PAI09", "When Will You Marry Me?", "ABC06", "1892", "263 100 000$", "0", "N"},
                                             };


        static void Main(string[] args)
        {
            int valeurChoix = 0;

            while (valeurChoix != 8)
            {
                valeurChoix = afficheMenu();

                if (valeurChoix == 8)
                    return;

                //Prendre action / loadé le module correspondant
                if (valeurChoix == 1)  // Option 1 - Ajouter conservateur
                {
                    ajouterConservateur();
                }
                else if (valeurChoix == 2) // Option 2 - Ajouter artiste
                {
                    ajouterArtiste();
                }
                else if (valeurChoix == 3) // Option 3 -Ajouter oeuvre
                {
                    ajouterOeuvre();
                }
                else if (valeurChoix == 4) // Option 4 - Afficher conservateur
                {
                    afficherConservateur();
                }
                else if (valeurChoix == 5) // Option 5 - Afficher artiste
                {
                    afficherArtiste();
                }
                else if (valeurChoix == 6) // Options 6 - Afficher oeuvre
                {
                    afficherOeuvre();
                }
                else if (valeurChoix == 7) // Options 7 - Vendre œuvre
                {
                    vendreOeuvre();
                }
            }

            // Termine le menu
        }

        /// <summary>
        /// Affiche un menu
        /// </summary>
        /// <returns>Retourne un Int representant le choix du l'usager</returns>
        private static int afficheMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("- Système de gallerie Informatisé -");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            Console.WriteLine("1 - Ajouter conservateur");
            Console.WriteLine("2 - Ajouter artiste");
            Console.WriteLine("3 - Ajouter oeuvre");
            Console.WriteLine("4 - Afficher conservateur");
            Console.WriteLine("5 - Afficher artiste");
            Console.WriteLine("6 - Afficher oeuvre");
            Console.WriteLine("7 - Vendre oeuvre");
            Console.WriteLine("8 - Quitter");
            Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SVP entrez votre selection (nombre) et appuyer sur enter");
            Console.ResetColor();

            //recupéré la valeur
            int valeurChoix;

            try
            {
                // recup le nombre et faire un parse du resultat
                valeurChoix = int.Parse(Console.ReadLine());
                return valeurChoix;
            }
            catch
            {
                //erreur dans le nombre
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur SVP Sélectionnez un nombre");
                Console.ReadKey();
                Console.ResetColor();
                return 9;
            }
        }

        /// <summary>
        /// Fonction pour ajouté un conservateur dans la base de donnée
        /// </summary>
        private static void ajouterConservateur()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Ajouter Conservateur");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - -");

            bool codeValid = false;
            bool nomValid = false;
            string[,] laliste = listConservateur;

            do
            {
                Console.WriteLine("Entrez le code du consevateur");
                conservateurCode = Console.ReadLine().ToUpper();

                if (validCodeLongueur(conservateurCode, 5)) // appelle la fonction qui valide la longueur
                {
                    string nonExiste = getNom(laliste, conservateurCode);
                    if (nonExiste == "")
                        codeValid = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le conservateur du nom de : " + nonExiste + " utlise le code : " + conservateurCode);
                        Console.WriteLine("Veuillez inscrire un code unique");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Code invalid - doit avoir 5 characteres ");
                    Console.WriteLine("Entrez le code du consevateur");
                    Console.ResetColor();
                }
            } while (codeValid == false);

            do
            {
                Console.WriteLine("Entrez le nom du consevateur");
                conservateurNom = Console.ReadLine();
                if (validCodeLongueur(conservateurNom, 30, false))
                {
                    nomValid = true;
                    Console.WriteLine("Enregistrement Conservateur - code: {0} - Nom: {1} est sauvegarder", conservateurCode, conservateurNom);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Appuyer sur une touche pour continuer...");
                    Console.ResetColor();
                    Console.ReadKey();
                    // retour enregistrement sauvegarder
                    // Code pour sauvegarder le conservateur va ici
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Code invalid - doit avoir 30 characteres ");
                    Console.ResetColor();
                }
            } while (nomValid == false);

        }

        /// <summary>
        /// Fonction pour ajouter Artiste dans la base de donnée
        /// </summary>
        private static void ajouterArtiste()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Ajouter Artiste");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - -");
            Console.WriteLine("Entrez le code de l'artiste");
            // validation des codes/nom a faire 

            bool codeValid = false;
            bool nomValid = false;
            string[,] laliste = listArtiste;

            do
            {
                artisteCode = Console.ReadLine().ToUpper();

                if (validCodeLongueur(artisteCode, 5))
                {
                    string nonExiste = getNom(laliste, artisteCode);
                    if (nonExiste == "")
                        codeValid = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("L'artiste au nom de : " + nonExiste + " utlise le code : " + artisteCode);
                        Console.WriteLine("Veuillez inscrire un code unique");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Code invalid - doit avoir 5 characteres ");
                    Console.WriteLine("Entrez le code de l'artiste");
                    Console.ResetColor();
                }
            } while (codeValid == false);

            do
            {
                Console.WriteLine("Entrez le nom de l'artiste");
                artisteNom = Console.ReadLine();
                if (validCodeLongueur(artisteNom, 40, false))
                {
                    nomValid = true;
                    Console.WriteLine("Enregistrement Artiste - code: {0} - Nom: {1} est sauvegarder", artisteCode, artisteNom);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Appuyer sur une touche pour continuer...");
                    Console.ResetColor();
                    Console.ReadKey();
                    // retour enregistrement sauvegarder
                    // Code pour sauvegarder le conservateur va ici
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nom invalid - doit avoir 40 characteres ");
                    Console.ResetColor();
                }
            } while (nomValid == false);
        }

        /// <summary>
        /// Ajouter un oeuvre dans la BD
        /// </summary>
        private static void ajouterOeuvre()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Ajouter Oeuvre");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - -");
            Console.WriteLine("Entrez le code de l'Oeuvre");

            bool codeValid = false;
            bool nomValid = false;
            bool artisteValid = false;
            bool anneeValid = false;
            bool etatValid = false;
            bool valeurValid = false;

            string[,] laliste = listOeuvre;
            string[,] lalisteNom = listArtiste;
            string oeuvreArtisteCode = "";
            string etatOeuvre = "";
            string nonExiste = "";
            string anneOeuvre = "";
            decimal valeurOeuvre = 0;

            do
            {
                oeuvreCode = Console.ReadLine().ToUpper();

                if (validCodeLongueur(oeuvreCode, 5))
                {
                    nonExiste = getNom(laliste, oeuvreCode);
                    if (nonExiste == "")
                        codeValid = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("L'oeuvre au nom de : " + nonExiste + " utlise le code : " + oeuvreCode);
                        Console.WriteLine("Veuillez inscrire un code unique");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Code invalid - doit avoir 5 characteres ");
                    Console.WriteLine("Entrez le code de l'oeuvre");
                    Console.ResetColor();
                }

            } while (codeValid == false);

            do
            {
                Console.WriteLine("Entrez le nom de l'Oeuvre");
                oeuvreNom = Console.ReadLine();
                if (validCodeLongueur(oeuvreNom, 40, false))
                {
                    nomValid = true;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nom invalid - doit avoir 40 characteres ");
                    Console.ResetColor();
                }
            } while (nomValid == false);

            do
            {
                Console.WriteLine("Entrez le code de l'artiste qui a fait cette oeuvre");
                oeuvreArtisteCode = Console.ReadLine().ToUpper();
                nonExiste = getNom(lalisteNom, oeuvreArtisteCode);

                if (nonExiste != "")
                {
                    artisteValid = true;
                }
                else
                {
                    Console.WriteLine("Aucun artiste n'est associer a ce code");
                }
            } while (artisteValid == false);

            do
            {
                Console.WriteLine("Entrez l'année de realisation de l'oeuvre (AAAA)");
                anneOeuvre = Console.ReadLine();
                
                if (anneOeuvre.Length == 4)
                {
                    try
                    {
                        int a = Int32.Parse(anneOeuvre);
                        anneeValid = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("La date doit etre du format (AAAA)");
                }

            } while (anneeValid == false);

            do
            {
                Console.WriteLine("Entrez la valeur extimée de l'oeuvre");
                string saisieOeuvre = Console.ReadLine();

                if (anneOeuvre.Length == 4)
                {
                    try
                    {
                        valeurOeuvre = decimal.Parse(saisieOeuvre);
                        valeurValid = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Le format doit etre monetaire (0000.00");
                }

            } while (valeurValid == false);

            do
            {
                Console.WriteLine("Entrez le statut / Etat de l'oeuvre (E/V/N)");
                Console.WriteLine("E - Exposer | V - Vendu | Entreposer");
                etatOeuvre = Console.ReadLine();

                if (etatOeuvre.Length == 1)
                {
                    if (etatOeuvre == "E" || etatOeuvre == "V" || etatOeuvre == "N")
                    {
                        etatValid = true;
                    }
                       
                }
                else
                {
                    Console.WriteLine("Le status doit etre (E/V/N)");
                }

            } while (etatValid == false);

            
            Console.WriteLine("L'artiste {0} a été assigné comme l'auteur de cette oeuvre", nonExiste);
            Console.WriteLine("L'ouvre a été créer en {0} et a une valeur estimé de : {1}", anneOeuvre, valeurOeuvre);
            Console.WriteLine("Enregistrement de l'oeuvre - code: {0} - {1} à été effectuer", oeuvreCode, oeuvreNom);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();
            // retour enregistrement sauvegarder
            // Code pour sauvegarder le conservateur va ici


        }

        private static void afficherConservateur()
        {
            //lire BD / Table des Conservateurs
            Console.Clear();
            string[,] laliste = listConservateur;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Liste des conservateurs");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - -");

            for (int x = 0; x < laliste.GetLength(0); x++)
            {
                string leCode = (laliste[x, 0].ToString());
                string lenom = (laliste[x, 1].ToString());
                Console.WriteLine(leCode + " : " + lenom);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        private static void afficherArtiste()
        {
            //lire BD / Table des artiste 
            Console.Clear();
            string[,] laliste = listArtiste;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Liste des Artistes");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - -");

            for (int x = 0; x < laliste.GetLength(0); x++)
            {
                string leCode = (laliste[x, 0].ToString());
                string lenom = (laliste[x, 1].ToString());
                Console.WriteLine(leCode + " : " + lenom);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        /// <summary>
        /// AFficher tous les oeuvres avec les information pertinentes
        /// </summary>
        private static void afficherOeuvre()
        {
            //lire BD / Table des oeuvres 
            //{"PAI002", "Peasant Woman Against a Background of Wheat", "ABC007", "1890", 68900000, 0, "E"},
            Console.Clear();
            string[,] laliste = listOeuvre;
            string[,] lalisteArtiste = listArtiste;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Liste des Oeuvres");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - -");
            

            for (int x = 0; x < laliste.GetLength(0); x++)
            {
                string leCode = (laliste[x, 0].ToString());
                string leTitre = (laliste[x, 1].ToString());
                
                string leCodeArtiste = (laliste[x, 2].ToString());
                string leNomArtiste = getNom(lalisteArtiste, leCodeArtiste);
                string leNomConservateur = getNomConservateur(lalisteArtiste, leCodeArtiste);
                string leAnnee = (laliste[x, 3]);
                string levaleur = (laliste[x, 4]);
                string lePrixVente = (laliste[x, 5]);
                string leStatut = "";
                string labelValeurouVendu = "";
                string leMontant = "0";
                
                if (laliste[x, 6] == "E")
                {
                    leStatut = "Exposé";
                    labelValeurouVendu = "Valeur :";
                    leMontant = levaleur;
                }
                else if ((laliste[x, 6] == "V"))
                {
                    leStatut = "Vendu";
                    labelValeurouVendu = "Prix de vente :";
                    leMontant = lePrixVente;
                }
                else if ((laliste[x, 6] == "N"))
                {
                    leStatut = "Entreposé";
                    labelValeurouVendu = "Valeur :";
                    leMontant = levaleur;
                }
                Console.WriteLine(leCode + " : " + leTitre + " - Statut : " + leStatut);
                Console.WriteLine("         Artiste : " + leNomArtiste + " - "  + labelValeurouVendu + " : " + leMontant);
                Console.WriteLine("         Conservateur : " + leNomConservateur);
                Console.WriteLine("----------------------------------------------------------");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        /// <summary>
        /// Fonction pour vendre une oeuvre
        /// </summary>
        public static void vendreOeuvre()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Vendre oeuvre");
            Console.ResetColor();
            Console.WriteLine("- - - - - - - - - - - -");
            Console.WriteLine("Entrez le code de l'ouevre a vendre");

            bool codeValid = false;
            string[,] laliste = listOeuvre;
            decimal PrixOeuvre = 0;

            do
            {
                oeuvreCode = Console.ReadLine().ToUpper();

                if (oeuvreCode.Length == 5)
                {
                    string nonExiste = getNom(laliste, oeuvreCode);
                    if (nonExiste != "")
                        codeValid = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("L'oeuvre " + oeuvreCode + "n'a pas été trouvée ");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Code invalid - doit avoir 5 characteres ");
                    Console.WriteLine("Entrez le code de l'oeuvre");
                    Console.ResetColor();
                }
            } while (codeValid == false);

            Console.WriteLine("Entrez le prix de vente :");
            string saisiePrixOeuvre = Console.ReadLine();

            try
            {
                PrixOeuvre = decimal.Parse(saisiePrixOeuvre);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            Console.WriteLine("Cette oeuvre a été vendu pour le prix de " + saisiePrixOeuvre);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();


        }

                      

        /// <summary>
        /// Fonction qui recupere le nom associer a un code (2ieme champ de la table) avec la cle situé au premier champ
        /// </summary>
        /// <param name="laListe">table a effectuer la recherche</param>
        /// <param name="cible">code a rechercher</param>
        /// <returns></returns>
        private static string getNom(this string[,] laListe, string cible)
        {
            string result = "";
            var rowLowerLimit = laListe.GetLowerBound(0);
            var rowUpperLimit = laListe.GetUpperBound(0);

            var colLowerLimit = laListe.GetLowerBound(1);
            var colUpperLimit = laListe.GetUpperBound(1);

            for (int row = rowLowerLimit; row < rowUpperLimit; row++)
            {
                for (int col = colLowerLimit; col < colUpperLimit; col++)
                {
                    if (laListe[row, 0] == cible && result == "")
                    {
                        return result = laListe[row, 1];
                    }
                }
            }
            return result;
        }

        private static string getNomConservateur(this string[,] laListe, string cible)
        {
            string result = "";
            string leCodeConservateur = "";
            string[,] lalisteConservateur = listConservateur;
            var rowLowerLimit = laListe.GetLowerBound(0);
            var rowUpperLimit = laListe.GetUpperBound(0);

            var colLowerLimit = laListe.GetLowerBound(1);
            var colUpperLimit = laListe.GetUpperBound(1);

            for (int row = rowLowerLimit; row < rowUpperLimit; row++)
            {
                for (int col = colLowerLimit; col < colUpperLimit; col++)
                {
                    if (laListe[row, 0] == cible && result == "")
                    {
                        leCodeConservateur = laListe[row, 2];
                        result = getNom(listConservateur, leCodeConservateur);
                    }
                }
            }
            return result;
        }

        /// </summary>
        /// <param name="code">sting a evaluer la longueur</param>
        /// <param name="longueur">Longueur cible</param>
        /// <param name="egal">True pour egal / False pour egale ou plus petit que</param>
        /// <returns></returns>
        private static bool validCodeLongueur(string code, int longueur, bool egal=true)
        {
            if (egal == true)
            {
                if (code.Length == longueur)
                {
                    return true;
                }
            }
            else if (egal == false)
            { 
                if (code.Length <= longueur)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
