using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : Character
{
    [SerializeField] private TextMeshProUGUI healthPointText;
    [SerializeField] private EnemyMovementController enemiesList;
    [SerializeField] public Transform nearestEnemy;
    [SerializeField] private float nearestEnemyDistance = 999;
    private void Start(){
    }
    private void Update(){
        GetFisrtEnemyPosition();
        CharacterMovement();
        UpdateHealthPointText();
        TrackingEnemy();
        FindNearestEnemy();
    }
    public override void CharacterMovement()
    {
        base.CharacterMovement();
        Vector3 direction = InputManager.Instance.GetArrowButton();
        transform.Translate(direction*movingSpeed*Time.deltaTime);
    }
    protected override void TakeDamage(int damageTaking)
    {
        base.TakeDamage(damageTaking);
        healthPoint-=damageTaking;
    }
    protected override void BeKilled(){
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Enemy")){
            TakeDamage(col.gameObject.GetComponent<Enemy>().damage);
            if(healthPoint<=0){
                BeKilled();
            }
        }
    }
    private void UpdateHealthPointText(){
        healthPointText.text = "Player HP: " + healthPoint.ToString();
    }
    private Transform FindNearestEnemy(){     
        if(enemiesList.characters.Count == 0) return nearestEnemy;
        foreach(Enemy enemy in enemiesList.characters){
            float distanceFromEnemyToPlayer = Vector3.Distance(enemy.transform.position,transform.position);
            if(nearestEnemyDistance > distanceFromEnemyToPlayer){
                nearestEnemyDistance = distanceFromEnemyToPlayer;
                nearestEnemy = enemy.transform;
            }
        }
        return nearestEnemy;
    }
    private void GetFisrtEnemyPosition(){
        if (enemiesList.characters.Count == 0) return;
        nearestEnemyDistance = Vector3.Distance(enemiesList.characters[0].transform.position,transform.position);
        nearestEnemy = enemiesList.characters[0].transform;
    }
    private void TrackingEnemy(){
        if(enemiesList.characters.Count == 0) return;
        nearestEnemyDistance = Vector3.Distance(nearestEnemy.position,transform.position);
    }
}
