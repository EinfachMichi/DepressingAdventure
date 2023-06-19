using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Main;

public class Quest_01ButtonInput : MonoBehaviour
{
    public int round;

    [SerializeField] bool isRandom = false;
    [SerializeField] private int choose;
    [SerializeField] private int enemychoose=0;
    private int playerpoints=0;
    private int enemypoints;
    public GameObject[] Button;
    public GameObject Player;
    public GameObject Enemy;
    public Sprite[] ChoosenItem;

    public TMP_Text RoundCounterText;
    public TMP_Text PlayerPointsText;
    public TMP_Text EnemyPointsText;
    public string SceneName;

    public Animator Ani;
    public Animator AniEnmey;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        Player.GetComponent<Image>().sprite = ChoosenItem[1];
        Enemy.GetComponent<Image>().sprite = ChoosenItem[1];
        round = 1;
        RoundCounterText.text = null;
        EnemyPointsText.text = enemypoints.ToString();
        PlayerPointsText.text = playerpoints.ToString();

        isRandom = GameManager.Instance.Data.Q1IsRandom;
        print(isRandom + ("ran"));
    }

    public void Buttons()
    {
        for (int i = 0; i <= 2; i++)
        {
            Button[i].GetComponent<Button>().interactable = true;
        }
    }

    public void PlayerChoose(int choose)
    {
        print("Test");
        for (int i = 0; i < 3; i++)
        {
            Button[i].GetComponent<Button>().interactable = false;
            print("Test");
        }

        Player.GetComponent<Image>().sprite = ChoosenItem[1];
        Enemy.GetComponent<Image>().sprite = ChoosenItem[1];
        Ani.SetTrigger("Trigger");
        AniEnmey.SetTrigger("Trigger");
        if ((round == 1 || round == 3)&&isRandom==false)
        {
            if (choose == 3)
            {
                enemychoose = 1;
            }
            else
            {
                enemychoose = choose + 1;
            }
        }
        else
        {
            int index = Random.Range(1, ChoosenItem.Length+1);
            enemychoose = index;
            print(index);
        }

        RoundCounterText.text = round.ToString() + ". Runde";

        //none=0, schere=1, Stein=2, Papier=3

       
        this.choose = choose;
        
    }

    public void StartRound()
    {
        switch (choose)
        {
            case 0:
                Player.GetComponent<Image>().sprite = ChoosenItem[1];
                break;
            case 1:
                Player.GetComponent<Image>().sprite = ChoosenItem[0];
                break;
            case 2:
                Player.GetComponent<Image>().sprite = ChoosenItem[1];
                break;
            case 3:
                Player.GetComponent<Image>().sprite = ChoosenItem[2];
                break;
        }
        switch (enemychoose)
        {
            case 0:
                Enemy.GetComponent<Image>().sprite = ChoosenItem[1];
                break;
            case 1:
                Enemy.GetComponent<Image>().sprite = ChoosenItem[0];
                break;
            case 2:
                Enemy.GetComponent<Image>().sprite = ChoosenItem[1];
                break;
            case 3:
                Enemy.GetComponent<Image>().sprite = ChoosenItem[2];
                break;
        }
        round++;
        pointCheck();
        if (round > 3)
        {
            StartCoroutine(GoScene());
        }
    }

    IEnumerator GoScene()
    {
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].GetComponent<Button>().interactable = false;
        }
        yield return new WaitForSeconds(2f);

        GameManager.Instance.Data.Q1IsRandom = true;
        GameManager.Instance.Save();

        SceneManager.LoadScene(SceneName);
    }

    void pointCheck()
    {
        if ((choose==1&& enemychoose==2) || (choose == 2 && enemychoose == 3) || (choose == 3 && enemychoose == 1))
        {
            enemypoints++;
            EnemyPointsText.text = enemypoints.ToString();
            print("ENEMY");
        }
        else if((choose == 2 && enemychoose == 1) || (choose == 3 && enemychoose == 2) || (choose == 1 && enemychoose == 3))
        {
            playerpoints++;
            PlayerPointsText.text = playerpoints.ToString();
            print("PLAYER");
        }
    }

    void pause()
    {
        Button[0].GetComponent<Button>().interactable = false;
        Button[1].GetComponent<Button>().interactable = false;
        Button[2].GetComponent<Button>().interactable = false;
    }

    void unpause()
    {
        Button[0].GetComponent<Button>().interactable = true;
        Button[1].GetComponent<Button>().interactable = true;
        Button[2].GetComponent<Button>().interactable = true;
    }
}
