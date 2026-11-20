using UnityEngine;

public class DraggableBall : MonoBehaviour
{
    private bool isDragging = false;
    private Camera cam;
    private float dragHeight = 0.5f;
    private Rigidbody rb;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isDragging = true;

        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    void Update()
    {
        if (!isDragging) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane dragPlane = new Plane(Vector3.up, new Vector3(0f, dragHeight, 0f));

        if (dragPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            transform.position = new Vector3(hitPoint.x, dragHeight, hitPoint.z);
        }
    }
}