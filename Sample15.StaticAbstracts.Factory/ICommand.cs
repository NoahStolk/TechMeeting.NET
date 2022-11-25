namespace Sample15.StaticAbstracts.Factory;

public interface ICommand<out TSelf> // Use the "curiously recurring template pattern" together with static abstract members
	where TSelf : ICommand<TSelf>
{
	static abstract TSelf Parse(string[] arguments);

	void Execute();
}
