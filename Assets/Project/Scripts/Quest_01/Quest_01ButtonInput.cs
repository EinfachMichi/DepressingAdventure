using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest_01ButtonInput : MonoBehaviour
{
    private int round;
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

    public void Start()
    {
        Player.GetComponent<Image>().sprite = ChoosenItem[1];
        Enemy.GetComponent<Image>().sprite = ChoosenItem[1];
        round = 1;
        RoundCounterText.text = null;
        EnemyPointsText.text = enemypoints.ToString();
        PlayerPointsText.text = playerpoints.ToString();
    }

    public void PlayerChoose(int choose)
    {
        if (round == 1 || round == 3)
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
        this.choose = choose;
        pointCheck();
        StartRound();
    }

    private void StartRound()
    {
        round++;
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
        SceneManager.LoadScene("Tutorial");
    }

    void pointCheck()
    {
        if (choose < enemychoose||enemychoose==1&&choose==3)
        {
            enemypoints++;
            EnemyPointsText.text = enemypoints.ToString();
        }
        else if (choose > enemychoose || enemychoose == 3 && choose == 1)
        {
            playerpoints++;
            PlayerPointsText.text = playerpoints.ToString();
        }

    }
}
