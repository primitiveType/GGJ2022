using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    private Renderer[] renderers;

    private static readonly int DissolveAmount = Shader.PropertyToID("DissolveAmount");

    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Dissolve()
    {
        StartCoroutine(DissolveCr());
    }

    private IEnumerator DissolveCr()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            foreach (Renderer renderer1 in renderers)
            {
                renderer1.sharedMaterial.SetFloat(DissolveAmount, t);
            }


            yield return null;
        }

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}