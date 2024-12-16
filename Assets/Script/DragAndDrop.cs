using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndZoom : MonoBehaviour, IDragHandler
{
    public float zoomSpeed = 1.0f;
    public float zoomAcceleration = 1.0f;
    private Vector3 offset;
    private float zDistance;
    private bool isDragging = false;

    public float wallBufferDistance = 0.1f; // Minimum distance to keep from walls
    public float zoomCheckRadius = 0.5f;   // Radius for sphere casting during zoom

    public Material outlineMaterial; // Assign this in the Inspector
    private Material[] originalMaterials; // Store the original materials

    private Renderer objectRenderer;
    [SerializeField] private TMP_Text SelectedItem;
    public GameObject CountdownPanel;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        if (!CountdownPanel.activeSelf)
        {
            objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                originalMaterials = objectRenderer.materials;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!CountdownPanel.activeSelf)
        {
            zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            isDragging = true;

            // Apply outline
            ApplyOutline();

            SelectedItem.text = "Selected Item: " + gameObject.name;
            audioManager.PlayClickSound(audioManager.ClickSource);
        }
        
    }

    private void OnMouseDrag()
    {
        if (!CountdownPanel.activeSelf)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

            // Use collision-safe movement
            Vector3 constrainedPosition = GetConstrainedPosition(transform.position, newPosition);
            transform.position = constrainedPosition;
        }
    }

    private void OnMouseUp()
    {
        if (!CountdownPanel.activeSelf)
        {
            isDragging = false;

            // Remove outline
            RemoveOutline();
            SelectedItem.text = "Selected Item: None";
        }
    }

    private void Update()
    {
        if (!CountdownPanel.activeSelf)
        {
                if (isDragging)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                if (scroll != 0)
                {
                    float newZDistance = zDistance + scroll * zoomSpeed * zoomAcceleration;
                    newZDistance = Mathf.Clamp(newZDistance, 10f, 50f);

                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, newZDistance);
                    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;

                    // Check for walls along the zoom path
                    if (!IsZoomBlockedByWall(transform.position, targetPosition))
                    {
                        zDistance = newZDistance; // Update zoom level only if no wall is hit
                        transform.position = targetPosition;
                    }
                }
            }
        }
    }

    private Vector3 GetConstrainedPosition(Vector3 currentPosition, Vector3 targetPosition)
    {
        if (!CountdownPanel.activeSelf)
        {
            Vector3 direction = targetPosition - currentPosition;
            float distance = direction.magnitude;

            if (Physics.Raycast(currentPosition, direction.normalized, out RaycastHit hit, distance + wallBufferDistance))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    return hit.point - direction.normalized * wallBufferDistance;
                }
            }
            return targetPosition;
        }

        return currentPosition;
        
        
    }

    private bool IsZoomBlockedByWall(Vector3 currentPosition, Vector3 targetPosition)
    {
        if (!CountdownPanel.activeSelf){
            Vector3 direction = targetPosition - currentPosition;
            float distance = direction.magnitude;

            if (Physics.SphereCast(currentPosition, zoomCheckRadius, direction, out RaycastHit hit, distance))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    private void ApplyOutline()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterials = renderer.materials;
            renderer.material = outlineMaterial; // Replace material with outline
        }
    }

    private void RemoveOutline()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null && originalMaterials != null)
        {
            renderer.materials = originalMaterials; // Restore original materials
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // This method is here to comply with the IDragHandler interface,
        // but it's not needed for 3D object dragging in this script.
    }
}
