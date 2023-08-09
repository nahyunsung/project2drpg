using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderScript : MonoBehaviour
{
    public Color Frontcolor = Color.red;
    public Color Uptcolor = Color.yellow;

    [Range(0, 16)]
    public int outlineSize = 1;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //UpdateOutline(true);
    }

    public void OutlineFrontTrue()
    {
        UpdateOutline(true, Frontcolor);
    }
    public void OutlineUpTrue()
    {
        UpdateOutline(true, Uptcolor);
    }

    public void OutlineFalse()
    {
        UpdateOutline(false, Color.white);
    }

    void UpdateOutline(bool outline, Color outColor)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 16f : 0);
        mpb.SetColor("_OutlineColor", outColor);
        mpb.SetFloat("_OutlineSize", outlineSize);
        spriteRenderer.SetPropertyBlock(mpb);
    }
}
