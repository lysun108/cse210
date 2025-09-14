using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        // Add a couple of your own:
        "What did I learn today that surprised me?",
        "What small act of kindness did I experience or give?"
    };

    private readonly Random _rand = new();

    public string GetRandomPrompt()
    {
        var i = _rand.Next(_prompts.Count);
        return _prompts[i];
    }
}
