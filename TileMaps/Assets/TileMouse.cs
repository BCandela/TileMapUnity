using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMouse : MonoBehaviour
{
    public Color highlightColor;
    private Color normalColor;
    // Start is called before the first frame update
    void Start()
    {
        normalColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
            GetComponent<Renderer>().material.color = highlightColor;
        else
            GetComponent<Renderer>().material.color = normalColor;
    }
}
