using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    public ArrayList HpList;
    public Image hpimage;
    public Image[] img = new Image[5];
    void Start()
    {
        HpList = new ArrayList();

        for(int i=0;i<5;i++)
        {
            img[i] = Instantiate(hpimage);
            img[i].transform.parent = transform;
            HpList.Add(hpimage);
            img[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        ShowHp();
    }

    void ShowHp()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < CharacterManager.Get_instance().Ch_Hp)
            {
                img[i].gameObject.SetActive(true);
            }
            if (i >= CharacterManager.Get_instance().Ch_Hp)
            {
                img[i].gameObject.SetActive(false);
            }
        }
    }





}
