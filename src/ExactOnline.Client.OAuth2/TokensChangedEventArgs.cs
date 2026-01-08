namespace ExactOnline.Client.OAuth2;

public class TokensChangedEventArgs(string? newRefreshToken, string? newAccessToken, DateTime? newExpiresAt) : EventArgs
{
	public string? NewRefreshToken { get; } = newRefreshToken;
	public string? NewAccessToken { get; } = newAccessToken;
	public DateTime? NewExpiresAt { get; } = newExpiresAt;
}
