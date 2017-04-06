using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMyColor
{
    public CMyColor(float r, float g, float b, float a = 255)
    {
        m_red = r;
        m_green = g;
        m_blue = b;
        m_alpha = a;
    }

    float m_red;
    float m_green;
    float m_blue;
    float m_alpha;

    public Color Get()
    {
        return new Color(m_red / 255, m_green / 255, m_blue / 255, m_alpha / 255);
    }
}

public class EditorUI : MonoBehaviour
{
    Tool m_editorTool;

    public Button[] m_editButtons;

    public GameObject m_blocksPanel;
    public GameObject m_bonusesPanel;

    public static CMyColor easyColor = new CMyColor(35, 170, 60);
    public static CMyColor normalColor = new CMyColor(40, 80, 190);
    public static CMyColor hardColor = new CMyColor(190, 40, 40);
    public static CMyColor immortalColor = new CMyColor(145, 20, 165);

    public static CMyColor wallColor = new CMyColor(42, 240, 100);
    public static CMyColor fireballColor = new CMyColor(200, 110, 12);
    public static CMyColor multiballColor = new CMyColor(170, 110, 250);
    public static CMyColor multiplierColor = new CMyColor(230, 210, 50);
    public static CMyColor gunsColor = new CMyColor(40, 20, 180);
    public static CMyColor lifeColor = new CMyColor(215, 30, 50);

    public static Color emptyColor = Color.clear;

    public Text m_currToolName;
    public Image m_currTool;

    public void Init(ref Tool tool)
    {
        m_editorTool = tool;
    }

    private void FixedUpdate()
    {
        UpdateCurrentTool();
    }
    void UpdateCurrentTool()
    {
        m_currToolName.text = (m_editorTool.active) ? m_editorTool.name : "";
    }

    public void ActivateCommonButtons(bool isActive)
    {
        foreach (Button button in m_editButtons)
        {
            button.interactable = isActive;
        }
    }
    public void SetLevelsMode()
    {
        ActivateCommonButtons(false);

        m_blocksPanel.SetActive(false);
        m_bonusesPanel.SetActive(false);
    }
    public void SetBlockMode()
    {
        SetLevelsMode();
        ActivateCommonButtons(true);
        m_blocksPanel.SetActive(true);
    }
    public void SetBonusMode()
    {
        SetLevelsMode();
        ActivateCommonButtons(true);
        m_bonusesPanel.SetActive(true);
    }

    public static Color GetBlockModeColor(BlockType type)
    {
        switch (type)
        {
            case (BlockType.EASY):
                return easyColor.Get();

            case (BlockType.NORMAL):
                return normalColor.Get();

            case (BlockType.HARD):
                return hardColor.Get();

            case (BlockType.IMMORTAL):
                return immortalColor.Get();
        }

        return emptyColor;
    }
    public static Color GetBonusModeColor(BonusType type)
    {
        switch (type)
        {
            case (BonusType.LIFE):
                return lifeColor.Get();

            case (BonusType.WALL):
                return wallColor.Get();

            case (BonusType.FIRE_BALL):
                return fireballColor.Get();

            case (BonusType.MULIBALL):
                return multiballColor.Get();

            case (BonusType.MULTIPLIER):
                return multiplierColor.Get();

            case (BonusType.GUNS):
                return gunsColor.Get();
        }

        return emptyColor;
    }
}
