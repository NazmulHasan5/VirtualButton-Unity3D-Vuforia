using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureImage : MonoBehaviour
{
    public Camera snapCam;
    int resWidth , resHeight;
    public GameObject fleshImage;
    private void Start()
    {
        snapCam = GetComponent<Camera>();
    }
    public void TakePicture()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        Debug.Log("Width: " + resWidth + " Height: " + resHeight);
        snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        StartCoroutine(TakeSnapShot());
    }

    private IEnumerator TakeSnapShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D snapShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;
        snapShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        byte[] bytes = snapShot.EncodeToPNG();
        string fileName = string.Format("{0}/SnapShots/{1}_{2}.png",Application.dataPath, Application.productName, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        System.IO.File.WriteAllBytes(fileName, bytes);
        Debug.Log("Snapshot Taken");
        snapCam.targetTexture = null;
        fleshImage.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.2f);
        fleshImage.SetActive(false);
    }

  
}
