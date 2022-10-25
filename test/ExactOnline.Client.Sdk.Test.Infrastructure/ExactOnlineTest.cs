using System.Globalization;

namespace ExactOnline.Client.Sdk.Test.Infrastructure;

public static class ExactOnlineTest
{
	public static string Url => "https://start.exactonline.be";

	private static readonly string _refreshTokenCacheFile = @"c:\temp\refreshTokenCache";
	private static readonly string _accessTokenCacheFile = @"c:\temp\accessTokenCache";
	private static readonly string _accessTokenExpiresAtCacheFile = @"c:\temp\accessTokenExpiresAtCache";
	private static readonly string _minutelyRemainingCacheFile = @"c:\temp\minutelyRemainingCache";
	private static readonly string _minutelyResetTimeCacheFile = @"c:\temp\minutelyResetTimeCache";

	public static string RefreshToken
	{
		get => File.Exists(_refreshTokenCacheFile) ? File.ReadAllText(_refreshTokenCacheFile) : null;
		set
		{
			if (value is not null)
			{
				File.WriteAllText(_refreshTokenCacheFile, value);
			}
			else
			{
				File.Delete(_refreshTokenCacheFile);
			}
		}
	}

	public static string AccessToken
	{
		get => File.Exists(_accessTokenCacheFile) ? File.ReadAllText(_accessTokenCacheFile) : null;
		set
		{
			if (value is not null)
			{
				File.WriteAllText(_accessTokenCacheFile, value);
			}
			else
			{
				File.Delete(_accessTokenCacheFile);
			}
		}
	}

	public static DateTime? AccessTokenExpiresAt
	{
		get => File.Exists(_accessTokenExpiresAtCacheFile) ? DateTime.Parse(File.ReadAllText(_accessTokenExpiresAtCacheFile), null, DateTimeStyles.RoundtripKind) : null;
		set
		{
			if (value.HasValue)
			{
				File.WriteAllText(_accessTokenExpiresAtCacheFile, value.Value.ToString("o"));
			}
			else
			{
				File.Delete(_accessTokenExpiresAtCacheFile);
			}
		}
	}

	public static int MinutelyRemaining
	{
		get => File.Exists(_minutelyRemainingCacheFile) ? int.Parse(File.ReadAllText(_minutelyRemainingCacheFile)) : -1;
		set
		{
			File.WriteAllText(_minutelyRemainingCacheFile, $"{value}");
		}
	}

	public static DateTime MinutelyResetTime
	{
		get => File.Exists(_minutelyResetTimeCacheFile) ? DateTime.Parse(File.ReadAllText(_minutelyResetTimeCacheFile), null, DateTimeStyles.RoundtripKind) : default;
		set
		{
			File.WriteAllText(_minutelyResetTimeCacheFile, value.ToString("o"));
		}
	}

	public static TimeSpan MinutelyWaitTime
	{
		get
		{
			var waitTime = MinutelyResetTime - DateTime.Now;
			return waitTime < TimeSpan.Zero ? TimeSpan.Zero : waitTime;
		}
	}
}
