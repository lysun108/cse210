using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new();

    public void AddEntry(Entry e) => _entries.Add(e);

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using var sw = new StreamWriter(filename);
        foreach (var e in _entries)
        {
            sw.WriteLine(e.Serialize());
        }
        Console.WriteLine($"Saved {_entries.Count} entries to \"{filename}\".\n");
    }

    public void LoadFromFile(string filename)
    {
        var lines = File.ReadAllLines(filename);
        _entries.Clear();
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            _entries.Add(Entry.Deserialize(line));
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from \"{filename}\".\n");
    }
}
