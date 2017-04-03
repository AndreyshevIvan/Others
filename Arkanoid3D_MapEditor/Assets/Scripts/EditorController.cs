using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tool
{
    public Tool(char key, Color color)
    {
        m_key = key;
        m_color = color;
    }

    char m_key;
    Color m_color;

    public char key
    {
        get
        {
            return m_key;
        }
    }

    public Color color
    {
        get
        {
            return m_color;
        }
    }
}

public class EditorController : MonoBehaviour
{
    public GameObject m_buttonsInner;
    public ButtonsArea m_buttonsArea;
    public MapPlane m_mapPlane;
    public UIArea m_interface;
    FileParser m_parser;

    Tool m_currTool;
    Tool m_easyBlock;
    Tool m_normalBlock;
    Tool m_hardBlock;
    Tool m_immortalBlock;
    Tool m_lastic;

    string[] m_level;

    const int LEVELS_COUNT = 50;

    public int levelsCount
    {
        get
        {
            return LEVELS_COUNT;
        }
    }
    public Tool tool
    {
        get
        {
            return m_currTool;
        }
    }

    void Awake()
    {
        m_buttonsArea.Init(this);
        m_interface.Init(this);
    }
    void Start()
    {

    }

    void InitTools()
    {
        m_easyBlock = new Tool(m_parser.easy, m_interface.easy);
        m_normalBlock = new Tool(m_parser.easy, m_interface.normal);
        m_hardBlock = new Tool(m_parser.easy, m_interface.hard);
        m_immortalBlock = new Tool(m_parser.easy, m_interface.immortal);
        m_lastic = new Tool(m_parser.empty, m_interface.empty);
    }

    public void SetLevelToEdit(int levelNumber)
    {
        m_buttonsInner.SetActive(false);
        m_parser = new FileParser(levelNumber);
        m_mapPlane.Init(m_parser.blocksCount, m_parser.collsCount);
        m_level = m_parser.level;
        m_parser.EditLevel(m_level);
        InitTools();
    }
    public void SetEasyTool()
    {
        m_currTool = m_easyBlock;
    }
    public void SetNormalTool()
    {
        m_currTool = m_normalBlock;
    }
    public void SetHardTool()
    {
        m_currTool = m_hardBlock;
    }
    public void SetImmortalTool()
    {
        m_currTool = m_immortalBlock;
    }
    public void SetLasticTool()
    {
        m_currTool = m_lastic;
    }
}