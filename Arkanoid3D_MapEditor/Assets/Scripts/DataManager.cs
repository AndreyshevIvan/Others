using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class DataManager
{
    readonly static string m_resourcesPath = Application.dataPath + "/Resources/";
    readonly static string m_levelPath = "Levels/";
    readonly static string m_fileType = ".txt";
    readonly static string m_levelNamePattern = "Level_";

    public static void SaveLevel(Level level)
    {
        string fileName = m_levelNamePattern + level.GetKey().ToString() + m_fileType;

        BinaryFormatter bFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(m_resourcesPath + m_levelPath + fileName, FileMode.Create);

        bFormatter.Serialize(stream, level);
        stream.Close();
    }

    public static Level LoadLevel(int levelNumber)
    {
        string fileName = m_levelNamePattern + levelNumber.ToString() + m_fileType;
        Level level = null;

        if (File.Exists(m_resourcesPath + m_levelPath + fileName))
        {
            Debug.Log("File exist");
            BinaryFormatter bFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(m_resourcesPath + m_levelPath + fileName, FileMode.Open);

            level = bFormatter.Deserialize(stream) as Level;
            stream.Close();
        }

        return level;
    }
}