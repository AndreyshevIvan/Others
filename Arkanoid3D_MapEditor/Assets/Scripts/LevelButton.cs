using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    Text m_textArea;
    RectTransform m_transform;
    EditorController m_controller;
    int m_number = 0;

    const string NAME_PATTERN = "Button_";

    void Awake()
    {
        m_textArea = GetComponentInChildren<Text>();
        m_transform = GetComponent<RectTransform>();
    }

    void Start()
    {

    }

    public void Init(EditorController editController, float size, int number)
    {
        m_number = number;
        m_controller = editController;
        m_textArea.text = m_number.ToString();
        name = NAME_PATTERN + m_number.ToString();

        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
    }

    public void StartEditLevel()
    {
        m_controller.SetLevelToEdit(m_number);
    }
}
