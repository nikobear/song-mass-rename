using System.Collections.Generic;
using System.IO;
using System.Linq;
using SongMassRename.Controllers.Interfaces;
using SongMassRename.Enums;
using SongMassRename.Models;
using SongMassRename.Properties;

namespace SongMassRename.Controllers
{
	internal class DirectoryReaderController : IDirectoryReaderController
	{
		private readonly ILogController _logController;

		public DirectoryReaderController(ILogController logController)
		{
			_logController = logController;
		}

		public IEnumerable<Mp3FileInfoModel> GetFilesInCurrentFolder()
		{
			_logController.Start(SongActionEnum.FilesInFolder);

			var files = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*.{Settings.Default.FileFormat}")
						.Select(x => new Mp3FileInfoModel(x))
						.ToList();

			_logController.FoundFiles(files.Count);

			_logController.End(SongActionEnum.FilesInFolder);

			return files;
		}
	}
}
