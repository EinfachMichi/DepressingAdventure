using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public NewSafeQuickTime QTime;

    int PlayerHp;
    int EnemyHp;

    [SerializeField] Slider PlayerSlider;
    [SerializeField] Slider EnemySlider;
    void Start()
    {
        EnemyHp= QTime.Enemyhealth;
        PlayerHp = QTime.Playerhealth;

        PlayerSlider.maxValue = PlayerHp;
        EnemySlider.maxValue = EnemyHp;

        PlayerSlider.value = PlayerHp;
        EnemySlider.value = EnemyHp;
    }

    void Update()
    {
        
    }

    public void PlayerOrEnemyGetDmg()
    {
        PlayerHp = QTime.Playerhealth;
        EnemyHp = QTime.Enemyhealth;

        PlayerSlider.value= PlayerHp;
        EnemySlider.value = EnemyHp;
        print("hp");
    }
}
