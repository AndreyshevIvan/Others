using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    RectTransform m_transform;

    void Awake()
    {
        m_transform = GetComponent<RectTransform>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void Init(Vector2 size)
    {
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        m_transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
    }
}
