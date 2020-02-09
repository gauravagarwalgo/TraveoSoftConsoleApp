using System;

namespace TraveoSoftConsoleApp
{
    /// <summary>
    /// Represents class generate query helper which is using to get query string by reading the character
    /// </summary>
    public class GenerateQueryHelper
    {
        /// <summary>
        /// Represents method to Get String
        /// </summary>
        /// <param name="name"></param>
        /// <returns>String</returns>  
        public string GetString(string name)
        {
            System.Reflection.Assembly assembly = typeof(PersonRepository).Assembly;
            var result = string.Empty;
            foreach (string resName in assembly.GetManifestResourceNames())
            {
                if (resName.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(assembly.GetManifestResourceStream(resName));
                    string data = sr.ReadToEnd();
                    sr.Close();
                    result = data;
                }
            }
            return result;
        }
    }
}
