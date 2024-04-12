using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimButtonManager : MonoBehaviour
{
    // [SerializeField] private string highlightTrigger;
    // [SerializeField] private string normalTrigger;

    // void Start()
    // {
    //     FindButtons();
    // }

    // void Update()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Adjust for touch if needed
    //     RaycastHit hit;

    //     GameObject highlightedButton = null;

    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         highlightedButton = hit.collider.gameObject;
    //     }

    //     UpdateButtonHighlights(highlightedButton);
    //     HandleButtonClick(highlightedButton);
    // }

    // private void FindButtons()
    // {
    //     Button[] buttons = FindObjectsOfType<Button>();
    //     foreach (Button button in buttons)
    //     {
    //         GameObject buttonObject = button.gameObject;
    //         Animator buttonAnimator = buttonObject.GetComponent<Animator>();
    //         if (buttonAnimator == null)
    //         {
    //             Debug.LogError("Button " + buttonObject.name + " lacks Animator component!");
    //         }
    //     }
    // }

    // private void UpdateButtonHighlights(GameObject highlightedButton)
    // {
    //     foreach (Button button in FindObjectsOfType<Button>())
    //     {
    //         GameObject buttonObject = button.gameObject;
    //         Animator buttonAnimator = buttonObject.GetComponent<Animator>();

    //         HighlightButton(buttonAnimator, highlightedButton == buttonObject);
    //     }
    // }

    // private void HighlightButton(Animator buttonAnimator, bool isHighlighted)
    // {
    //     if (isHighlighted)
    //     {
    //         buttonAnimator.SetTrigger(highlightTrigger);
    //     }
    //     else
    //     {
    //         buttonAnimator.SetTrigger(normalTrigger);
    //     }
    // }

    // private void HandleButtonClick(GameObject highlightedButton)
    // {
    //     if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    //     {
    //         if (highlightedButton != null)
    //         {
    //             // Simulate button click using events
    //             Button button = highlightedButton.GetComponent<Button>();
    //             if (button != null)
    //             {
    //                 button.onClick.Invoke();
    //             }
    //         }
    //     }
    // }
}
