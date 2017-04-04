using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArea : MonoBehaviour, IToolColors
{
    IEditorTool m_editorTool;

    public Button[] m_editorButtons;

    public Color m_easyColor;
    public Color m_normalColor;
    public Color m_hardColor;
    public Color m_immortalColor;

    public Color m_emptyColor;

    public Text m_currToolName;
    public Image m_currTool;

    public void Init(IEditorTool editor)
    {
        m_editorTool = editor;
    }

    private void FixedUpdate()
    {
        UpdateCurrentTool();
    }
    void UpdateCurrentTool()
    {
        if (m_editorTool.IsActive())
        {
            Tool currTool = m_editorTool.GetCurrentTool();

            if (currTool.type == ToolType.BLOCK)
            {
                m_currToolName.text = "Block " + GetBlockName(currTool.key);
            }
            else if (currTool.type == ToolType.BONUS)
            {
                m_currToolName.text = "Bonus " + GetBonusName(currTool.key);
            }
        }
        else
        {
            m_currToolName.text = "";
        }
    }

    public void SetActive(bool isActive)
    {
        foreach (Button button in m_editorButtons)
        {
            button.interactable = isActive;
        }
    }

    public Color GetBlockColor(char blockKey)
    {
        Color color = m_emptyColor;

        if (blockKey == FileParser.easyKey)
        {
            color = m_easyColor;
        }
        else if (blockKey == FileParser.normalKey)
        {
            color = m_normalColor;
        }
        else if (blockKey == FileParser.hardKey)
        {
            color = m_hardColor;
        }
        else if (blockKey == FileParser.immortalKey)
        {
            color = m_immortalColor;
        }

        return color;
    }
    public Color GetBonusColor(char bonusKey)
    {
        Color color = m_emptyColor;

        if (bonusKey == FileParser.wallKey)
        {
            color = m_emptyColor;
        }
        else if (bonusKey == FileParser.lifeKey)
        {
            color = m_emptyColor;
        }
        else if (bonusKey == FileParser.multiplierKey)
        {
            color = m_emptyColor;
        }
        else if (bonusKey == FileParser.multiplierKey)
        {
            color = m_emptyColor;
        }
        else if (bonusKey == FileParser.gunsKey)
        {
            color = m_emptyColor;
        }
        else if (bonusKey == FileParser.fireballKey)
        {
            color = m_emptyColor;
        }

        return color;
    }

    public string GetBlockName(char blockKey)
    {
        string name = "";

        if (blockKey == FileParser.easyKey)
        {
            name = "Easy";
        }
        else if (blockKey == FileParser.normalKey)
        {
            name = "Normal";
        }
        else if (blockKey == FileParser.hardKey)
        {
            name = "Hard";
        }
        else if (blockKey == FileParser.immortalKey)
        {
            name = "Immortal";
        }
        else if (blockKey == FileParser.emptyKey)
        {
            name = "lastic";
        }

        return name;
    }
    public string GetBonusName(char bonusKey)
    {
        string name = "";

        if (bonusKey == FileParser.wallKey)
        {
            name = "wall";
        }
        else if (bonusKey == FileParser.lifeKey)
        {
            name = "life";
        }
        else if (bonusKey == FileParser.multiplierKey)
        {
            name = "points multiplier";
        }
        else if (bonusKey == FileParser.multiballKey)
        {
            name = "multiball";
        }
        else if (bonusKey == FileParser.gunsKey)
        {
            name = "guns";
        }
        else if (bonusKey == FileParser.fireballKey)
        {
            name = "fireball";
        }
        else if (bonusKey == FileParser.emptyKey)
        {
            name = "lastic";
        }

        return name;
    }
}
