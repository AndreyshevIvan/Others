using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArea : MonoBehaviour
{
    Tool m_editorTool;

    public Button[] m_editButtons;

    public GameObject m_blocksPanel;
    public GameObject m_bonusesPanel;

    public Color m_easyColor;
    public Color m_normalColor;
    public Color m_hardColor;
    public Color m_immortalColor;

    public Color m_emptyColor;

    public Text m_currToolName;
    public Image m_currTool;

    public void Init(Tool tool)
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
}
