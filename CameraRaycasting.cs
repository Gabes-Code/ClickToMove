using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ClickToMove player;

    private int groundLayer;

    void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
            {
                Debug.Log("Moving player to: " + hit.point);
                player.MoveTo(hit.point);
            }
        }
    }
}
