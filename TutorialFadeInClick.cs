using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFadeInClick : MonoBehaviour 
{
	public bool 		isTestingResetKey   = false;
	public bool 		isStart 			= false;

	public string		fadeInBool			= "FadeIn";
	public string		fadeOutBool 		= "FadeOut";

	public string		key					= "";
	public GameObject[] fadeObjects;

	private Animator 	m_Animator;


	void Start()
	{
		if (isTestingResetKey)
		{
			PlayerPrefs.SetInt(key, 1);
			PlayerPrefs.Save();
		}

		if (isStart)
		{
			if (!PlayerPrefs.HasKey(key))
			{
				PlayerPrefs.SetInt(key, 1);
				PlayerPrefs.Save();
			}

			if (PlayerPrefs.GetInt(key) == 1) // True
			{
				foreach (GameObject fadeObject in fadeObjects)
				{
					fadeObject.SetActive(true);
					m_Animator = fadeObject.GetComponent<Animator>();
					m_Animator.SetBool(fadeInBool, true);
					m_Animator.SetBool(fadeOutBool, false);
				}
			}
		}
	}

	public void TutorialAction()
	{
		if (!PlayerPrefs.HasKey(key))
		{
			PlayerPrefs.SetInt(key, 1);
			PlayerPrefs.Save();
		}

		if (PlayerPrefs.GetInt(key) == 1) // True
		{
			if (!isStart)
			{
				foreach (GameObject fadeObject in fadeObjects)
				{
					fadeObject.SetActive(true);
					m_Animator = fadeObject.GetComponent<Animator>();
					m_Animator.SetBool(fadeInBool, true);										
					m_Animator.SetBool(fadeOutBool, false);
				}
			}
		}
	}

	public void OnMouseDown()
	{
		TutorialAction();
	}
}
