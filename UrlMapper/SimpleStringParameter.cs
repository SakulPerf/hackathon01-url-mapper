using System.Collections.Generic;

namespace UrlMapper
{
    public class SimpleStringParameter : ISimpleStringParameter
    {
        public readonly string pattern;

        public SimpleStringParameter(string pattern) => this.pattern = pattern;

        public void ExtractVariables(string target, IDictionary<string, string> dicToStoreResults)
        {
            throw new System.NotImplementedException();
        }

        public bool IsMatched(string textToCompare)
        {
            throw new System.NotImplementedException();
        }
    }
}