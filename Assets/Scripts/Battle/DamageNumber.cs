using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public float lifetime = 1f;
    public float moveSpeed = 1f;

    public float placmentJitter = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);

    }

    public void SetDamage(int damageAmmount)
    {
        damageText.text = damageAmmount.ToString();
        transform.position += new Vector3(Random.Range(-placmentJitter, placmentJitter), Random.Range(-placmentJitter, placmentJitter), 0f);
    }
}
