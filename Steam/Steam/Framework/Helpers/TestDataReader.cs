using Newtonsoft.Json;
using Steam.Framework.Models;

namespace Steam.Framework.Utils
{
    public static class TestDataReader
    {
        private static readonly string testDataPath = Path.Combine(AppContext.BaseDirectory, "Resources", "testdata.json");

        private static FullTestData LoadData()
        {
            var json = File.ReadAllText(testDataPath);
            return JsonConvert.DeserializeObject<FullTestData>(json);
        }

        public static List<string> GetLanguages()
        {
            return LoadData().Languages;
        }
    }
}
