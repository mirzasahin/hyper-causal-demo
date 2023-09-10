using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    public List<GameObject> blockList  = new List<GameObject>();

    private GameObject lastBlockObject;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLastBlockObject(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseBlockStack(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
    }

    public void DecreaseBlock(GameObject _gameobject)
    {
        _gameobject.transform.parent = null;
        blockList.Remove(_gameobject);
        UpdateLastBlockObject();
    }

    private void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
