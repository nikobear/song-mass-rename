using System.Collections.Generic;

namespace SongMassRename.Extensions
{
	internal static class ListExtensions
	{
		public static T NextOf<T>(this IList<T> list, T item)
		{
			return list[list.IndexOf(item) + 1 == list.Count ? 0 : list.IndexOf(item) + 1];
		}
	}
}
