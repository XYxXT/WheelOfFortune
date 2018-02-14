using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelOfFortune : MonoBehaviour {
    public float rotateSpeed = -1f;
    public float deltaSpeed = 1f;
    public Text resultText;

    private bool isStarted;
    private float initSpeed;
    private Dictionary<string, int> prizeList;
    private string prizeWin;


    // Use this for initialization
    void Start () {
        isStarted = false;
        prizeList = new Dictionary<string, int>();
        prizeList.Add("prize_0", 0);
        prizeList.Add("prize_1", 1);
        prizeList.Add("prize_2", 2);
        prizeList.Add("prize_3", 3);
        resultText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (isStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isStarted = true;
                initSpeed = Random.Range(300, 500);
            }
        }

        if (isStarted)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * initSpeed * Time.deltaTime);

            initSpeed = initSpeed - deltaSpeed;
            if (initSpeed <= 0)
            {
                isStarted = false;
                resultText.text = "Te ha tocado " + prizeList[prizeWin] + "º premio";
            }
               


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prizeWin = collision.tag;
        Debug.Log(collision.tag);
    }
}
