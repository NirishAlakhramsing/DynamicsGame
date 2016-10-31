using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    public int health;
    bool canDie = true;
    GameObject getUIObj;
    GameObject currentHeart;
    public RPGCharacterControllerFREE playerScript;
    public EnemyBehaviour enemyScript;
    public GameObject Heart1, Heart2, Heart3;


    // Use this for initialization
    void Start () {
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0f, "time", 10f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        getUIObj = GameObject.Find("HealthBarGUI");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);

        if (Input.GetKeyUp(KeyCode.L))
        {
            ReviveHearths();
        }
    }

    public void RemoveHearth(int getHealth)
    {
        
        //For each case stop all other itweens before using new ones and show HealthBar UI again
        if (canDie)
        switch (getHealth)
        {
            case 3:
                //currentHeart = GameObject.Find("Heart0");
                iTween.Stop(gameObject);
                iTween.FadeTo(gameObject, iTween.Hash("alpha", 1f, "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                StartCoroutine(FadeOutUI(Heart1));
                break;
            case 2:
                //currentHeart = GameObject.Find("Heart1");
                iTween.Stop(gameObject);
                iTween.FadeTo(gameObject, iTween.Hash("alpha", 1f, "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                StartCoroutine(FadeOutUI(Heart2));
                break;
            case 1:
                //currentHeart = GameObject.Find("Heart2");
                iTween.Stop(gameObject);
                iTween.FadeTo(gameObject, iTween.Hash("alpha", 1f, "time", 0.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                StartCoroutine(FadeOutUI(Heart3));
                break;
            case 0:
                // player dies
                Debug.Log("In switch case 0 ");
                playerScript.Invoke("startDeath", 0.1f);
                enemyScript.playerAlive = false;
                canDie = false;
                break;
            default:
            break;
        }
    }

    public void ReviveHearths()
    {
        
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            currentHeart = GameObject.Find("Heart"+i);
            iTween.MoveAdd(currentHeart, iTween.Hash("amount", new Vector3(0, -5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            iTween.FadeTo(currentHeart, iTween.Hash("alpha", 1f, "time", 1f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

    }

    IEnumerator FadeOutUI(GameObject name)
    {
        yield return new WaitForSeconds(0.3f);
        //move and fade out the heart
        iTween.MoveAdd(name, iTween.Hash("amount", new Vector3(0, 5f, 0), "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        iTween.FadeTo(name, iTween.Hash("alpha", 0f, "time", 2f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        //Fade out the entire Healthbar UI
        yield return new WaitForSeconds(2.5f);
        //Destroy(name);
        name.SetActive(false);
        name.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        iTween.FadeTo(gameObject, iTween.Hash("alpha", 0f, "time", 10f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        
    }
}
