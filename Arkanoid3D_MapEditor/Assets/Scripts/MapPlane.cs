using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPlane : MonoBehaviour
{
    public BlockButton m_instantBlock;
    List<BlockButton> m_buttons;
    RectTransform m_transform;
    IGameLevel m_level;

    int m_rowsCount;
    int m_collsCount;
    int m_blocksCount;
    Vector2 m_areaSize;
    Vector2 m_offset;
    Vector2 m_buttonSize;

    const float BLOCK_RELATIVE_WIDTH = 0.9f;

    void Awake()
    {
        m_buttons = new List<BlockButton>();
        m_transform = GetComponent<RectTransform>();

        m_rowsCount = Level.rowsCount;
        m_collsCount = Level.collsCount;
        m_blocksCount = Level.blocksCount;

        m_areaSize = m_transform.rect.size;

        float blockWidth = m_areaSize.x / m_collsCount * BLOCK_RELATIVE_WIDTH;
        float offsetX = m_areaSize.x - (blockWidth * m_collsCount);
        float oneOffset = offsetX / (m_collsCount + 1);
        float offsetY = (oneOffset * (m_rowsCount + 1));
        float blockHeight = (m_areaSize.y - offsetY) / m_rowsCount;

        m_offset = new Vector2(offsetX, offsetY);
        m_buttonSize = new Vector2(blockWidth, blockHeight);
    }
    public void Init(IGameLevel level, ref Tool editorTool)
    {
        m_level = level;

        SpawnBlocks(ref editorTool);
    }

    public void SetBlockMode()
    {
        foreach (BlockButton button in m_buttons)
        {
            button.SetBlockMode();
        }
    }
    public void SetBonusMode()
    {
        foreach (BlockButton button in m_buttons)
        {
            button.SetBonusMode();
        }
    }

    public List<BlockType> GetBlocksMap()
    {
        List<BlockType> blocksMap = new List<BlockType>();

        foreach (BlockButton button in m_buttons)
        {
            blocksMap.Add(button.block);
        }

        return blocksMap;
    }
    public List<BonusType> GetBonusMap()
    {
        List<BonusType> bonusMap = new List<BonusType>();

        foreach (BlockButton button in m_buttons)
        {
            bonusMap.Add(button.bonus);
        }

        return bonusMap;
    }

    void FixedUpdate()
    {
        HandleTouch();
    }
    void HandleTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    void SpawnBlocks(ref Tool editorTool)
    {
        ClearBlocks();

        float oneOffset = m_offset.x / (m_collsCount + 1);
        Vector3 posOffset = new Vector3(oneOffset, -oneOffset, 0);

        List<BlockType> blocksMap = m_level.GetBlocksMap();
        List<BonusType> bonusMap = m_level.GetBonusesMap();

        for (int buttonNum = 0; buttonNum < m_blocksCount; buttonNum++)
        {
            BlockButton button = Instantiate(m_instantBlock);
            button.InitTool(ref editorTool);
            button.InitItems(blocksMap[buttonNum], bonusMap[buttonNum]);
            button.InitTransformProperty(m_buttonSize, posOffset, transform);
            m_buttons.Add(button);

            posOffset.x += (oneOffset + m_buttonSize.x);
            bool isNewRow = (buttonNum + 1) % m_collsCount == 0;

            if (isNewRow)
            {
                posOffset = new Vector3(oneOffset, posOffset.y - (oneOffset + m_buttonSize.y), 0);
            }
        }
    }
    void ClearBlocks()
    {
        foreach (BlockButton block in m_buttons)
        {
            Destroy(block.gameObject);
        }

        m_buttons.Clear();
    }
}
