using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArea : MonoBehaviour
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

    }

    public void SetActive(bool isActive)
    {
        foreach (Button button in m_editorButtons)
        {
            button.interactable = isActive;
        }
    }
}
