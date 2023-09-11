using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] private PlayerStackController playerStackController;

    private Vector3 direction = Vector3.back;

    public bool isStack = false;
    public bool touchedObstacle = false;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        playerStackController = GameObject.FindObjectOfType<PlayerStackController>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        // SphereCast ba?lang?? noktas? (k?renin merkezi) ve yar??ap?n? kullan?r
        float radius = 0.5f; // K?re yar??ap?, ayarlamalar? ihtiyaca g?re yapabilirsiniz
        Vector3 castDirection = direction.normalized; // Raycast y?n?

        // SphereCast ile ?evresindeki objeleri tespit et
        if (Physics.SphereCast(transform.position, radius, castDirection, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = true;
                playerStackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                touchedObstacle = true;
                playerStackController.DecreaseBlock(gameObject);
            }
        }
    }


    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
