using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPlane : MonoBehaviour
{
    public BlockButton m_instantBlock;
    List<BlockButton> m_blocks;
    RectTransform m_transform;

    int m_blocksCount;
    int m_collsCount;

    const float BLOCK_RELATIVE_WIDTH = 0.9f;

    void Awake()
    {
        m_blocks = new List<BlockButton>();
        m_transform = GetComponent<RectTransform>();
    }
    public void Init(IEditorTool editorTool, IToolColors toolColors, string[] blocksCode)
    {
        m_collsCount = FileParser.collsCount;
        m_blocksCount = m_collsCount * FileParser.rowsCount;
        SpawnBlocks(editorTool, toolColors, blocksCode);
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

    void SpawnBlocks(IEditorTool editorTool, IToolColors toolColors, string[] blocksCode)
    {
        ClearBlocks();

        Vector2 areaSize = m_transform.rect.size;
        int rowsCount = m_blocksCount / m_collsCount;

        float blockWidth = areaSize.x / m_collsCount * BLOCK_RELATIVE_WIDTH;
        float offsetX = areaSize.x - (blockWidth * m_collsCount);
        float oneOffset = offsetX / (m_collsCount + 1);
        float offsetY = (oneOffset * (rowsCount + 1));
        float blockHeight = (areaSize.y - offsetY) / rowsCount;
        Vector2 blockSize = new Vector2(blockWidth, blockHeight);

        Vector3 posOffset = new Vector3(oneOffset, -oneOffset, 0);

        for (int i = 0; i < m_blocksCount; i++)
        {
            char blockKey = blocksCode[i][0];
            char bonusKey = blocksCode[i][1];

            BlockButton newBlock = Instantiate(m_instantBlock);
            m_blocks.Add(newBlock);
            newBlock.Init(editorTool, toolColors, blockSize, blockKey, bonusKey);
            newBlock.transform.SetParent(transform);
            newBlock.transform.localPosition = posOffset;
            posOffset.x += (oneOffset + blockSize.x);

            bool isNewRow = (i + 1) % m_collsCount == 0;
            if (isNewRow)
            {
                posOffset = new Vector3(oneOffset, posOffset.y - (oneOffset + blockSize.y), 0);
            }
        }
    }
    void ClearBlocks()
    {
        foreach (BlockButton block in m_blocks)
        {
            Destroy(block.gameObject);
        }

        m_blocks.Clear();
    }

    public string[] GetRowsCode()
    {
        string[] rowsCode = new string[FileParser.rowsCount];
        string row = "";
        int rowNum = 0;
        int collNum = 0;

        for (int i = 0; i < m_blocks.Count; i++)
        {
            row += m_blocks[i].GetCode();
            if (collNum != FileParser.collsCount - 1)
            {
                row += FileParser.blockSeparator;
            }
            collNum++;


            if (collNum == FileParser.collsCount)
            {
                rowsCode[rowNum] = row;
                row = "";
                collNum = 0;
                rowNum++;
            }
        }

        return rowsCode;
    }
}
