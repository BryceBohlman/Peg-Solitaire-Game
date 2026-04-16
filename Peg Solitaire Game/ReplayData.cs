using Peg_Solitaire_Game;
using System;
using System.Collections.Generic;
using System.IO;

public class ReplayData
{
    public int Size { get; set; }
    public string Type { get; set; } = "";
    public string Mode { get; set; } = "";
    public List<GameMove> Moves { get; set; } = new List<GameMove>();

    public static ReplayData LoadFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length < 5)
            throw new InvalidDataException("Replay file is incomplete.");

        ReplayData data = new ReplayData
        {
            Size = ParseInt(lines[0], "Size"),
            Type = ParseString(lines[1], "Type"),
            Mode = ParseString(lines[2], "Mode")
        };

        int movesCount = ParseInt(lines[3], "MovesCount");

        if (!lines[4].Equals("Moves:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException("Missing Moves section.");

        for (int i = 5; i < 5 + movesCount; i++)
        {
            if (i >= lines.Length)
                throw new InvalidDataException("Replay file ended early.");

            data.Moves.Add(GameMove.Parse(lines[i]));
        }

        return data;
    }

    private static int ParseInt(string line, string key)
    {
        string prefix = key + "=";
        if (!line.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException($"Missing {key} header.");

        return int.Parse(line.Substring(prefix.Length));
    }

    private static string ParseString(string line, string key)
    {
        string prefix = key + "=";
        if (!line.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException($"Missing {key} header.");

        return line.Substring(prefix.Length).Trim();
    }
}