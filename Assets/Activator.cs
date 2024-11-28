using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    public gameLogic logic;
    bool active=false;
    GameObject note;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)&&active){
            logic.addScore();
            Destroy(note);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        active=true;
        if(col.gameObject.tag=="Note"){
            note=col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        active=false;
    }
}
