using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareManager : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject button;
    private string shareMessage;
    static int playerScore;

   
    
    public void shareButton(){
        button.SetActive(false);
        shareMessage = "I can't believe I scored " + playerScore.ToString() + " points in Dugong: The Ruined Homeland!";
        StartCoroutine(TakeScreenshotAndShare());
     
    }

    public static void GetPlayerScore(int score){
        playerScore = score;
    }

    public void hideSharePanel(){
        sharePanel.SetActive(false);
    }

    public void showSharePanel(){
        Debug.Log("IamtappedShowpanel");
        sharePanel.SetActive(true);
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        // To avoid memory leaks
        Destroy( ss );

        new NativeShare().AddFile( filePath )
            .SetSubject( "Dugong: The Ruined Homeland" ).SetText(shareMessage)
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
            .Share();

        button.SetActive(true);    
    }
}
