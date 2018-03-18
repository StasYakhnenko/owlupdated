using BAL.Interface;
using DAL.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Model.DTO;
using System.Text.RegularExpressions;
using Common;
using System.Linq;
using System.Diagnostics;

namespace BAL.Manager
{
    public class ImportQuestionsManager : BaseManager, IImportQuestionsManager
	{
		private readonly ILogger logger;
		
		private const string patternForImagelink = @"(?<=Зображення:)(.*)(?=;)";
		private const string patternForLevel = @"(?<=Рівень:)(.*)(?=;)";
		private const string patternForAnswers = @"(?<=Відповідь)(.*)(?=;)";

		public ImportQuestionsManager(IUnitOfWorkOld uOw, ILogger<QuestionManager> logger) : base(uOw)
		{
			this.logger = logger;
		}

		public QuestionsImportResultDTO ProccessFileForImport(string path)
		{
			var content = System.IO.File.ReadAllText(path);
			var questionBlocks = content.Split(new string[] { new string('-', 5) }, StringSplitOptions.RemoveEmptyEntries);
			var questions = new List<QuestionDTO>();
			var sb = new StringBuilder();
			var i = 0;

			foreach (var questionBlock in questionBlocks)
			{
				try
				{
					i++;
					string patternForText = @"(?<=Текст:)([\s\S]*?)(?=Зображення:)";
					var test = Regex.Match(questionBlock, patternForText);
					string textOfQuestion = Regex.Match(questionBlock, patternForText).Value;
					Debug.WriteLine(i);
					textOfQuestion = textOfQuestion.Substring(0, textOfQuestion.LastIndexOf(';'));
					string imageLink = Regex.Match(questionBlock, patternForImagelink).Value;
					string levelString = Regex.Match(questionBlock, patternForLevel).Value;

					ValidateBaseInformation(ref sb, textOfQuestion, levelString, i);
					ComplexityLevel level = levelString == "Легкий" ? level = ComplexityLevel.Easy :
						(levelString == "Середній" ? ComplexityLevel.Medium : ComplexityLevel.Hard);

					var question = new QuestionDTO
					{
						Text = textOfQuestion,
						ImageLink = imageLink,
						Level = level,
						Answers = new List<AnswerDTO>()
					};
					var answerBlocks = Regex.Matches(questionBlock, patternForAnswers);
					var j = 0;
					foreach (Match answerBlock in answerBlocks)
					{
						j++;
						bool isCorrent = answerBlock.Value.Contains("(вірна)");
						var answerText = answerBlock.Value.Substring(answerBlock.Value.IndexOf(":") + 1);

						if (string.IsNullOrEmpty(answerText))
						{
							sb.AppendLine($"Помилка: на {i}-ому питанні текст {j}-ої відповіді пустий");
						}
						question.Answers.Add(new AnswerDTO
						{
							Text = answerText,
							IsCorrect = isCorrent
						});
					}
					if (!question.Answers.Any(x => x.IsCorrect))
					{
						sb.AppendLine($"Помилка: на {i}-ому питанні немає жодної коректної відповіді");
					}
					questions.Add(question);
				}
				catch
				{
					var a = i;
					;
				}
			}

			if (sb.Length != 0)
			{
				return new QuestionsImportResultDTO
				{
					IsSuccessful = false,
					ErrorMessage = sb.ToString().Split(new string[] { Environment.NewLine },StringSplitOptions.None),
				};
			}

			return new QuestionsImportResultDTO
			{
				IsSuccessful = true,
				GottenQuestions = questions
			};
		}
		private void ValidateBaseInformation(ref StringBuilder sb, string textOfQuestion, string levelString, int i)
		{
			var levels = new List<string> { "Легкий", "Середній", "Важкий" };

			if (string.IsNullOrEmpty(textOfQuestion.Trim()))
			{
				sb.AppendLine($"Помилка: текст {i}-ого питання пустий");
			}
			if (!levels.Contains(levelString))
			{
				sb.AppendLine($"Помилка: рівень {i}-ого питання не коректний");
			}
		}
	}
}
