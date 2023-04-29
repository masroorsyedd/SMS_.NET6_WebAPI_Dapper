namespace TechSol.StudentManagementSystem.Utility.Common
{
    public class ListKeyValuePair<TKey,TValue> : List<KeyValuePair<TKey, TValue>>
	{
		public void Add(TKey key, TValue value)
		{
			var element = new KeyValuePair<TKey, TValue>(key, value);
			this.Add(element);
		}
	}
}
