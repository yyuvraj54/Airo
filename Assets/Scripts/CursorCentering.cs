using UnityEngine;

public class CursorCentering : MonoBehaviour
{
 
  private Vector2 screenCenter;

  void Start()
  {
    screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
  }

  void Update()
  {
    // Cast Camera.main.ScreenPointToRay(Input.mousePosition).origin to Vector2
    // to ensure compatible subtraction with screenCenter (Vector2)
    Vector2 mousePositionRelativeToCenter = (Vector2)Camera.main.ScreenPointToRay(Input.mousePosition).origin - screenCenter;

    // Do something with the centered mouse position, for example:
    Debug.Log("Mouse X (relative to center): " + mousePositionRelativeToCenter.x);
  }
}
