using System;
using System.Collections.Generic;
using System.Text;

namespace FoodLovers.Elastic.Constants
{
    public class TokenFilter
    {
        // built-in
        public const string AsciiFolding = "asciifolding";
        public const string CustomAsciiFolding = "asciifolding_preserv_original";
        public const string Lowercase = "lowercase";
        public const string Ngram = "ngram";
        public const string Standard = "standard";
        public const string Trim = "trim";
        public const string Whitespace_Normalization = "whitespace_normalization";
    }
}
