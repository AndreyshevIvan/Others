using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArea : MonoBehaviour
{
    EditorController m_editor;

    public Button m_easyBlock;
    public Button m_normalBlock;
    public Button m_hardBlock;
    public Button m_immortalBlock;
    public Button m_lastic;

    public Color m_easyColor;
    public Color m_normalColor;
    public Color m_hardColor;
    public Color m_immortalColor;
    public Color m_lasticColor;

    public Image m_currTool;

    public Color easy
    {
        get
        {
            return m_easyColor;
        }
    }
    public Color normal
    {
        get
        {
            return m_normalColor;
        }
    }
    public Color hard
    {
        get
        {
            return m_hardColor;
        }
    }
    public Color immortal
    {
        get
        {
            return m_immortalColor;
        }
    }
    public Color empty
    {
        get
        {
            return m_lasticColor;
        }
    }

    public void Init(EditorController editor)
    {
        m_editor = editor;
    }

    private void FixedUpdate()
    {

    }

    public void SetActive(bool isActive)
    {
        m_currTool.color = Color.clear;

        m_easyBlock.interactable = isActive;
        m_normalBlock.interactable = isActive;
        m_hardBlock.interactable = isActive;
        m_immortalBlock.interactable = isActive;
        m_lastic.interactable = isActive;
    }
}
