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
    public Tool(ToolType type, string name = "")
    {
        this.type = type;
        this.name = name;
        active = false;
    }

    public bool active;
    public ToolType type;
    public string name;
}

public class EditorController : MonoBehaviour
{
    public GameObject m_buttonsInner;
    public ButtonsArea m_buttonsArea;
    public MapPlane m_mapPlane;
    public UIArea m_interface;

    Level m_editLevel;
    Tool m_tool;

    int m_editLevelNumber;
    bool m_isToolActive = false;

    const int LEVELS_COUNT = 50;

    void Awake()
    {
        m_buttonsArea.Init(LEVELS_COUNT);
        m_interface.Init(m_tool);
        m_buttonsArea.startEdit += StartEditLevel;

        ResetAllLevels();
    }
    void Start()
    {
        m_interface.SetLevelsMode();
    }
    public void StartEditLevel(int levelNumber)
    {
        m_editLevel = DataManager.LoadLevel(levelNumber);
        m_mapPlane.Init(m_editLevel);
        m_interface.SetBlockMode();
        m_buttonsInner.SetActive(false);
    }
    public void BackToLevels()
    {
        m_isToolActive = false;
        m_interface.SetLevelsMode();
        m_buttonsInner.SetActive(true);
    }
    void ResetAllLevels()
    {
        for (int i = 0; i < LEVELS_COUNT; i++)
        {
            Level emptyLevel = new Level(i);
            DataManager.SaveLevel(emptyLevel);
        }
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
        m_tool = new Tool();
    }
    public void SetNormalBlockTool()
    {
        m_tool = new Tool();
    }
    public void SetHardBlockTool()
    {
        m_tool = new Tool();
    }
    public void SetImmortalBlockTool()
    {
        m_tool = new Tool();
    }
    public void SetBlockLasticTool()
    {
        m_tool = new Tool();
    }

    public void SetWallTool()
    {
        m_tool = new Tool();
    }
    public void SetFireballTool()
    {
        m_tool = new Tool();
    }
    public void SetMultyballTool()
    {
        m_tool = new Tool();
    }
    public void SetMultiplierTool()
    {
        m_tool = new Tool();
    }
    public void SetGunsTool()
    {
        m_tool = new Tool();
    }
    public void SetLifeTool()
    {
        m_tool = new Tool();
    }
    public void SetBonusLasticTool()
    {
        m_tool = new Tool();
    }

    public void SaveEditLevel()
    {

    }

    public bool IsActive()
    {
        return m_isToolActive;
    }

}