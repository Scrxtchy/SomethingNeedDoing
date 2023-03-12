using System.Text.RegularExpressions;

namespace SomethingNeedDoing.Grammar.Modifiers;

/// <summary>
/// The &lt;qskip&gt; modifier.
/// </summary>
internal class QualitySkipModifier : MacroModifier
{
    private static readonly Regex Regex = new(@"(?<modifier><qskip>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private QualitySkipModifier(bool isSkip)
    {
        this.IsSkip = isSkip;
    }

    /// <summary>
    /// Gets a value indicating whether the modifier was present.
    /// </summary>
    public bool IsSkip { get; }

    /// <summary>
    /// Parse the text as a modifier.
    /// </summary>
    /// <param name="text">Text to parse.</param>
    /// <param name="command">A parsed modifier.</param>
    /// <returns>A value indicating whether the modifier matched.</returns>
    public static bool TryParse(ref string text, out QualitySkipModifier command)
    {
        var match = Regex.Match(text);
        var success = match.Success;

        if (success)
        {
            var group = match.Groups["modifier"];
            text = text.Remove(group.Index, group.Length);
        }

        command = new QualitySkipModifier(success);

        return success;
    }
}
