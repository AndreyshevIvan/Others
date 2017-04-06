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

    Tool m_tool;

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
        m_buttonsArea.Init();
        m_interface.Init(this);
        InitTools();
    }
    void Start()
    {
        m_interface.SetActive(false);
        Level level = new Level(228);
        DataManager.SaveLevel(level);
    }
    public void StartEditLevel(int levelNumber)
    {

    }
    public void BackToLevels()
    {
        m_isToolActive = false;
        m_buttonsInner.SetActive(true);
        m_interface.SetActive(false);
    }

    void InitTools()
    {
        SetEasyBlockTool();
    }

    public Tool GetCurrentTool()
    {
        return m_tool;
    }

    void PreparePlan()
    {

    }

    public void SetEasyBlockTool()
    {

    }
    public void SetNormalBlockTool()
    {

    }
    public void SetHardBlockTool()
    {

    }
    public void SetImmortalBlockTool()
    {

    }
    public void SetBlockLasticTool()
    {

    }

    public void SetWallTool()
    {

    }
    public void SetFireballTool()
    {

    }
    public void SetMultyballTool()
    {

    }
    public void SetMultiplierTool()
    {

    }
    public void SetGunsTool()
    {

    }
    public void SetLifeTool()
    {

    }
    public void SetBonusLasticTool()
    {

    }

    public void SaveEditLevel()
    {

    }

    public bool IsActive()
    {
        return m_isToolActive;
    }

}