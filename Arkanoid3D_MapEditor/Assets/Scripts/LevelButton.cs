using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    Text m_textArea;
    RectTransform m_transform;

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
        m_textArea.text = levelNamber.ToString();

        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
    }

    public void StartEditLevel()
    {

    }
}
