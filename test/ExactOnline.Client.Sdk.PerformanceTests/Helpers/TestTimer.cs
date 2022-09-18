using System.Diagnostics;

namespace ExactOnline.Client.Sdk.PerformanceTests.Helpers;

public class TestTimer
{
	public static TimeSpan Time(Action toTime)
	{
		var timer = Stopwatch.StartNew();
		toTime();
		timer.Stop();
		return timer.Elapsed;
	}
}
