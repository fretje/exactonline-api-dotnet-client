namespace ExactOnline.Client.OAuth2;

public class TokensChangedEventArgs : EventArgs
{
	public TokensChangedEventArgs(string? newRefreshToken, string? newAccessToken, DateTime? newExpiresAt) =>
		(NewRefreshToken, NewAccessToken, NewExpiresAt) = (newRefreshToken, newAccessToken, newExpiresAt);

	public string? NewRefreshToken { get; }
	public string? NewAccessToken { get; }
	public DateTime? NewExpiresAt { get; }
}
