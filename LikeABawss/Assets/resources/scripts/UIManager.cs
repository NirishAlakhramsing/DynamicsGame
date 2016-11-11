using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //track bridgeweights
    public int weightsDropped = 0;
    public Text text;

    public float readTime;
    public int dialogueNr;
    public bool sendFeedback;

    // Use this for initialization
    void Awake () {
        iTween.FadeTo(GameObject.Find("GUI Camera"), iTween.Hash("alpha", 0f, "time", 0.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        iTween.FadeTo(GameObject.Find("Controls"), iTween.Hash("alpha", 1f, "time", 1.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 1.1f));
        iTween.FadeTo(GameObject.Find("MouseRightButton"), iTween.Hash("alpha", 0f, "time", 0.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        iTween.FadeTo(GameObject.Find("MouseLeftButton"), iTween.Hash("alpha", 0f, "time", 0.0f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
    }
	

    void Start()
    {
        text = GameObject.Find("CharacterUISprite").GetComponentInChildren<Text>();

        StartCoroutine(RenderText(0));
    }

	// Update is called once per frame
	void Update () {

	}

    public IEnumerator RenderText (int textNr)
    {
        if (textNr == 0)
        { 
            //new text
            text.text = "This forest holds a secret. I need to find out what it is.";
            //move in
            iTween.MoveBy(GameObject.Find("CharacterUISprite"), iTween.Hash("amount", new Vector3(15f, 0f, 0f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        if (textNr == 1)
        {
            //new text
            text.text = "What the...flying stone? I cant hit that with my fists?";
            //move in
            iTween.MoveBy(GameObject.Find("CharacterUISprite"), iTween.Hash("amount", new Vector3(15f, 0f, 0f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        if (textNr == 2)
        {
            //new text
            text.text = "Up there. It shows me what i need to find.";
            //move in
            iTween.MoveBy(GameObject.Find("CharacterUISprite"), iTween.Hash("amount", new Vector3(15f, 0f, 0f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        if (textNr == 3)
        {
            //new text
            text.text = "I feel a burning feeling in my right hand";
            //move in
            iTween.MoveBy(GameObject.Find("CharacterUISprite"), iTween.Hash("amount", new Vector3(15f, 0f, 0f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        }

        yield return new WaitForSeconds(readTime);
        iTween.MoveBy(GameObject.Find("CharacterUISprite"), iTween.Hash("amount", new Vector3(-15f, 0f, 0f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        
    }

}
