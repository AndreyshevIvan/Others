using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{
    RectTransform m_transform;
    IEditorTool m_editorTool;
    IToolColors m_toolColor;

    char m_blockKey;
    char m_bonusKey;

    public Text m_blockKeyUI;
    public Text m_bonusKeyUI;

    public Image m_blockImg;
    public Image m_bonusImg;

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
        m_blockKeyUI.text = "";
        m_bonusKeyUI.text = "";
    }
    public void Init(IEditorTool editorTool, IToolColors toolColors ,Vector2 size, char blockKey, char bonusKey)
    {
        m_blockKey = blockKey;
        m_bonusKey = bonusKey;
        m_editorTool = editorTool;
        m_toolColor = toolColors;

        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
    }

    private void FixedUpdate()
    {
        m_blockKeyUI.text = (m_blockKey == FileParser.emptyKey) ? "" : m_blockKey.ToString();
        m_bonusKeyUI.text = (m_bonusKey == FileParser.emptyKey) ? "" : m_bonusKey.ToString();

        m_blockImg.color = m_toolColor.GetBlockColor(m_blockKey);
        m_bonusImg.color = m_toolColor.GetBonusColor(m_bonusKey);
    }

    public void AddProperty()
    {
        char key = m_editorTool.GetCurrentTool().key;

        if (m_editorTool.GetCurrentTool().type == ToolType.BLOCK)
        {
            SetBlockKey(key);
        }
        else if (m_editorTool.GetCurrentTool().type == ToolType.BONUS)
        {
            SetBonusKey(key);
        }
    }

    public void SetBlockKey(char key)
    {
        m_blockKey = key;

        if (m_blockKey == FileParser.emptyKey)
        {
            SetBonusKey(FileParser.emptyKey);
        }
    }
    public void SetBonusKey(char key)
    {
        m_bonusKey = key;
    }

    public string GetCode()
    {
        string code = m_blockKey.ToString() + m_bonusKey.ToString();

        return code;
    }
}
