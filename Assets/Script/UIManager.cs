using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject addDialoguePanel, showDialogueDataPanel;

   public void DisplayAddDialoguePanel()
   {
       addDialoguePanel.SetActive(true);
   }

   public void DisplayDialogueDataPanel()
   {
       showDialogueDataPanel.SetActive(true);
   }

   public void CloseAddDialoguePanel()
   {
       addDialoguePanel.SetActive(false);
   }

   public void CloseDialogueDataPanel()
   {
       showDialogueDataPanel.SetActive(false);
   }
}
