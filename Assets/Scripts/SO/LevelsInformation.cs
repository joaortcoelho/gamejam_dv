using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Level Data", fileName = "New Level Data")]
public class LevelsInformation : ScriptableObject
{
  private int maxPacts = 0;
  private int purifiedPacts = 0;
  [SerializeField] private string currentLevel;
  [SerializeField] private string nextLevel;
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

  public string CurrentLevel
  {
    get => currentLevel;
  }
  
  public string NextLevel
  {
    get => nextLevel;
  }
  
  public void OnAfterDeserialize()
  {
    maxPacts = 0;
    purifiedPacts = 0;
  }

  public bool IsLevelCompleted()
  {
    return maxPacts == purifiedPacts;
  }
}
