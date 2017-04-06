using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    Text m_textArea;
    RectTransform m_transform;

    public delegate void OnEditLevel(int levelNumber);
    public OnEditLevel startEdit;

    int m_levelNumber;

    const string NAME_PATTERN = "Button_";

    void Awake()
    {
        m_textArea = GetComponentInChildren<Text>();
        m_transform = GetComponent<RectTransform>();
    }

    void Start()
    {

    }

    public void Init(float size, int levelNamber)
    {
        string numStr = (levelNamber + 1).ToString();
        m_textArea.text = numStr;
        gameObject.name = NAME_PATTERN + numStr;
        m_levelNumber = levelNamber;

        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
    }

    public void StartEditLevel()
    {
        startEdit(m_levelNumber);
    }
}
