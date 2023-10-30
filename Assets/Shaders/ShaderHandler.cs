using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode] //So it appears in the editor
public class ShaderHandler : MonoBehaviour
{
    public Material effectMat;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMat);
    }
}
