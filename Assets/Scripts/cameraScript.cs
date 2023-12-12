using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Update()
    {
        transform.position = player.transform.position;
    }
}
