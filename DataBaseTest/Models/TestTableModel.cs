
namespace DataBaseTest.Models
{
    public class TestTableModel
    {
        public Dictionary<string, object> TestTableRow = new Dictionary<string, object>();
        public void AddColumn(string key, object value)
        {
            TestTableRow.Add(key, $"\"{value.ToString()}\"");
        }
        public void AddColumn(string key, DateTime value)
        {
            TestTableRow.Add(key, $"\"{value.ToString("yyyy-MM-dd HH:mm:ss")}\"");
        }

        public Dictionary<string, object> GetKeyValuePairs() => TestTableRow;
    }
    public enum TestResultStatus
    {
        Passed = 1,
        Failed = 2,
        Ignored = 3
    }
}
