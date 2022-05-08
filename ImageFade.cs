using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFade : MonoBehaviour
{
     public float FadeRate;
     public RawImage image;
     public float targetAlpha;
     public float TIME_LIMIT = 30F;
 
     // timer variable
     public float timer = 0F;
     // Use this for initialization
     void Start () {
         this.image = this.GetComponent<RawImage>();
         if(this.image==null)
         {
             Debug.LogError("Error: No image on "+this.name);
         }
         this.targetAlpha = this.image.color.a;
     }
     
     // Update is called once per frame
     void Update () {
         Color curColor = this.image.color;
         float alphaDiff = Mathf.Abs(curColor.a-this.targetAlpha);
         if (alphaDiff>0.0001f)
         {
             curColor.a = Mathf.Lerp(curColor.a,targetAlpha,this.FadeRate*Time.deltaTime);
             this.image.color = curColor;
         }
         this.timer += Time.deltaTime;
 
         // check if it's time to switch scenes
         if (this.timer >= TIME_LIMIT)
         {
             FadeIn();
         }
         

     }
 
     public void FadeOut()
     {
         this.targetAlpha = 0.0f;
     }
 
     public void FadeIn()
     {
         this.targetAlpha = 1.0f;
     }
 }
