using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 3;
    public float deadZone = -100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.position= transform.position + (Vector3.down * moveSpeed) *Time.deltaTime;

    if (transform.position.y<deadZone){
        Destroy(gameObject);
    }
    }
}
