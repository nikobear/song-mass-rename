using System.Collections.Generic;
using SongMassRename.Models;

namespace SongMassRename.Controllers.Interfaces
{
	internal interface IDirectoryReaderController
	{
		IEnumerable<Mp3FileInfoModel> GetFilesInCurrentFolder();
	}
}
