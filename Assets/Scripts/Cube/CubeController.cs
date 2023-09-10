using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] private PlayerStackController playerStackController;

    private Vector3 direction = Vector3.back;

    private bool isStack = false;

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
        // SphereCast baþlangýç noktasý (kürenin merkezi) ve yarýçapýný kullanýr
        float radius = 0.5f; // Küre yarýçapý, ayarlamalarý ihtiyaca göre yapabilirsiniz
        Vector3 castDirection = direction.normalized; // Raycast yönü

        // SphereCast ile çevresindeki objeleri tespit et
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
                playerStackController.DecreaseBlock(gameObject);
            }
        }
    }


    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
