using System.Linq;

namespace Combinations
{

	public static class LinearIterations
    {

		public static T[][] Combina<T>(T[] elementi, int numeroPosizioni)
		{
			var combinatore = new Disposizioni<T>(elementi, numeroPosizioni);
			return combinatore.ToArray();
		}
	}
}
