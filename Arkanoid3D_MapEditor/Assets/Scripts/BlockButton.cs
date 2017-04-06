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
    public void Init(Vector2 size)
    {
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
    }

    private void FixedUpdate()
    {

    }

    public void AddProperty()
    {

    }

    public void SetBlockKey()
    {

    }
    public void SetBonusKey()
    {

    }
}
