using UnityEngine;
using UnityEngine.Rendering;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private bool dynamicSorting;

    private int _defaltOrderInLayer;

    private SpriteRenderer _sortTargetRenderer;
    private SortingGroup _sortTargetGroup;
    private void Start()
    {
        _sortTargetGroup = GetComponent<SortingGroup>();
        _sortTargetRenderer = GetComponent<SpriteRenderer>();

        if( _sortTargetRenderer != null)
        {
            _defaltOrderInLayer = _sortTargetRenderer.sortingOrder;
        }
        if( _sortTargetGroup != null )
        {
            _defaltOrderInLayer = _sortTargetGroup.sortingOrder;

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
        if (_sortTargetRenderer != null)
        {
            _sortTargetRenderer.sortingOrder = _defaltOrderInLayer - Mathf.RoundToInt( transform.root.position.z*50);
        }
        if (_sortTargetGroup != null)
        {
            _sortTargetGroup.sortingOrder = _defaltOrderInLayer - Mathf.RoundToInt(transform.root.position.z * 50);
        }
    }
}
