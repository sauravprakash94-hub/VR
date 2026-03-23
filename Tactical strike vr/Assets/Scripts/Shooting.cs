using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Shooting : MonoBehaviour
{
    [Header("Gun Settings")]
    public int damage = 50;
    public float range = 200f;

    [Tooltip("Drag your FirePoint empty GameObject here")]
    public Transform firePoint;

    [Header("Zoom / Scope Settings")]
    [Tooltip("FOV when zoomed in (lower = more zoom). Default 15 = sniper zoom")]
    public float zoomedFOV = 15f;

    [Tooltip("Normal FOV to return to after unzoom")]
    public float normalFOV = 60f;

    [Tooltip("How smoothly the zoom transitions")]
    public float zoomSpeed = 8f;

    private XRGrabInteractable grabInteractable;
    private Camera xrCamera;
    private bool isZoomed = false;
    private float targetFOV;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.activated.AddListener(Shoot);
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);

        xrCamera = Camera.main;
        targetFOV = normalFOV;
    }

    private void OnDestroy()
    {
        grabInteractable.activated.RemoveListener(Shoot);
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (xrCamera == null)
            xrCamera = Camera.main;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        ExitZoom();
    }

    private void Update()
    {
        if (xrCamera != null)
        {
            xrCamera.fieldOfView = Mathf.Lerp(
                xrCamera.fieldOfView,
                targetFOV,
                Time.deltaTime * zoomSpeed
            );
        }
    }

    private void Shoot(ActivateEventArgs args)
    {
        Debug.Log("BANG! Trigger pulled.");

        if (firePoint == null)
        {
            Debug.LogWarning("FirePoint not assigned on the gun!");
            return;
        }

        RaycastHit hit;

        Vector3 origin = firePoint.position;
        Vector3 direction = firePoint.forward;

        if (isZoomed && xrCamera != null)
        {
            origin = xrCamera.transform.position;
            direction = xrCamera.transform.forward;
        }

        if (Physics.Raycast(origin, direction, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void ToggleZoom()
    {
        if (isZoomed)
            ExitZoom();
        else
            EnterZoom();
    }

    public void EnterZoom()
    {
        isZoomed = true;
        targetFOV = zoomedFOV;
        Debug.Log("Scope ON");
    }

    public void ExitZoom()
    {
        isZoomed = false;
        targetFOV = normalFOV;
        Debug.Log("Scope OFF");
    }
}
