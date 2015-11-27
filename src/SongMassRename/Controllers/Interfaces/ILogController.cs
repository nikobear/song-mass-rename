using SongMassRename.Enums;
using SongMassRename.Models;
using TagLib;

namespace SongMassRename.Controllers.Interfaces
{
	internal interface ILogController
	{
		void ProgramEnd();
		void ProgramStart();

		void Start(SongActionEnum actionEnum);
		void End(SongActionEnum refactor);

		void LoadSong(string path);
		void SaveSong(Mp3FileInfoModel song);

		void ChangeTag(Mp3FileInfoModel file);
		void ChangeSongArtist(string artist);
		void ChangeSongTitle(string title);
		
		void FoundFiles(int count);
	}
}
