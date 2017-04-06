using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{
    public Image m_backgorund;

    RectTransform m_transform;
    Tool m_editorTool;

    EditorMode m_mode = EditorMode.NONE;
    BlockType m_blockType;
    BonusType m_bonusType;

    Color m_blockColor;
    Color m_bonusColor;

    public BlockType block
    {
        get { return m_blockType; }
    }
    public BonusType bonus
    {
        get { return m_bonusType; }
    }

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
    }
    public void InitTool(ref Tool editorTool)
    {
        m_editorTool = editorTool;
    }
    public void InitItems(BlockType blockType, BonusType bonusType)
    {
        m_blockType = blockType;
        m_bonusType = bonusType;
    }
    public void InitTransformProperty(Vector2 size, Vector2 position, Transform parent)
    {
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);

        transform.SetParent(parent);
        transform.localPosition = position;
    }

    private void FixedUpdate()
    {
        UpdateColor();

        if (block == BlockType.NONE)
        {
            m_bonusType = BonusType.NONE;
        }
    }
    void UpdateColor()
    {
        Color color = EditorUI.emptyColor;

        switch(m_mode)
        {
            case (EditorMode.BLOCK):
                color = EditorUI.GetBlockModeColor(m_blockType);
                break;
            case (EditorMode.BONUS):
                color = EditorUI.GetBonusModeColor(m_bonusType);
                break;
        }

        m_backgorund.color = color;
    }

    public void AddProperty()
    {
        if (m_editorTool.mode == EditorMode.BLOCK)
        {
            BlockType toolBlockType = m_editorTool.blockType;
            SetBlockType(toolBlockType);
        }
        else if (block != BlockType.NONE)
        {
            if (m_editorTool.mode == EditorMode.BONUS)
            {
                BonusType toolBonusType = m_editorTool.bonusType;
                SetBonusType(toolBonusType);
            }
        }
    }

    void SetBlockType(BlockType type)
    {
        m_blockType = type;
    }
    void SetBonusType(BonusType type)
    {
        m_bonusType = type;
    }

    public void TurnOffModes()
    {
        m_mode = EditorMode.NONE;
    }
    public void SetBlockMode()
    {
        TurnOffModes();
        m_mode = EditorMode.BLOCK;
    }
    public void SetBonusMode()
    {
        TurnOffModes();
        m_mode = EditorMode.BONUS;
    }
}
