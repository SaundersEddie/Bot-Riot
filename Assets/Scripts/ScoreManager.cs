using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static List<(string initials, int score)> highScores = new List<(string, int)>
    {
        ("AAA", 99900),
        ("ZXK", 88950),
        ("DOG", 87300),
        ("YT1", 85200),
        ("MRT", 81900),
        ("LNA", 79250),
        ("PPN", 77000)
    };

    public static void AddScore(string initials, int score)
    {
        highScores.Add((initials.ToUpper(), score));
        highScores.Sort((a, b) => b.score.CompareTo(a.score)); // Descending
        if (highScores.Count > 10)
            highScores.RemoveAt(highScores.Count - 1);
    }

    public static string GetFormattedScores()
    {
        string result = "";
        foreach (var (initials, score) in highScores)
        {
            result += $"{initials} – {score}   ";
        }
        return result;
    }
}
