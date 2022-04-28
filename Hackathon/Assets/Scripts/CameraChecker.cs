using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    checker checker;
    public GameObject nehirustu, nehirdensonra, kopruustu, koprudensonra, holeustu, holedensonra, nehir, kopru, hole, diyalog82;
    public GameObject LriverCam, WeakbridgeCam, holeCam, checkerObject;
    private void OnTriggerEnter(Collider other)
    {
        //checker'ý birden çok objenin ayný anda bir deðere bakmasý için atadým.
        //bu scriptte nehir/köprü/hole kýsýmlarýnda giriþ/orta/çýkýþa koyduðum triggerlara bakýyor
        //mesela önce giriþ'e girmesi bir þey ifade etmiyor, orta-çýkýþ veya tersten gelir orta-giriþ yaparsa animasyon çalýþýyor.
        checker = checkerObject.GetComponent<checker>();
        print(gameObject.name);
        if(gameObject.name == "nehir")
        {
            checker.isRiver = true;
        }
        else if (gameObject.name == "kopru")
        {
            checker.isWeakbridge = true;
        }

        else if (gameObject.name == "hole")
        {
            checker.isHole = true;
        }
        if (checker.isRiver && (gameObject == nehirustu.gameObject || gameObject == nehirdensonra.gameObject))
        {
            StartCoroutine(BreakAnim("Lriver"));
        }
        if (checker.isWeakbridge && (gameObject == kopruustu.gameObject || gameObject == koprudensonra.gameObject))
        {
            StartCoroutine(BreakAnim("weakbridge"));
        }
        if (checker.isHole && (gameObject == holeustu.gameObject || gameObject == holedensonra.gameObject))
        {
            StartCoroutine(BreakAnim("hole"));
        }
    }
    private IEnumerator BreakAnim(string type)
    {
        if (type == "Lriver")
        {
            LriverCam.SetActive(true);
            yield return new WaitForSeconds(4);
            LriverCam.SetActive(false);
            nehirdensonra.SetActive(false);
            nehir.SetActive(false);
            nehirustu.SetActive(false);
        }
        else if (type == "weakbridge")
        {
            WeakbridgeCam.SetActive(true);
            yield return new WaitForSeconds(4);
            WeakbridgeCam.SetActive(false);
            diyalog82.SetActive(true);
            koprudensonra.SetActive(false);
            kopru.SetActive(false);
            kopruustu.SetActive(false);


        }
        else
        {
            holeCam.SetActive(true);
            yield return new WaitForSeconds(4);
            holeCam.SetActive(false);
            holedensonra.SetActive(false);
            hole.SetActive(false);
            holeustu.SetActive(false);

        }
    }
}
