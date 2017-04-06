using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlockButtonMode
{
    NONE,
    BLOCK,
    BONUS,
}

public class BlockButton : MonoBehaviour
{
    RectTransform m_transform;

    BlockType m_blockType;
    BonusType m_bonusType;

    public Text m_key;
    public Image m_backgorund;

    BlockButtonMode m_mode;

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
        m_key.text = "";
    }
    public void Init(BlockType blockType, BonusType bonusType)
    {
        m_blockType = blockType;
        m_bonusType = bonusType;
    }
    public void SetTransformProperty(Vector2 size, Vector2 position, Transform parent)
    {
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);

        transform.SetParent(parent);
        transform.localPosition = position;
    }

    private void FixedUpdate()
    {

    }

    public void TurnOffModes()
    {
        m_mode = BlockButtonMode.NONE;
    }
    public void SetBlockMode()
    {
        TurnOffModes();
        m_mode = BlockButtonMode.BLOCK;
    }
    public void SetBonusMode()
    {
        TurnOffModes();
        m_mode = BlockButtonMode.BONUS;
    }
}
