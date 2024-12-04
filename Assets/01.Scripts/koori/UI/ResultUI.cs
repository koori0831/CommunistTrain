using UnityEngine;
using UnityEngine.EventSystems;

public class ResultUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject _stampPrefab;
    private GameObject _stamp;
    private RectTransform _stampRect;
    private Camera _uiCam;

    private void Awake()
    {
        _uiCam = GetComponentInParent<Canvas>().worldCamera;
        Initialize();
    }

    private void Initialize()
    {
        _stamp = Instantiate(_stampPrefab, transform);
        if (_stamp == null) return;

        _stamp.name = _stampPrefab.name;
        _stampRect = _stamp.GetComponent<RectTransform>();
        _stamp.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_stamp == null) return;

        _stamp.SetActive(true);
        _stampRect.position = (Vector2)_uiCam.ScreenToWorldPoint(eventData.position);
        _stampRect.eulerAngles = new Vector3(0, 0, Random.Range(-360, 360));
    }
}
