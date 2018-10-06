using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("UrlMapper.Tests")]
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
            var areArgumentsValid = pattern != null && textToCompare != null;
            if (!areArgumentsValid) return false;

            var isSimpleMatched = pattern == textToCompare;
            if (isSimpleMatched) return true;

            var patternSegments = SegmentPattern(pattern);
            const int MaximumKey = 1;
            var hasPatternDuplicatedKeys = patternSegments.GroupBy(it => it).Any(it => it.Count() > MaximumKey);
            if (hasPatternDuplicatedKeys) return false;

            var inputPattern = getPattern(textToCompare, patternSegments);

            var result = pattern.Equals(inputPattern, StringComparison.CurrentCultureIgnoreCase);
            return result;
        }

        internal IEnumerable<string> SegmentPattern(string url)
        {
            var isInputValid = !string.IsNullOrEmpty(url) && !string.IsNullOrWhiteSpace(url);
            if (!isInputValid) return Enumerable.Empty<string>();

            const int MinimumRangeOfSegmentation = 0;

            const string BeginSegment = "{";
            var beginSegmentIndex = url.IndexOf(BeginSegment);
            if (beginSegmentIndex < MinimumRangeOfSegmentation) return new[] { url };

            const string EndSegment = "}";
            var endSegmentIndex = url.IndexOf(EndSegment);
            if (endSegmentIndex < MinimumRangeOfSegmentation) return new[] { url };

            const int SeparatorOffset = 1;
            var segments = new List<string>();
            while (url.Contains(BeginSegment))
            {
                var firstSegment = url.Substring(MinimumRangeOfSegmentation, beginSegmentIndex);
                if (!string.IsNullOrEmpty(firstSegment)) segments.Add(firstSegment);

                var middleSegment = url.Substring(beginSegmentIndex, endSegmentIndex - beginSegmentIndex + SeparatorOffset);
                segments.Add(middleSegment);

                var lastSegment = url.Substring(endSegmentIndex + EndSegment.Length, url.Length - EndSegment.Length - endSegmentIndex);

                url = lastSegment;
                beginSegmentIndex = url.IndexOf(BeginSegment);
                endSegmentIndex = url.IndexOf(EndSegment);

                var shouldKeepTheLastSegment = beginSegmentIndex < MinimumRangeOfSegmentation && !string.IsNullOrEmpty(lastSegment);
                if (shouldKeepTheLastSegment) segments.Add(lastSegment);
            }
            return segments;
        }

        internal string getPattern(string url, IEnumerable<string> segments)
        {
            if (url == null) return string.Empty;

            const string BeginSegment = "{";
            const string EndSegment = "}";
            const int MinimumRangeOfSegmentation = 0;
            var pattern = new StringBuilder();

            var isFirstSegment = true;
            var variableSegment = string.Empty;
            foreach (var item in segments)
            {
                var beginSegmentIndex = url.IndexOf(item);
                var isContainSegment = beginSegmentIndex >= MinimumRangeOfSegmentation;
                var isVariableSection = item.StartsWith(BeginSegment) && item.EndsWith(EndSegment);
                var shouldKeetpThisSegment = isContainSegment || isVariableSection;
                if (!shouldKeetpThisSegment)
                {
                    if (!isContainSegment && isFirstSegment) return url;
                    else continue;
                }

                if (isVariableSection) variableSegment = item;
                else
                {
                    if (!string.IsNullOrEmpty(variableSegment))
                    {
                        url = url.Remove(0, beginSegmentIndex);
                        variableSegment = string.Empty;
                        beginSegmentIndex = url.IndexOf(item);
                    }
                    url = url.Remove(beginSegmentIndex, item.Length);
                }
                pattern.Append(item);
                isFirstSegment = false;
            }

            var isVariableSegmentClear = string.IsNullOrEmpty(variableSegment);
            if (isVariableSegmentClear) pattern.Append(url);
            return pattern.ToString();
        }
    }
}