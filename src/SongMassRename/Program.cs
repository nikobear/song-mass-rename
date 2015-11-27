using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using SongMassRename.Controllers;
using SongMassRename.Controllers.Interfaces;
using SongMassRename.Enums;
using SongMassRename.Extensions;
using SongMassRename.Models;
using SongMassRename.Properties;

using static System.String;

namespace SongMassRename
{
	internal class Program
	{
		private static readonly ILogController LogController = new LogController();
		private static readonly ITagModifyController TagModifyController = new TagModifyController(LogController);
		private static readonly IDirectoryReaderController DirectoryReaderController = new DirectoryReaderController(LogController);

		private static IEnumerable<TargetParameterModel> TargetParameters => new List<TargetParameterModel>
		{
			new TargetParameterModel(NonLocalizable.ParameterPrint, TargetArgumentEnum.End, s => Console.ReadLine()),
			new TargetParameterModel(NonLocalizable.ParameterLanguage, TargetArgumentEnum.Beginning, SetDefaultLanguage)
		};

		private static void SetDefaultLanguage(string culture)
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
		}

		private static void Main(string[] args)
		{
			CheckArguments(args, TargetArgumentEnum.Beginning);

			LogController.ProgramStart();

			var files = DirectoryReaderController.GetFilesInCurrentFolder();

			TagModifyController.Refactor(files);

			LogController.ProgramEnd();

			CheckArguments(args, TargetArgumentEnum.End);
		}

		private static void CheckArguments(IList<string> args, TargetArgumentEnum when)
		{
			if (args.Count <= 0)
			{
				return;
			}

			foreach (var argument in args)
			{
				var option = args.NextOf(argument);
				var hasParameter = option.First() == '+' || option.First() == '-' ? Empty : option;

				TargetParameters.FirstOrDefault(x => x.Parameters.Contains(argument) && x.When == when)?.Action.Invoke(hasParameter);
			}
		}
	}

}
