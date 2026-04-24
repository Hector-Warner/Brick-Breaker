using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 startPos;
    public float magnitude = 0.1f;
    public float shakeDur = 0.1f;
    void Start()
    {
       startPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallShake()
    {
        StartCoroutine(Shake());
    }
    [ContextMenu("Shake")]
    public IEnumerator Shake()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < shakeDur)
        {
            transform.localPosition = new Vector3 (startPos.x + Random.Range(-magnitude,magnitude), startPos.y + Random.Range(-magnitude,magnitude), startPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = startPos;
    }
}
