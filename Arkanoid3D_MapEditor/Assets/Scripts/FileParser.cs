using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;

public static class FileParser
{
    public readonly static char lineSeparator = '/';
    public readonly static char blockSeparator = '_';

    public readonly static char easyKey = 'E';
    public readonly static char normalKey = 'N';
    public readonly static char hardKey = 'H';
    public readonly static char immortalKey = 'I';
    public readonly static char emptyKey = '.';

    public readonly static char wallKey = 'W';
    public readonly static char gunsKey = 'G';
    public readonly static char lifeKey = 'L';
    public readonly static char multiplierKey = 'P';
    public readonly static char fireballKey = 'F';
    public readonly static char multyballKey = 'M';

    public readonly static string levelPattern = "Level_";
    readonly static string fileType = ".txt";
    public readonly static int systemStrCount = 2;

    readonly static string standartLevelName = "Level";
    readonly static string resourcesPath = Application.dataPath + "/Resources/";
    readonly static string levelPath = "Levels/";
    readonly static int standartGroundKey = 0;

    public readonly static int rowsCount = 20;
    public readonly static int collsCount = 14;

    public static void CreateFiles(int count)
    {
        string path = resourcesPath + levelPath;

        for(int i = 0; i < count; i++)
        {
            string file = levelPattern + i.ToString() + fileType;
            File.CreateText(path + file);
        }
    }

    static string[] GetLevelFilePattern()
    {
        int strCount = rowsCount + systemStrCount;
        string[] pattern = new string[strCount];
        string rowPattern = "";

        for (int i = 0; i < collsCount; i++)
        {
            rowPattern += emptyKey;
            rowPattern += emptyKey;
            if (i != collsCount - 1)
            {
                rowPattern += blockSeparator;
            }
        }

        for (int i = 0; i < strCount; i++)
        {
            pattern[i] = rowPattern;
        }

        pattern[0] = standartLevelName;
        pattern[1] = standartGroundKey.ToString();

        return pattern;
    }

    public static string[] GetLevel(int levelNumber)
    {
        string[] level = { };

        string file = levelPath + levelPattern + levelNumber.ToString();
        TextAsset levelCode = Resources.Load(file) as TextAsset;

        if (IsLevelValid(levelCode))
        {
            level = levelCode.text.Split(lineSeparator);
        }
        else
        {
            level = GetLevelFilePattern();
        }

        return level;
    }

    public static void EditLevel(int levelNumber, string[] level)
    {
        if (IsLevelAvalable(levelNumber))
        {
            string path = resourcesPath + levelPath;
            string file = levelPattern + levelNumber.ToString() + fileType;
            StreamWriter writer = new StreamWriter(path + file, false);

            for (int i = 0; i < level.Length; i++)
            {
                if (i != level.Length - 1)
                {
                    level[i] += lineSeparator;
                }
                writer.Write(level[i]);
            }

            writer.Close();
        }
    }

    public static bool IsLevelAvalable(int levelNumber)
    {
        string path = resourcesPath + levelPath;
        string file = levelPattern + levelNumber.ToString() + fileType;

        return File.Exists(path + file);
    }
    static bool IsLevelValid(TextAsset levelCode)
    {
        if (levelCode != null)
        {
            string[] levelRows = levelCode.text.Split(lineSeparator);

            if (levelRows.Length == systemStrCount + rowsCount)
            {
                return IsBlocksCountValid(levelRows);
            }
        }

        return false;
    }
    static bool IsBlocksCountValid(string[] levelRows)
    {
        for (int i = systemStrCount; i < levelRows.Length; i++)
        {
            string[] blocksInRow = levelRows[i].Split(blockSeparator);

            if (blocksInRow.Length != collsCount)
            {
                return false;
            }
        }

        return true;
    }
}
