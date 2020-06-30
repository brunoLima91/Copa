using API.Copa.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace API.Copa.Business.Extensions
{
	public class OrdenaEquipePorNome :IComparer<Equipe>
	{
		public int Compare([AllowNull] Equipe x, [AllowNull] Equipe y)
		{

			if (x== null || y == null)
			{
				return 1;
			}
			String[] lNome1Partes = x.Nome.Split(" ");
			String[] lNome2Partes = y.Nome.Split(" ");

			int compareNome = lNome1Partes[0].ToUpper().CompareTo(lNome2Partes[0].ToUpper());

			if (compareNome != 0)
			{
				return compareNome;
			}

			if (lNome1Partes.Length == 1 && lNome2Partes.Length > 1)
			{
				return -1;
			}

			if (lNome1Partes.Length > 1 && lNome2Partes.Length == 1)
			{
				return 1;
			}

			if (lNome1Partes.Length > 1 && lNome2Partes.Length > 1)
			{
				var lNum1 = 0;
				Int32.TryParse(lNome1Partes[1], out lNum1);

				var lNum2 = 0;
				Int32.TryParse(lNome2Partes[1], out lNum2);

				return lNum1 - lNum2;
			}

			return x.Nome.ToUpper().CompareTo(y.Nome.ToUpper());
		}
	}
}
