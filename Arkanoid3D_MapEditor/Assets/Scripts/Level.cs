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
        m_blocksMap = new List<BlockType>();
        m_bonusesMap = new List<BonusType>();

        ResetItems();
    }

    int m_key;
    int m_groundKey;
    List<BlockType> m_blocksMap;
    List<BonusType> m_bonusesMap;

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

    void ResetItems()
    {
        for (int i = 0; i < blocksCount; i++)
        {
            m_blocksMap.Add(BlockType.NONE);
            m_bonusesMap.Add(BonusType.NONE);
        }
    }

    public int GetKey()
    {
        return m_key;
    }
    public List<BlockType> GetBlocksMap()
    {
        return m_blocksMap;
    }
    public List<BonusType> GetBonusesMap()
    {
        return m_bonusesMap;
    }

    public void SetBlocksMap(List<BlockType> blocksMap)
    {
        m_blocksMap = blocksMap;
    }
    public void SetBonusesMap(List<BonusType> blocksMap)
    {
        m_bonusesMap = blocksMap;
    }
}