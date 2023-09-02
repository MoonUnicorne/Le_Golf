using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalleNamespace;
using DiceNamespace;

namespace Le_golf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeGeneral de = new DeGeneral();

            int nbBalle = 100;
            int nbDimention = 5;

            Balle[,] balles1 = new Balle[nbBalle, nbDimention];
            Balle[,] balles2 = new Balle[nbBalle, nbDimention];

            decimal[] meanCoup1 = new decimal[nbDimention];
            decimal[] meanCoup2 = new decimal[nbDimention];

            for (int d = 1; d < nbDimention; d++)
            {
                meanCoup1[d] = 0;
                meanCoup2[d] = 0;
                for (int i = 0; i < nbBalle; i++)
                {
                    balles1[i, d] = new Balle(d + 1);
                    balles2[i, d] = new Balle(d + 1);
                    bool victoire1 = false;
                    bool victoire2 = false;
                    do
                    {
                        int longeure = de.roll();
                        
                        if (!victoire1)
                        {
                            victoire1 = balles1[i, d].Strategie1DimBy1(longeure);
                            meanCoup1[d]++;
                        }
                        if (!victoire2)
                        {
                            victoire2 = balles2[i, d].StrategieCouloire(longeure);
                            meanCoup2[d]++;
                        }
                        Debug.WriteLine("");
                    } while (!(victoire1 && victoire2));
                }
                meanCoup1[d] /= nbBalle;
                meanCoup2[d] /= nbBalle;
                Console.WriteLine($"Nombre de coup moyen : {meanCoup1[d]} pour {d + 1} dimention avec D6 avec strategie naive");
                
                Console.WriteLine($"Nombre de coup moyen : {meanCoup2[d]} pour {d + 1} dimention avec D6 avec Strategie couloire");
                Console.WriteLine();
                Debug.WriteLine("");
            }

            Console.WriteLine();
            Console.ReadKey();

        }
        
    }
}
