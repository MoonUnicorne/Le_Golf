using System;
using System.Collections.Generic;
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

            int nbBalle = 1000;
            int nbDimention = 4;

            Balle[,] balles = new Balle[nbBalle,nbDimention];
            decimal[] meanCoup = new decimal[nbDimention];
            
            for (int d = 0; d < nbDimention; d++)
            {
                meanCoup[d] = 0;
                for (int i = 0; i< nbBalle; i++)
                {
                    balles[i, d] = new Balle(d+1);
                    while (!balles[i,d].StrategiNaive(de.roll()))
                    {
                        meanCoup[d]++;
                    }
                }
                meanCoup[d] /= nbBalle;
                Console.WriteLine($"Nombre de coup moyen : {meanCoup[d]} pour {d} dimention avec D6");
                //Console.WriteLine($"Performance : {meanCoup[d] / (decimal)Math.Pow(1000 * 1000, 1/2)}");
            }
            
            Console.ReadKey();
        }
    }
}
