using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    private float radius = 6f;
    private int segments = 36;
    private Color color = Color.green;
    private float lineWidth = 0.1f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color")) { color = color };

        UpdateCircle();
    }

    private void UpdateCircle()
    {
        lineRenderer.positionCount = segments + 1;

        Vector3[] points = new Vector3[segments + 1];
        float angleStep = 360f / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = angleStep * i;
            points[i] = new Vector3(
                radius * Mathf.Cos(angle * Mathf.Deg2Rad),
                0,
                radius * Mathf.Sin(angle * Mathf.Deg2Rad)
            );
        }

        lineRenderer.SetPositions(points);
    }
    }