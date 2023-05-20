using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Level", fileName = "New Level Data")]
public class LevelsInformation : ScriptableObject
{
  private int maxPacts = 0;
  private int purifiedPacts = 0;

  public int MaxPacts
  {
    get => maxPacts;
    set => maxPacts = value;
  }
  
  public int PurifiedPacts
  {
    get => purifiedPacts;
    set => purifiedPacts = value;
  }
}
