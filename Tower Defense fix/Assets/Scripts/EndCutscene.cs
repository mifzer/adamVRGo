using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCutscene : MonoBehaviour
{
    public SceneFader fader;

    public Animator animator;
    //public Animation cutscene;

    public string levelName;
    public static EndCutscene endCutInstance = null;
    public Sprite[] mySprite;
    public SpriteRenderer theSpriteRenderer;
    private int indexSprite = 0;
    public GameObject img_Next, img_Prev;
    bool endScene = false;

    private void Awake()
    {
        if (endCutInstance == null)
            endCutInstance = this;

        //ChangeSpriteAdd();
        //ChangeSpriteMin();
    }

    public void ChangeSpriteAdd()
    {
        
        if (endScene == true)
        {
            Application.LoadLevel("Level01");
            this.gameObject.SetActive(false);
        }else
        if(indexSprite<9&&indexSprite>=0){
            indexSprite++;
            theSpriteRenderer.sprite = mySprite[indexSprite];
            img_Next.SetActive(false);
            img_Prev.SetActive(false);
            StartCoroutine(SetFalse());
            if(indexSprite==9){
                endScene = true;
            }
        } 


    }

    public void ChangeSpriteMin()
    {
        if (indexSprite < 10 && indexSprite > 0)
        {
            theSpriteRenderer.sprite = mySprite[indexSprite - 1];
            indexSprite--;
            img_Next.SetActive(false);
            img_Prev.SetActive(false);
            StartCoroutine(SetFalse());
        }
    }
    void Update()
    {
        //if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
          //  fader.FadeTo(levelName);
    }

    IEnumerator SetFalse(){
        yield return new WaitForSeconds(3f);
        img_Next.SetActive(true);
        img_Prev.SetActive(true);
    }
}
