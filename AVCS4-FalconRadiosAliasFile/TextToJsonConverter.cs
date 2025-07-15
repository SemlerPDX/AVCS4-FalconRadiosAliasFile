using Newtonsoft.Json;

namespace AVCS4_FalconRadiosAliasFile
{
    public static class TextToJsonConverter
    {
        /// <summary>
        /// Converts a flat text format to a JSON string.
        /// </summary>
        /// <param name="flatText">The flat text to convert.</param>
        /// <returns>The JSON representation of the flat text.</returns>
        public static string ConvertFlatTextToJson(string flatText)
        {
            var dict = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            var lines = flatText.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length != 2)
                {
                    continue;
                }

                var key = parts[0].Trim();
                var values = parts[1].Split([';'], StringSplitOptions.RemoveEmptyEntries);
                dict[key] = [];

                foreach (var v in values)
                {
                    dict[key].Add(v.Trim());
                }
            }

            return JsonConvert.SerializeObject(dict, Formatting.Indented);
        }
    }

}
