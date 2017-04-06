using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsArea : MonoBehaviour
{
    public LevelButton m_button;

    public delegate void OnStartEdit(int levelNumber);
    public OnStartEdit startEdit;

    Vector2 m_startPos;
    Vector2 m_size;
    RectTransform m_transform;

    int m_levelsCount = 0;

    const int BUTTONS_IN_ROW = 6;
    const float BUTTON_RELATIVE_WIDTH = 0.85f;

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
    }

    public void Init(int levelsCount)
    {
        m_levelsCount = levelsCount;
        SpawnButtons();
    }

    void SpawnButtons()
    {
        Vector2 areaSize = m_transform.rect.size;
        int rowsCount = m_levelsCount / BUTTONS_IN_ROW;
        rowsCount = (m_levelsCount % BUTTONS_IN_ROW == 0) ? rowsCount : rowsCount + 1;

        float buttonWidth = areaSize.x / BUTTONS_IN_ROW * BUTTON_RELATIVE_WIDTH;
        float offsetX = areaSize.x - (buttonWidth * BUTTONS_IN_ROW);
        float oneOffset = offsetX / (BUTTONS_IN_ROW + 1);
        float areaHeight = (rowsCount * buttonWidth) + (rowsCount + 1) * oneOffset;
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, areaHeight);

        Vector3 posOffset = new Vector3(oneOffset, -oneOffset, 0);

        for (int buttonNum = 0; buttonNum < m_levelsCount; buttonNum++)
        {
            LevelButton button = Instantiate(m_button);
            button.Init(buttonWidth, buttonNum);
            button.startEdit += StartEditLevel;
            button.transform.SetParent(transform);
            button.transform.localPosition = posOffset;
            posOffset.x += (oneOffset + buttonWidth);

            bool isNewRow = (buttonNum + 1) % BUTTONS_IN_ROW == 0;
            if (isNewRow)
            {
                posOffset = new Vector3(oneOffset, posOffset.y - (oneOffset + buttonWidth), 0);
            }
        }
    }

    void StartEditLevel(int levelNumber)
    {
        startEdit(levelNumber);
    }
}
