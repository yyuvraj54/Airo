using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(LineRenderer))]
public class AimController : MonoBehaviour
{

    
    public TMP_Text hoverTextInstance; // Instance of the TextMeshPro text component

    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;
    GameObject lastHitObject; // Store the last object hit by the laser
    

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()

    {
            RaycastCollider();          
    }

    void RaycastCollider()
    {
        fireTimer += Time.deltaTime;
        fireTimer = 0;
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            // Apply hover effect
            string tag = hit.collider.gameObject.tag;
            ApplyHoverEffect(hit.collider.gameObject.name, tag);
            lastHitObject = hit.collider.gameObject;
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            // Remove hover effect if the object is not hit by the laser
            if (lastHitObject != null)
            {
                RemoveHoverEffect();
                lastHitObject = null;
            }
        }
        StartCoroutine(ShootLaser());
    }

    void ApplyHoverEffect(string objectName, string tag)
    {
        
        hoverTextInstance.text = tag;
        hoverTextInstance.gameObject.SetActive(true);
        Onclicked(tag);
        
    }

    void RemoveHoverEffect()
    {
        if (hoverTextInstance != null)
        {
            hoverTextInstance.gameObject.SetActive(false);
        }

    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }


    void Onclicked(string tag) {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            // Check if the touch phase is began or moved
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Single touch detected at position: " + touch.position);
                switch (tag)
                {
                    case "Click To Start":
                        // Open Gallery window
                        Debug.Log("Click TO Start Trigger...");
                        break;
                    case "Calculator":
                        // Open Calculator window
                        Debug.Log("Opening Calculator");
                        break;
                    case "Weather":
                        // Open Weather app
                        Debug.Log("Opening Weather app");
                        break;
                    // Add more cases for other icons
                    default:
                        // No action for other tags
                        Debug.Log("No action defined for tag: " + tag);
                        break;
                }

            }
        }
    }

    void ShowHoverText(Vector3 objectPosition,string appName)
    {
        // If hover text instance doesn't exist, create it
        if (hoverTextInstance == null)
        {
            //hoverTextInstance = Instantiate(hoverTextPrefab, transform);
        }

        // Set position of hover text just below the object
        hoverTextInstance.transform.position = objectPosition + Vector3.down * 0.5f; // Adjust as needed
        hoverTextInstance.text = appName; // Set the text content
        hoverTextInstance.gameObject.SetActive(true);
    }
}


