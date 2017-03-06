using System;
using System.IO;

namespace SongMassRename.Models
{
	internal class Mp3FileInfoModel
	{
		public Mp3FileInfoModel(string filepath)
		{
			Filepath = filepath;
			Filename = Path.GetFileNameWithoutExtension(filepath);

			var split = Filename?.Split(new [] { " - " }, StringSplitOptions.RemoveEmptyEntries);

			if (split == null || split.Length < 2)
			{
				return;
			}

			Artist = split[0].Trim();
			Title = split[1].Trim();
		}

		public string Filepath { get; }
		public string Filename { get; }
		public string Artist { get; }
		public string Title { get; }
	}
}
