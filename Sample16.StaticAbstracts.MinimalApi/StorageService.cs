using System.Collections.Concurrent;

namespace Sample16.StaticAbstracts.MinimalApi;

public class StorageService
{
	private readonly ConcurrentDictionary<string, string> _storage = new();

	public string GetByKey(string key)
	{
		return _storage.TryGetValue(key, out string? value) ? value : string.Empty;
	}
	
	public void Add(string key, string value)
	{
		_storage.TryAdd(key, value);
	}

	public void Clear()
	{
		_storage.Clear();
	}
}
