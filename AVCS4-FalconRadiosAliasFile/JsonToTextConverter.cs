using Newtonsoft.Json;


namespace AVCS4_FalconRadiosAliasFile
{
    /// <summary>
    /// Provides methods to convert JSON data to a flat text format.
    /// </summary>
    public static class JsonToTextConverter
    {
        /// <summary>
        /// Converts a JSON string to a flat text format.
        /// </summary>
        /// <param name="json">The JSON string to convert.</param>
        /// <returns>A flat text representation of the JSON data.</returns>
        /// <exception cref="ArgumentException">Thrown when the JSON format is invalid.</exception>
        public static string ConvertJsonToFlatText(string json)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            if (dict == null)
            {
                throw new ArgumentException("Invalid JSON format.");
            }

            var lines = new List<string>();

            foreach (var kvp in dict)
            {
                string line = kvp.Key + "=" + string.Join(";", kvp.Value);
                lines.Add(line);
            }

            return string.Join(Environment.NewLine, lines);
        }
    }

}


