using System;

namespace Combinations
{

    public static class StaticIterations
    {

		public static T[][] Combina4_5<T>(T[] elementi, int numeroPostazioni)
		{
			int n = elementi.Length;
			int k = numeroPostazioni;
			int count = (int)Math.Pow(n, k);
			T[][] combinazione = new T[count][];

			int p = 0;
			for (int k1 = 0; k1 < n; k1++)
			{
				for (int k2 = 0; k2 < n; k2++)
				{
					for (int k3 = 0; k3 < n; k3++)
					{
						for (int k4 = 0; k4 < n; k4++)
						{
							for (int k5 = 0; k5 < n; k5++)
							{
								combinazione[p++] = new T[] {
																	elementi[k1],
																	elementi[k2],
																	elementi[k3],
																	elementi[k4],
																	elementi[k5]																	 
																};
							}
						}
					}
				}
			}

			return combinazione;
		}

		public static T[][] Combina4_12<T>(T[] elementi, int numeroPostazioni)
		{
			int n = elementi.Length;
			int k = numeroPostazioni;
			int count = (int)Math.Pow(n, k);
			T[][] combinazione = new T[count][];

			int p = 0;
			for (int k1 = 0; k1 < n; k1++)
			{
				for (int k2 = 0; k2 < n; k2++)
				{
					for (int k3 = 0; k3 < n; k3++)
					{
						for (int k4 = 0; k4 < n; k4++)
						{
							for (int k5 = 0; k5 < n; k5++)
							{
								for (int k6 = 0; k6 < n; k6++)
								{
									for (int k7 = 0; k7 < n; k7++)
									{
										for (int k8 = 0; k8 < n; k8++)
										{
											for (int k9 = 0; k9 < n; k9++)
											{
												for (int k10 = 0; k10 < n; k10++)
												{
													for (int k11 = 0; k11 < n; k11++)
													{
														for (int k12 = 0; k12 < n; k12++)
														{
															combinazione[p++] = new T[] {
																	elementi[k1],
																	elementi[k2],
																	elementi[k3],
																	elementi[k4],
																	elementi[k5],
																	elementi[k6],
																	elementi[k7],
																	elementi[k8],
																	elementi[k9],
																	elementi[k10],
																	elementi[k11],
																	elementi[k12]
																};
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}

			return combinazione;
		}

	}
}
