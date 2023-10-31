using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class StackManager : Singletion<StackManager>
{
    
    public int stackValue;
    public TMP_Text stackValueText;
    
    public void StackObject(GameObject other, int index)
    {
        stackValue++;
        stackValueText.text = stackValue.ToString();
        
        other.gameObject.transform.parent = transform;
        Vector3 newPos = PlayerManager.Instance.collected[index].transform.localPosition;
        if (index == 0)
        {
            newPos.z += 0.4f;
        }

        newPos.z += 1f;
        newPos.y = 0f;

        other.transform.localPosition = newPos;
        PlayerManager.Instance.collected.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    public IEnumerator MakeObjectsBigger()
    {
        for (int i = PlayerManager.Instance.collected.Count - 1; i >= 1; i--)
        {
            int index = i;
            Vector3 scale = Vector3.zero;

            if (PlayerManager.Instance.collected[index].gameObject.tag == "Collect")
            {
                scale = new Vector3(1, 1, 1);
                Vector3 doScale = scale * 1.5f;
                PlayerManager.Instance.collected[index].transform.DOScale(doScale, 0.06f).OnComplete(() =>
                    PlayerManager.Instance.collected[index].transform.DOScale(scale, 0.06f));

                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}