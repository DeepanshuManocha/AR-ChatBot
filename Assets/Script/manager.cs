using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject addData, showData;
   public void displayAdd()
   {
       addData.SetActive(true);
   }
   public void displayshow()
   {
       showData.SetActive(true);
   }
   public void closeAdd()
   {
       addData.SetActive(false);
   }
   public void closeShow()
   {
       showData.SetActive(false);
   }
}
