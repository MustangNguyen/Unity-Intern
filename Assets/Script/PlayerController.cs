using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private TextMeshProUGUI healthPointText;
    private void Update(){
        CharacterMovement();
        UpdateHealthPointText();
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
}
