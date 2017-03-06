using System;
using System.Globalization;
using System.Text;
using SongMassRename.Controllers.Interfaces;
using SongMassRename.Enums;
using SongMassRename.Models;
using SongMassRename.Properties;

using static System.String;

namespace SongMassRename.Controllers
{
	internal class LogController : ILogController
	{
		public LogController()
		{
			Console.OutputEncoding = Encoding.UTF8;
		}

		public void ProgramEnd()
		{
			Write(Localization.ProgramEnd);
		}

		public void ProgramStart()
		{
			Write(Localization.ProgramStart);
		}

		public void Start(SongActionEnum actionEnum)
		{
			Write(Localization.StartingAction, actionEnum);
		}

		public void End(SongActionEnum actionEnum)
		{
			Write(Localization.EndAction, actionEnum);
		}

		public void SaveSong(Mp3FileInfoModel song)
		{
			Write(Localization.SavingSong, song.Artist, song.Title);
			WriteEmptyLine();
		}

		public void LoadSong(string path)
		{
			WriteEmptyLine();
			Write(Localization.LoadingSong, path);
		}

		public void ChangeTag(Mp3FileInfoModel file)
		{
			Write(Localization.ChangingTag, file.Filename);
		}

		public void ChangeSongArtist(string artist)
		{
			Write(Localization.ChangingArtist, artist);
		}

		public void ChangeSongTitle(string title)
		{
			Write(Localization.ChangingArtist, title);
		}

		public void FoundFiles(int count)
		{
			Write(Localization.FoundFiles, count);
		}

		public void Error(string error)
		{
			Write(Localization.Error, error);
		}

		private static void Write(string text, params object[] parameters)
		{
			var timestamp = DateTime.UtcNow.ToString(Settings.Default.TimestampFormat, CultureInfo.InvariantCulture);

			if (parameters.Length > 0)
			{
				text = Format(text, parameters);
			}

			Console.WriteLine($"[{timestamp}] {text}");
		}

		private static void WriteEmptyLine()
		{
			Console.WriteLine();
		}
	}
}
