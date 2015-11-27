using System.Collections.Generic;
using SongMassRename.Models;

namespace SongMassRename.Controllers.Interfaces
{
	internal interface ITagModifyController
	{
		void Refactor(IEnumerable<Mp3FileInfoModel> files);
	}
}
