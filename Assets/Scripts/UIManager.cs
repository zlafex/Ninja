﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] List<GameObject> uI;

    Image healthBar;
    TextMeshProUGUI scoreText;

    [HideInInspector] public float stamina;
    [HideInInspector] public float score;

    public override void Init()
    {
        GameManager.Instance.startGame += () => this.enabled = true;
    }

    void Start()
    {
        foreach (var go in uI)
        {
            if (go != uI[PlayerPrefs.GetInt("UI", 0)])
            {
                Destroy(go);
            }
            else
            {
                go.SetActive(true);
            }
        }
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        healthBar.fillAmount = stamina / 100;
        scoreText.text = ((int)score).ToString();
    }
}
