using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScene : MonoBehaviour
{
    public void LoadActionScene()
    {
        SceneManager.LoadScene(2);
    }
}
