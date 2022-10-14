using System;

namespace firstgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Partie();
        }
        static void Partie()
        {
            //Affichage     
            Console.WriteLine("[**************************]");
            Console.WriteLine("[****** Jeu du + / - ******]");
            Console.WriteLine("[**************************]");
            Console.WriteLine("");

            //Affichage*
            Console.WriteLine("[Entrer un premier chiffre.]");
            Console.WriteLine("");

            //RND
            Random rnd = new Random();
            int RndNmbr = rnd.Next(101);

            //Debug
            Console.WriteLine("(RndNmer = " + RndNmbr + ")");

            //Boucle Win
            bool Win = false;
            while (!Win)
            {
                //Console
                string UserInput = Console.ReadLine();
                int UserNmbr;
                if (!Int32.TryParse(UserInput, out UserNmbr))
                {
                    Console.WriteLine("[Veuillez entrer un chiffre.]");
                    Console.WriteLine("");
                }
                else
                {
                    if (UserNmbr > RndNmbr)
                    {
                        Console.WriteLine("[C'est moins.]");
                        Console.WriteLine("");
                    }
                    else if (UserNmbr < RndNmbr)
                    {
                        Console.WriteLine("[C'est plus.]");
                        Console.WriteLine("");
                    }
                    else if (UserNmbr == RndNmbr)
                    {
                        Win = true; //Fin Boucle Win
                        Console.WriteLine("[Bravo !]");
                        Console.WriteLine("");
                    }
                }
            }
            RestartChoice();
        }

        static void RestartChoice()
        {
            //Restart
            Console.WriteLine("[Rejouer ? (1: Oui, 2: Non)]");
            Console.WriteLine("");

            int Action = 0;
            bool SaisieCorrecte = false;

            while (!SaisieCorrecte)
            {
                string Recu = Console.ReadLine();
                if (int.TryParse(Recu, out Action) && (Action == 1 || Action == 2))
                {
                    Action = Convert.ToInt32(Recu);
                    SaisieCorrecte = true;
                }
                else
                {
                    Console.WriteLine("[Veuillez entrer 1 ou 2.]");
                    Console.WriteLine("");
                }
            }
            switch (Action)
            {
                case 1:
                    Partie();
                    break;

                case 2:
                    Console.WriteLine("[Merci d'avoir joué !]");
                    Console.WriteLine("");
                    break;
            }
        }
    }
}
