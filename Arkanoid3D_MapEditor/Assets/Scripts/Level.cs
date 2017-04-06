using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public enum BlockType
{
    NONE,
    EASY,
    NORMAL,
    HARD,
    IMMORTAL,
}

public enum BonusType
{
    NONE,
    WALL,
    FIRE_BALL,
    MULTIPLIER,
    MULIBALL,
    GUNS,
    LIFE,
}

[System.Serializable]
public class Level : IGameLevel
{
    public Level(int key)
    {
        m_key = key;
        m_blocksMap = new BlockType[blocksCount];
        m_bonusesMap = new BonusType[blocksCount];

        for (int i = 0; i < blocksCount; i++)
        {
            m_blocksMap[i] = BlockType.NONE;
            m_bonusesMap[i] = BonusType.NONE;
        }
    }

    int m_key;
    int m_groundKey;
    BlockType[] m_blocksMap;
    BonusType[] m_bonusesMap;

    readonly static int m_rowsCount = 20;
    readonly static int m_collsCount = 14;

    public static int rowsCount
    {
        get { return m_rowsCount; }
    }
    public static int collsCount
    {
        get { return m_collsCount; }
    }
    public static int blocksCount
    {
        get { return m_rowsCount * m_collsCount; }
    }

    public int GetKey()
    {
        return m_key;
    }
    public BlockType[] GetBlocksMap()
    {
        return m_blocksMap;
    }
    public BonusType[] GetBonusesMap()
    {
        return m_bonusesMap;
    }
}