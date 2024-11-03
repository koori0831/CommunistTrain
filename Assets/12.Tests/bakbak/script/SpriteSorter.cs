using UnityEngine;
using UnityEngine.Rendering;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private bool dynamicSorting;

    private int defaltOrderInLayer;

    private SpriteRenderer sortTargetRenderer;
    private SortingGroup sortTargetGroup;
    private void Start()
    {
        sortTargetGroup = GetComponent<SortingGroup>();
        sortTargetRenderer = GetComponent<SpriteRenderer>();

        if( sortTargetRenderer != null)
        {
            defaltOrderInLayer = sortTargetRenderer.sortingOrder;
        }
        if( sortTargetGroup != null )
        {
            defaltOrderInLayer = sortTargetGroup.sortingOrder;

        }
        SetLayer();
    }

    private void Update()
    {
        if( dynamicSorting)
        {
            SetLayer();
        }
    }

    private void SetLayer()
    {
        if (sortTargetRenderer != null)
        {
            sortTargetRenderer.sortingOrder = defaltOrderInLayer - Mathf.RoundToInt( transform.root.position.z*50);
        }
        if (sortTargetGroup != null)
        {
            sortTargetGroup.sortingOrder = defaltOrderInLayer - Mathf.RoundToInt(transform.root.position.z * 50);
        }
    }
}
