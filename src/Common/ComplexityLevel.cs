using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common
{
	public enum ComplexityLevel : byte
    {
		[Display(ResourceType = typeof(General), Name = "Easy")] Easy = 1,
		[Display(ResourceType = typeof(General), Name = "Medium")] Medium = 2,
		[Display(ResourceType = typeof(General), Name = "Hard")] Hard = 3
    }
}
