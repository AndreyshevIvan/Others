using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;

public class FileParser : MonoBehaviour
{
    public FileParser(int levelNumber)
    {
        m_levelNumber = levelNumber;
        m_level = GetLevel();
    }

    int m_levelNumber;
    string[] m_level;

    const char SEPARATOR = '/';
    const char EASY_KEY = 'E';
    const char NORMAL_KEY = 'N';
    const char HARD_KEY = 'H';
    const char IMMORTAL_KEY = 'I';
    const char EMPTY_KEY = '.';

    const string LEVEL_PATTERN = "Level";
    const string STANDART_LEVEL_NAME = "Level";
    const int SYSTEM_STR_COUNT = 2;
    const int STANDART_GROUND_KEY = 0;

    const int ROWS_COUNT = 20;
    const int COLLS_COUNT = 14;

    public string[] level
    {
        get
        {
            return m_level;
        }
    }
    public int collsCount
    {
        get
        {
            return COLLS_COUNT;
        }
    }
    public int rowsCount
    {
        get
        {
            return ROWS_COUNT;
        }
    }
    public int blocksCount
    {
        get
        {
            return (ROWS_COUNT * COLLS_COUNT);
        }
    }
    public char easy
    {
        get
        {
            return EASY_KEY;
        }
    }
    public char normal
    {
        get
        {
            return NORMAL_KEY;
        }
    }
    public char hard
    {
        get
        {
            return HARD_KEY;
        }
    }
    public char immortal
    {
        get
        {
            return IMMORTAL_KEY;
        }
    }
    public char empty
    {
        get
        {
            return EMPTY_KEY;
        }
    }

    string[] GetLevelFilePattern()
    {
        const int strCount = ROWS_COUNT + SYSTEM_STR_COUNT;
        string[] pattern = new string[strCount];
        string emptyRow = "";

        for (int i = 0; i < COLLS_COUNT; i++)
        {
            emptyRow += empty;
        }

        for (int i = 0; i < strCount; i++)
        {
            pattern[i] = emptyRow;
        }

        pattern[0] = STANDART_LEVEL_NAME;
        pattern[1] = STANDART_GROUND_KEY.ToString();

        return pattern;
    }
    string[] GetLevel()
    {
        TextAsset levelCode = Resources.Load(LEVEL_PATTERN + m_levelNumber.ToString()) as TextAsset;
        string[] level = levelCode.text.Split(SEPARATOR);

        if (level.Length != SYSTEM_STR_COUNT + ROWS_COUNT)
        {
            level = GetLevelFilePattern();
        }

        return level;
    }

    // TODO: Обезопасить
    public void EditLevel(string[] level)
    {
        string path = Application.dataPath + "/Resources/" + LEVEL_PATTERN + m_levelNumber + ".txt";
        StreamWriter writer = new StreamWriter(path, false);

        for (int i = 0; i < level.Length; i++)
        {
            if (i != level.Length - 1)
            {
                level[i] += SEPARATOR;
            }
            writer.Write(level[i]);
        }

        writer.Close();
    }
}
