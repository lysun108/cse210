using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }   // Extra field for bonus credit

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = string.IsNullOrWhiteSpace(mood) ? "Neutral" : mood.Trim();
    }

    public override string ToString()
    {
        return $"[{Date}] {Prompt}\n  {Response}\n  Mood: {Mood}";
    }

    // Use a separator unlikely to appear in text
    private static readonly string Sep = "~|~";

    public string Serialize() => $"{Date}{Sep}{Prompt}{Sep}{Response}{Sep}{Mood}";

    public static Entry Deserialize(string line)
    {
        var parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
        if (parts.Length == 4)
        {
            return new Entry(parts[0], parts[1], parts[2], parts[3]);
        }
        else if (parts.Length == 3) // Backward compatibility (no mood in older files)
        {
            return new Entry(parts[0], parts[1], parts[2], "Neutral");
        }
        else
        {
            throw new FormatException("Corrupt journal line.");
        }
    }
}
