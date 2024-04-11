using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResourceBar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform cam;

    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void ChangeXScale(float value, float maxValue)
    {
        float ratio = value / maxValue;
        Vector3 currentScale = spriteRenderer.gameObject.transform.localScale;
        currentScale.x = ratio;
        spriteRenderer.gameObject.transform.localScale = currentScale;
    }
}
