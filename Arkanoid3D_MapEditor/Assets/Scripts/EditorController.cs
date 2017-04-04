using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType
{
    BLOCK,
    BONUS,
}

public struct Tool
{
    public Tool(char key, ToolType type)
    {
        this.key = key;
        this.type = type;
    }

    public char key;
    public ToolType type;
}

public class EditorController : MonoBehaviour, IEditorTool
{
    public GameObject m_buttonsInner;
    public ButtonsArea m_buttonsArea;
    public MapPlane m_mapPlane;
    public UIArea m_interface;

    Tool m_currTool;

    Tool m_easyBlock;
    Tool m_normalBlock;
    Tool m_hardBlock;
    Tool m_immortalBlock;
    Tool m_blockLastic;

    Tool m_wallBonus;
    Tool m_multyballBonus;
    Tool m_fireballBonus;
    Tool m_pointsBonus;
    Tool m_lifeBonus;
    Tool m_gunsBonus;
    Tool m_bonusLastic;

    string[] m_level;
    int m_editLevelNumber;
    bool m_isToolActive = false;

    const int LEVELS_COUNT = 50;

    public int levelsCount
    {
        get
        {
            return LEVELS_COUNT;
        }
    }

    void Awake()
    {
        m_buttonsArea.Init(this);
        m_interface.Init(this);
        FileParser.CreateFiles(LEVELS_COUNT);
        InitTools();
    }
    void Start()
    {
        m_interface.SetActive(false);
    }
    public void StartEditLevel(int levelNumber)
    {
        if (FileParser.IsLevelAvalable(levelNumber))
        {
            m_isToolActive = true;
            m_interface.SetActive(true);
            m_editLevelNumber = levelNumber;
            m_buttonsInner.SetActive(false);
            m_level = FileParser.GetLevel(levelNumber);
            PreparePlan();
        }
    }
    public void BackToLevels()
    {
        m_isToolActive = false;
        m_buttonsInner.SetActive(true);
        m_interface.SetActive(false);
    }

    void InitTools()
    {
        m_easyBlock = new Tool(FileParser.easyKey, ToolType.BLOCK);
        m_normalBlock = new Tool(FileParser.normalKey, ToolType.BLOCK);
        m_hardBlock = new Tool(FileParser.hardKey, ToolType.BLOCK);
        m_immortalBlock = new Tool(FileParser.immortalKey, ToolType.BLOCK);
        m_blockLastic = new Tool(FileParser.emptyKey, ToolType.BLOCK);

        m_wallBonus = new Tool(FileParser.wallKey, ToolType.BONUS);
        m_multyballBonus = new Tool(FileParser.multiballKey, ToolType.BONUS);
        m_fireballBonus = new Tool(FileParser.fireballKey, ToolType.BONUS);
        m_pointsBonus = new Tool(FileParser.multiplierKey, ToolType.BONUS);
        m_lifeBonus = new Tool(FileParser.lifeKey, ToolType.BONUS);
        m_gunsBonus = new Tool(FileParser.gunsKey, ToolType.BONUS);
        m_bonusLastic = new Tool(FileParser.emptyKey, ToolType.BONUS);

        SetEasyBlockTool();
    }

    public Tool GetCurrentTool()
    {
        return m_currTool;
    }

    void PreparePlan()
    {
        int blocksCount = FileParser.collsCount * FileParser.rowsCount;
        string[] blocks = new string[blocksCount];

        for (int i = FileParser.systemStrCount; i < m_level.Length; i++)
        {
            string[] blockInRow = m_level[i].Split(FileParser.blockSeparator);

            for (int j = 0; j < blockInRow.Length; j++)
            {
                int rowNum = i - FileParser.systemStrCount;
                int blockNum = rowNum * FileParser.collsCount + j;

                blocks[blockNum] = blockInRow[j];
            }
        }

        m_mapPlane.Init(this, m_interface, blocks);
    }

    public void SetEasyBlockTool()
    {
        m_currTool = m_easyBlock;
    }
    public void SetNormalBlockTool()
    {
        m_currTool = m_normalBlock;
    }
    public void SetHardBlockTool()
    {
        m_currTool = m_hardBlock;
    }
    public void SetImmortalBlockTool()
    {
        m_currTool = m_immortalBlock;
    }
    public void SetBlockLasticTool()
    {
        m_currTool = m_blockLastic;
    }

    public void SetWallTool()
    {
        m_currTool = m_wallBonus;
    }
    public void SetFireballTool()
    {
        m_currTool = m_fireballBonus;
    }
    public void SetMultyballTool()
    {
        m_currTool = m_multyballBonus;
    }
    public void SetMultiplierTool()
    {
        m_currTool = m_pointsBonus;
    }
    public void SetGunsTool()
    {
        m_currTool = m_gunsBonus;
    }
    public void SetLifeTool()
    {
        m_currTool = m_lifeBonus;
    }
    public void SetBonusLasticTool()
    {
        m_currTool = m_bonusLastic;
    }

    public void SaveEditLevel()
    {
        string[] newRowsCode = m_mapPlane.GetRowsCode();
        int rowNum = 0;

        for (int i = FileParser.systemStrCount; i < m_level.Length; i++)
        {
            m_level[i] = newRowsCode[rowNum];
            rowNum++;
        }

        if (m_isToolActive)
        {
            FileParser.EditLevel(m_editLevelNumber, m_level);
        }
    }

    public bool IsActive()
    {
        return m_isToolActive;
    }

}