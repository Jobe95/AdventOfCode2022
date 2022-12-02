namespace AoC2022.Services;
using System;

public class Aoc2022Service : IAoc2022Service
{

    public int AoC001b()
    {
        var readText = File.ReadAllLines(@"Inputs/001.txt");
        var allElfs = new List<List<int>>();
        var currentElf = new List<int>();
        foreach (var line in readText)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                allElfs.Add(currentElf);
                currentElf = new List<int>();
                continue;
            }
            currentElf.Add(int.Parse(line));
        }
        if (currentElf.Any())
            allElfs.Add(currentElf);

        var topThreeElfs = allElfs.OrderByDescending(x => x.Sum()).Take(3);

        return topThreeElfs.Select(x => x.Sum()).Sum();
    }

    public int AoC001a()
    {
        var readText = File.ReadAllLines(@"Inputs/001.txt");
        var allElfs = new List<List<int>>();
        var currentElf = new List<int>();
        foreach (var line in readText)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                allElfs.Add(currentElf);
                currentElf = new List<int>();
                continue;
            }
            currentElf.Add(int.Parse(line));
        }
        if(currentElf.Any())
            allElfs.Add(currentElf);

        var topElf = allElfs.OrderByDescending(x => x.Sum()).FirstOrDefault();

        return topElf?.Sum() ?? 0;
    }

    public int AoC002a()
    {
        var myScore = 0;
        var readText = File.ReadAllLines(@"Inputs/002.txt");
        foreach (var result in readText)
        {
         String elf = result.Split(' ')[0];
         String mine = result.Split(' ')[1];
         int score = calculateRound(elf, mine);
         myScore += score;
        }
        return myScore;
    }

        public int AoC002b()
    {
        var myScore = 0;
        var readText = File.ReadAllLines(@"Inputs/002.txt");
        foreach (var result in readText)
        {
         String elf = result.Split(' ')[0];
         String mine = result.Split(' ')[1];
         if (mine == "X")
         {
            // WIN
            myScore += calculateRound(elf, calcLose(elf));
         } else if (mine == "Y")
         {
            // DRAW
            myScore += calculateRound(elf, elf);

         } else {
            // LOSE
            myScore += calculateRound(elf, calcWin(elf));
         }
        }
        return myScore;
    }

    private String calcWin(String elf)
    {
        if (elf == "A")
        {
            return "Y";
        } else if (elf == "B")
        {
            return "Z";
        }
        return "X";
    }

    private String calcLose(String elf)
    {
        if (elf == "A")
        {
            return "Z";
        } else if (elf == "B")
        {
            return "X";
        }
        return "Y";
    }

    

    

    private int calculateRound(String elf, String mine)
    {
        int elfScore = sumOfChar(elf);
        int myScore = sumOfChar(mine);
         if (elfScore == myScore)
        {
            return 3 + myScore;
        } else if (elfScore == 1 && myScore == 2 || elfScore == 2 && myScore == 3 || elfScore == 3 && myScore == 1)
        {
            return 6 + myScore;
        }
        return 0 + myScore;
    }



    private int sumOfChar(String result)
    {
        if (result == "A" || result == "X")
        {
            return 1;
        } else if (result == "B" || result == "Y")
        {
            return 2;
        } else {
            return 3;
        }
    }

}