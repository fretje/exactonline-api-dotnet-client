// Polyfills for C# 9+ language features on netstandard2.0.
// Required because the compiler emits references to these BCL types when it sees
// `init` accessors, `required` members and `[SetsRequiredMembers]`, but netstandard2.0
// does not ship them.

namespace System.Runtime.CompilerServices
{
	internal static class IsExternalInit { }

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
	internal sealed class RequiredMemberAttribute : Attribute { }

	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	internal sealed class CompilerFeatureRequiredAttribute(string featureName) : Attribute
	{
		public string FeatureName { get; } = featureName;
		public bool IsOptional { get; init; }

		public const string RefStructs = nameof(RefStructs);
		public const string RequiredMembers = nameof(RequiredMembers);
	}
}

namespace System.Diagnostics.CodeAnalysis
{
	[AttributeUsage(AttributeTargets.Constructor, Inherited = false)]
	internal sealed class SetsRequiredMembersAttribute : Attribute { }
}
