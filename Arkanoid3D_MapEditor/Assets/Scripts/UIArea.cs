using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArea : MonoBehaviour, IToolColors
{
    EditorController m_editor;

    public Button[] m_editorButtons;

    public Color m_easyColor;
    public Color m_normalColor;
    public Color m_hardColor;
    public Color m_immortalColor;

    public Color m_emptyColor;

    public Image m_currTool;

    public void Init(EditorController editor)
    {
        m_editor = editor;
    }

    private void FixedUpdate()
    {

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
}
