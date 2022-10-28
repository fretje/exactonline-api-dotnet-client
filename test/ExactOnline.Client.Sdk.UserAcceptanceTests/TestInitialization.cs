using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace User_Acceptance_Tests;

[TestClass]
public static class TestInitialization
{
	[AssemblyInitialize]
	public static void AssemblyInit(TestContext context) =>
		ServicePointManager.ServerCertificateValidationCallback = TrustAllCertificates;

	private static bool TrustAllCertificates(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error) =>
		true;
}
