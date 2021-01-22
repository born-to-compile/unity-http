using UnityEngine;

namespace BornToCompile.Http.Service.Unity
{
	public sealed class WaitForHttpRequest : CustomYieldInstruction
	{
		public override bool keepWaiting => !HasResponded;
		public bool HasResponded { get; set; }
	}
}