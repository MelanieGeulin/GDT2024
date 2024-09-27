using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private float _waitingTime = 1f;
    [SerializeField]
    private Animator _transitionAnimator;
    [SerializeField]
    private Image _screen;
    // Start is called before the first frame update
    void Start()
    {
        _screen.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneByIndex(int buildIndexID)
    {
        StartCoroutine(LoadScene(buildIndexID));
    }
    private IEnumerator LoadScene(int buildIndexId)
    {
        _transitionAnimator.SetTrigger("Transition");
        yield return new WaitForSeconds(_waitingTime);
        SceneManager.LoadScene(buildIndexId);
    }
}
