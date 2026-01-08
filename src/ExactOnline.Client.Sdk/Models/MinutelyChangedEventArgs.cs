namespace ExactOnline.Client.Sdk.Models;

public class MinutelyChangedEventArgs(int newRemaining, DateTime newResetTime) : EventArgs
{
	public int NewRemaining { get; } = newRemaining;
	public DateTime NewResetTime { get; } = newResetTime;
}
