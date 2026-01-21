using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace SparkSchemaCreator.Controls.FastColoredTextBox
{
    public class SyntaxDescriptor: IDisposable
    {
        public char leftBracket = '(';
        public char rightBracket = ')';
        public char leftBracket2 = '{';
        public char rightBracket2 = '}';
        public BracketsHighlightStrategy bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
        public readonly List<Style> styles = [];
        public readonly List<RuleDesc> rules = [];
        public readonly List<FoldingDesc> foldings = [];

        public void Dispose()
        {
            foreach (var style in styles)
                style.Dispose();

            GC.SuppressFinalize(this);
        }
    }

    public class RuleDesc(string _pattern)
    {
        Regex? regex;
        public string pattern = _pattern;
        public RegexOptions options = RegexOptions.None;
        public Style? style;

        public Regex Regex
        {
            get
            {
                regex ??= new Regex(pattern!, SyntaxHighlighter.RegexCompiledOption | options);
                return regex;
            }
        }
    }

    public class FoldingDesc
    {
        public string? startMarkerRegex;
        public string? finishMarkerRegex;
        public RegexOptions options = RegexOptions.None;
    }
}
