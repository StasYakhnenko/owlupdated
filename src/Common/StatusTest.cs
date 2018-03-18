using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common
{
	public enum StatusTest : byte
    {
		[Display(ResourceType = typeof(General), Name = "NotFinished")]
		NotFinished = 1,
		[Display(ResourceType = typeof(General), Name = "Finished")]
		Finished
    }
}
