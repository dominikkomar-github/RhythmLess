using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitting : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyPress;
    public GameObject HitEffect, MissEffect;
    public bool canExit = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyPress))
        {
            if(canBePressed)
            {
                canExit = false;
                ManagerTop.instance.Hit();
                ManagerBottom.instance.Hit();
                ManagerLeft.instance.Hit();
                ManagerRight.instance.Hit();
                Instantiate(HitEffect, transform.position, HitEffect.transform.rotation);
                gameObject.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Pressed")
        {
            canBePressed = true;
            
        }
    }

      private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Pressed")
            {
                if(canExit) 
                {
                    canBePressed = false;
                    ManagerTop.instance.Miss();
                    ManagerBottom.instance.Miss();
                    ManagerLeft.instance.Miss();
                    ManagerRight.instance.Miss();
                    Instantiate(MissEffect, transform.position, MissEffect.transform.rotation);
                    Destroy(gameObject);
                }
            }
    }
}
