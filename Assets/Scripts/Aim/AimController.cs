using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


[RequireComponent(typeof(LineRenderer))]
public class AimController : MonoBehaviour
{



    // Animations
     private Animator animator;
    private bool isAnimationPlaying = false;
    private GameObject previousHit = null;
    
    // Preview text below objects
    public TMP_Text hoverTextInstance; // Instance of the TextMeshPro text component
    
    
    // Raycast hitter - Relative Camera
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;
    LineRenderer laserLine;
    float fireTimer;
    GameObject lastHitObject=null; // Store the last object hit by the laser
    [SerializeField] private float hoverDistance = 0.5f; // Distance to move closer on hover (adjustable in Inspector)
    [SerializeField] private float transitionSpeed = 5f; // Speed of movement transition (adjustable in Inspector)
    [SerializeField] private bool useEasing = true; // Use easing function for smoother animation (optional)





    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        
    }

    void Start(){
        
        Debug.Log(Input.mousePosition);
    }
    void Update()

    {
            RaycastCollider();
            
    }

    void RaycastCollider()
    {
        
        // fireTimer += Time.deltaTime;
        fireTimer = 0;
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            lastHitObject = hit.collider.gameObject;
            laserLine.SetPosition(1, hit.point);
            // Debug.Log("Hit object: " + hit.collider.gameObject.name);
            ApplyHoverEffect(hit.collider.gameObject);     
            
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
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }

    void ApplyHoverEffect(GameObject obj)
    {
        string tag =obj.tag;
        ShowText(tag,obj,obj.name);   
        Onclicked(tag,obj,obj.name);
    }

    void RemoveHoverEffect()
    {
        if (hoverTextInstance != null)
        {
            hoverTextInstance.gameObject.SetActive(false);
            
        }
        
        isAnimationPlaying = false;
        if(previousHit != null){
                Debug.Log("OBJ NULL");
                animator = previousHit.GetComponent<Animator>();
                animator.SetBool("Normal", false); 
                
                previousHit =null;
                animator.enabled = false;
            
            }

    

    }

 
  

    void Onclicked(string tag,GameObject obj,string displayText) {
        Debug.Log(tag);
         if (Input.touchCount > 0  || Input.GetKeyDown(KeyCode.E))
        // if (Input.GetKeyDown(KeyCode.E))
        {   
            
             Touch touch = Input.GetTouch(0);
            
            // Check if the touch phase is began or moved
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || Input.GetKeyDown(KeyCode.E)){
            
            

                // Debug.Log("Single touch detected at position: " + touch.position);
                switch (tag){
                    case "appIcons":
                        Debug.Log("Got a button");
                        HandleButtonClick(obj);
                        break;
                    case "Click To Start":
                        Debug.Log("Screen Action .......");
                        SceneManager.LoadScene("Desktop Screen");
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

    void ShowText(string tag,GameObject obj,string displayText)

    {

        if(tag == "appIcon"){
        // Vector3 currentPosotion=obj.transform.position;
        Bounds bounds = GetBounds(obj);
        
        Vector3 bottomPosition = bounds.center - new Vector3(0, bounds.extents.y, 0);

        
        
        // Set position of hover text just below the object
        hoverTextInstance.transform.position = bottomPosition + Vector3.down * 0.1f; // Adjust as needed
        hoverTextInstance.text = displayText; // Set the text content
        hoverTextInstance.gameObject.SetActive(true);
        
        if(lastHitObject !=null){
            SmoothTransitionToTarget(lastHitObject);
        }
            
        }
    }
    Bounds GetBounds(GameObject obj)
    {
        // Try to get the renderer component
        Renderer renderer = obj.GetComponent<Renderer>();

        // If renderer is not available, try to get the collider
        if (renderer == null)
        {
            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
            {
                // Use collider bounds if renderer is not available
                return collider.bounds;
            }
            else
            {
                Debug.LogError("Renderer or Collider component not found on GameObject!");
                return new Bounds(); // Return empty bounds
            }
        }
        else
        {
            // Use renderer bounds
            return renderer.bounds;
        }
    }

 
    public void SmoothTransitionToTarget(GameObject currentObj)
    {
        animator = currentObj.GetComponent<Animator>();
        if (currentObj != null)
        { 
            if (animator == null)
            {
                
                return;// Debug.LogError("Animator component not found on the highlighted GameObject.");
            }            
            if (isAnimationPlaying)
                return;
            
            animator.enabled = true;
            // Trigger the animation
            previousHit=currentObj;
            
            animator.SetBool("Normal", true); 

            isAnimationPlaying = true;
            
        }
    }
    
    private void HandleButtonClick(GameObject highlightedButton)
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (highlightedButton != null)
            {
                // Simulate button click using events
                Button button = highlightedButton.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                }
            }
        }
    }
}




