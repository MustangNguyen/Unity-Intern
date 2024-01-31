using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] public List<Enemy> characters = new List<Enemy>();
    private void Update(){
        foreach(Enemy enemy in characters){
            enemy.CharacterMovement();
            enemy.UpdateHealPointText();
        }
    }
    public void SetCharacter(Enemy enemy){
        characters.Add(enemy);
    }
    public void RemoveCharacter(Enemy enemy){
        characters.Remove(enemy);
    }
}
