using System;
using SongMassRename.Enums;

namespace SongMassRename.Models
{
	internal class TargetParameterModel
	{
		private readonly string _parameter;

		public TargetParameterModel(string parameter, TargetArgumentEnum targetArgument, Action<string> action)
		{
			_parameter = parameter;

			Action = action;
			When = targetArgument;
		}

		public string[] Parameters => new[] { $"+{_parameter}", $"-{_parameter}" };
		public Action<string> Action { get; }
		public TargetArgumentEnum When { get; }
	}
}
