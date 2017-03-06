using System.Collections.Generic;
using System.IO;
using System.Linq;
using SongMassRename.Controllers.Interfaces;
using SongMassRename.Enums;
using SongMassRename.Models;
using static System.String;
using File = TagLib.File;

namespace SongMassRename.Controllers
{
	internal class TagModifyController : ITagModifyController
	{
		private readonly ILogController _logController;

		public TagModifyController(ILogController logController)
		{
			_logController = logController;
		}

		public void Refactor(IEnumerable<Mp3FileInfoModel> files)
		{
			_logController.Start(SongActionEnum.Refactor);

			files.ToList().ForEach(UpdateSong);

			_logController.End(SongActionEnum.Refactor);
		}

		private void UpdateSong(Mp3FileInfoModel file)
		{
			_logController.ChangeTag(file);

			var song = LoadSong(file.Filepath);

			try
			{

				ChangeArtist(song, file);
				ChangeTitle(song, file);

				RemoveUnnecessaryInfo(song);
			}
			catch (IOException e)
			{
				_logController.Error(e.Message);
			}

			SaveSong(song, file);
		}

		private static void RemoveUnnecessaryInfo(File file)
		{
			file.Tag.Comment = Empty;
			file.Tag.Copyright = Empty;
		}

		private void ChangeArtist(File file, Mp3FileInfoModel fileInfo)
		{
			_logController.ChangeSongArtist(fileInfo.Artist);

			file.Tag.Performers = new[] { fileInfo.Artist };
		}

		private void ChangeTitle(File file, Mp3FileInfoModel fileInfo)
		{
			_logController.ChangeSongTitle(fileInfo.Title);

			file.Tag.Title = fileInfo.Title;
		}

		private File LoadSong(string path)
		{
			_logController.LoadSong(path);

			return File.Create(path);
		}

		private void SaveSong(File song, Mp3FileInfoModel fileInfo)
		{
			_logController.SaveSong(fileInfo);

			song.Save();
		}
	}
}
