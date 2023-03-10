using System;
using System.Collections.Generic;

namespace Combinations
{

    public static class RecursiveIterations
    {

		public static T[][] Combina<T>(T[] elementi, int numeroPosizioni)
		{
			int cnt = (int)Math.Pow(elementi.Length, numeroPosizioni);
			List<T[]> combinazioni = new List<T[]>(cnt);
			T[] combinazione = new T[numeroPosizioni];
			Combina(combinazioni, combinazione, elementi, 0);
			return combinazioni.ToArray();
		}

		private static void Combina<T>(List<T[]> combinazioni, T[] combinazione, T[] elementi, int k)
		{
			if (k == combinazione.Length)
            {
				combinazioni.Add( (T[])combinazione.Clone() );
            }
            else
            {
				for (int i = 0; i < elementi.Length; i++)
                {
					combinazione[k] = elementi[i];
					Combina(combinazioni, combinazione, elementi, k + 1);
                }
            }
		}
	}
}
