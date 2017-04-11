using UnityEngine;
using System.Collections;

public class MaterialRenderQuene : MonoBehaviour
{
    public int RenderQuene = 3000;

    void OnEnable()
    {
        RebuildMaterial(transform);
    }


    void RebuildMaterial(Transform root)
    {
        Renderer[] rootRenderers = root.gameObject.GetComponents<Renderer>() as Renderer[];
        foreach (Renderer renderer in rootRenderers)
        {
            ResetRenderQuene(renderer.material);
        }
        Transform[] trans = root.GetComponentsInChildren<Transform>(true) as Transform[];
        foreach (Transform child in trans)
        {
            if (child.GetComponent<MaterialRenderQuene>() == null && child != root)
            {
                Renderer[] renderers = child.gameObject.GetComponents<Renderer>() as Renderer[];
                foreach (Renderer renderer in renderers)
                {
                    ResetRenderQuene(renderer.material);
                }
                RebuildMaterial(child);
            }
        }
    }

    void ResetRenderQuene(Material mat)
    {
        mat.renderQueue = RenderQuene;
    }

}
