using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EditorMode
{
    NONE,
    BLOCK,
    BONUS,
}

public class Tool
{
    public Tool(EditorMode mode, BlockType blockType, BonusType bonusType, string name = "")
    {
        this.mode = mode;
        this.name = name;
        this.blockType = blockType;
        this.bonusType = bonusType;
        active = false;
    }

    public void SetProperties(EditorMode mode, BlockType blockType, BonusType bonusType, string name = "")
    {
        this.mode = mode;
        this.name = name;
        this.blockType = blockType;
        this.bonusType = bonusType;
        active = false;
    }

    public EditorMode mode;
    public BlockType blockType;
    public BonusType bonusType;

    public bool active;
    public string name;
}

public class EditorController : MonoBehaviour
{
    public GameObject m_buttonsInner;
    public ButtonsArea m_buttonsArea;
    public MapPlane m_mapPlane;
    public EditorUI m_interface;

    Level m_editLevel;
    Tool m_tool;

    int m_editLevelNumber;

    const int LEVELS_COUNT = 50;

    void Awake()
    {
        m_tool = new Tool(EditorMode.BLOCK, BlockType.EASY, BonusType.NONE);
        m_buttonsArea.Init(LEVELS_COUNT);
        m_interface.Init(ref m_tool);
        m_buttonsArea.startEdit += StartEditLevel;

        //ResetAllLevels();
    }
    void Start()
    {
        m_interface.SetLevelsMode();
    }
    public void StartEditLevel(int levelNumber)
    {
        m_editLevel = DataManager.LoadLevel(levelNumber);
        m_mapPlane.Init(m_editLevel, ref m_tool);
        m_buttonsInner.SetActive(false);
        m_tool.active = true;
        SetBlockMode();
    }
    public void BackToLevels()
    {
        m_interface.SetLevelsMode();
        m_buttonsInner.SetActive(true);
        m_tool.active = false;
    }
    void ResetAllLevels()
    {
        for (int i = 0; i < LEVELS_COUNT; i++)
        {
            Level emptyLevel = new Level(i);
            DataManager.SaveLevel(emptyLevel);
        }
    }

    public void SetBlockMode()
    {
        m_interface.SetBlockMode();
        m_mapPlane.SetBlockMode();
        SetEasyBlockTool();
    }
    public void SetBonusMode()
    {
        m_interface.SetBonusMode();
        m_mapPlane.SetBonusMode();
        SetGunsTool();
    }

    public void SetEasyBlockTool()
    {
        m_tool.SetProperties(EditorMode.BLOCK, BlockType.EASY, BonusType.NONE);
    }
    public void SetNormalBlockTool()
    {
        m_tool.SetProperties(EditorMode.BLOCK, BlockType.NORMAL, BonusType.NONE);
    }
    public void SetHardBlockTool()
    {
        m_tool.SetProperties(EditorMode.BLOCK, BlockType.HARD, BonusType.NONE);
    }
    public void SetImmortalBlockTool()
    {
        m_tool.SetProperties(EditorMode.BLOCK, BlockType.IMMORTAL, BonusType.NONE);
    }
    public void SetBlockLasticTool()
    {
        m_tool.SetProperties(EditorMode.BLOCK, BlockType.NONE, BonusType.NONE);
    }

    public void SetWallTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.WALL);
    }
    public void SetFireballTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.FIRE_BALL);
    }
    public void SetMultyballTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.MULIBALL);
    }
    public void SetMultiplierTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.MULTIPLIER);
    }
    public void SetGunsTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.GUNS);
    }
    public void SetLifeTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.LIFE);
    }
    public void SetBonusLasticTool()
    {
        m_tool.SetProperties(EditorMode.BONUS, BlockType.NONE, BonusType.NONE);
    }

    public void SaveEditLevel()
    {
        List<BlockType> newBlocksMap = m_mapPlane.GetBlocksMap();
        List<BonusType> newBonusMap = m_mapPlane.GetBonusMap();

        m_editLevel.SetBlocksMap(newBlocksMap);
        m_editLevel.SetBonusesMap(newBonusMap);

        DataManager.SaveLevel(m_editLevel);
    }
}