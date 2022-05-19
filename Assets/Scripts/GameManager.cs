
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager mInstance;

    public static GameManager GetInstance()
    {
        return mInstance;
    }

    public Text cMuertes;
    public GameObject hero;
    private HeroController mHeroController;

    private int contMuertes = 0;

    private void Awake()
    {
        mInstance = this;
    }

    private void Start()
    {
        mHeroController = hero.GetComponent<HeroController>();
        mHeroController.AddOnDieDelegate(OnDieDelegate);
    }

    public void OnDieDelegate(object sender, EventArgs e)
    {
        contMuertes++;
        cMuertes.text = "Muertes: "+contMuertes.ToString();
    }
}
