using Newtonsoft.Json;

namespace Steam.Framework.Utils
{
    public static class TestDataReader
    {
        private static readonly string testDataPath = Path.Combine(AppContext.BaseDirectory, "Resources", "testdata.json");

        public static List<string> GetLanguages()
        {
            var jsonData = File.ReadAllText(testDataPath);
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonData);
            return jsonObject["Languages"];
        }
    }
}
