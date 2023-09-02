using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiceNamespace;

namespace BalleNamespace
{
    internal class Balle
    {
        public int _dimention {get; private set;}
        public int[] _coordonee {get; private set;}

        public Balle(int dimention)
        {
            if (dimention <= 0)
            {
                throw new ArgumentException("USAGE : La dimention de la balle doit être un nombre entier > 0");
            }
            _dimention = dimention;
            _coordonee = new int[dimention];


            for (int i = 0; i < dimention; i++)
            {
                _coordonee[i] = 1000;
            }

        }

        public bool Deplacer(int longueur, int axe=0)
        {
            if (axe < 0 || axe >= _dimention)
            {
                throw new ArgumentException($"USAGE : La dimention {axe} n'existe pas");
            }
            if (_coordonee[axe] == 0)
            {
                return true;
            }

            if (_coordonee[axe] < 0)
            {
                _coordonee[axe] += longueur;
            }
            else
            {
                _coordonee[axe] -= longueur;
            }

            return _coordonee[axe] == 0;
        }

        public bool StrategiNaive(int longueur)
        {
            int bestAxe = 0;
            int minDist = int.MaxValue;
            for (int i = 0; i < _coordonee.Length ; i++)
            {
                if (_coordonee[i] == 0)
                {
                    continue;
                }
                else if (_coordonee[i] == longueur)
                {
                    bestAxe = i;
                    break;
                }
                else if (_coordonee[i] > 0)
                {
                    
                    if (Math.Abs(_coordonee[i] - longueur) < minDist)
                    {
                        bestAxe = i;
                    }
                }
                else
                {
                    if (Math.Abs(_coordonee[i] + longueur) < minDist)
                    {
                        bestAxe = i;
                    }
                }
            }

            Deplacer(longueur, bestAxe);

            for (int d = 0; d < _coordonee.Length ; d++)
            {
                if (_coordonee[d] != 0) 
                {
                    return false;
                }
            }
            return true;
        }


    }
}
