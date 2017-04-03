using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlane : MonoBehaviour
{
    public Block m_block;
    RectTransform m_transform;

    int m_blocksCount;
    int m_collsCount;

    const float BLOCK_RELATIVE_WIDTH = 0.9f;

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
    }
    public void Init(int blocksCount, int collsCount)
    {
        m_blocksCount = blocksCount;
        m_collsCount = collsCount;
        SpawnBlocks();
    } 

    void SpawnBlocks()
    {
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
            Block newBlock = Instantiate(m_block);
            newBlock.Init(blockSize);
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
}
