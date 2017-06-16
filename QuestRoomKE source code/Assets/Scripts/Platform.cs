using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    bool isPressed = false;
    public GameObject MyPlatform;
    public GameObject MySafe;
    public AnimationClip aclipD;
    public AnimationClip aclipU;
    public AnimationClip wallS;
    public AnimationClip wallSBack;
    // Use this for initialization
    void Start () {
        isPressed = false;
    }
	
	// Update is called once per frame
	void Update () {
	
  //      if (isPressed)
         //   MyPlatform.GetComponent<Animation>().Play(aclip.name);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" || col.tag=="Стул")
        {
      //      Debug.Log("Вы встали на платформу");
            isPressed = true;
            MyPlatform.GetComponent<Animation>().Play(aclipD.name);
            MySafe.GetComponent<Animation>().Play(wallS.name);
            //     MyPlatform.GetComponent<Animation>().Play(aclip.name);

            //   this.gameObject.transform.parent.GetComponent<Animator>().enabled = true;
            //     this.gameObject.transform.parent.GetComponent<Animation>().Play("PlatfDown");

            /*  gameObject.transform.parent.gameObject.transform.localScale =
                          new Vector3(gameObject.transform.parent.gameObject.transform.localScale.x,
                             gameObject.transform.parent.gameObject.transform.localScale.y-1.5f,
                            gameObject.transform.parent.gameObject.transform.localScale.z); */
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player" || col.tag == "Стул")
        {
      //      Debug.Log("Вы покинули платформу");
            isPressed = false;
            MyPlatform.GetComponent<Animation>().Play(aclipU.name);
            MySafe.GetComponent<Animation>().Play(wallSBack.name);
            //    this.gameObject.transform.parent.GetComponent<Animation>().Play("PlatfUp");
            /*  gameObject.transform.parent.gameObject.transform.position =
                          new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x,
                           this.gameObject.transform.parent.gameObject.transform.position.y + 2,
                           this.gameObject.transform.parent.gameObject.transform.position.z);  */
        }
    }
}
