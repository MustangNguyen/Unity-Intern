using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Enemy : Character
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private EnemyMovementController enemyMovementController;
    [SerializeField] private TextMeshProUGUI healPointText;
    [SerializeField] private EnemyPool enemyPool;
    private void OnEnable(){
        enemyMovementController = FindObjectOfType<EnemyMovementController>();
        enemyMovementController.SetCharacter(this);
    }
    public override void CharacterMovement(){
        
        transform.Translate(LookAt()*movingSpeed*Time.deltaTime);
    }
    private Vector3 LookAt(){
        Vector3 direction;
        if(playerPos==null||!playerPos.gameObject.activeSelf){
            direction = Vector3.zero - transform.position;
            direction.Normalize();
            return direction;
        }
        direction = playerPos.transform.position - transform.position;
        direction.Normalize();
        return direction;
    }
    public void UpdateHealPointText(){
        healPointText.text = "HP: " + healthPoint.ToString();
    }
    protected override void BeKilled(){
        if(healthPoint<=0){
            ResetStat();
            enemyMovementController.RemoveCharacter(this);
            enemyPool.ReturnPrefabBackToPool(this);
        }
    }
    private void ResetStat(){
        healthPoint = maxHealthPoint;
    }
    protected override void TakeDamage(int damageTaking)
    {
        healthPoint -= damageTaking;
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Bullet")){
            TakeDamage(col.gameObject.GetComponent<BulletBehavior>().bulletDamage);       
            BeKilled();
        }
    }
}
