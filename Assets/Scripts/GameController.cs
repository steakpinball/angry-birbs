using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject birbPrefab;
    public Dragging slingshot;
    public Transform spawnPoint;
    public Rigidbody2D springAnchor;

    private GameObject _currentBirb;

    private void SpawnBirb()
    {
        var newBirb = Instantiate(birbPrefab, spawnPoint.position, spawnPoint.rotation);
        newBirb.GetComponent<BirbInput>().slingshot = slingshot;
        newBirb.GetComponent<Launch>().slingshot = slingshot;
        newBirb.GetComponent<SpringJoint2D>().connectedBody = springAnchor;
        _currentBirb = newBirb;

        slingshot.contents = newBirb.GetComponent<CircleCollider2D>();
        slingshot.enabled = true;
    }

    #region Unity Events

    private void Start()
    {
        SpawnBirb();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(_currentBirb);
            SpawnBirb();
            
        }
    }

    #endregion
}
