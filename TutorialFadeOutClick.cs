using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFadeOutClick : MonoBehaviour 
{
	public bool 		isTestingResetKey   = false;

	public string		fadeInBool			= "FadeIn";
	public string		fadeOutBool 		= "FadeOut";

	public string		key					= "";
	public GameObject[] fadeObjects;

	private Animator 			m_Animator;

	void Start()
	{
		if (isTestingResetKey)
		{
			PlayerPrefs.SetInt(key, 1);
			PlayerPrefs.Save();
		}
	}

	public void TutorialAction()
	{
		if (PlayerPrefs.GetInt(key) == 1) // True
		{
			// We have already faded out this object and the next click has happened so disable this object
			if (PlayerPrefs.HasKey(key))
			{
				if (PlayerPrefs.GetInt(key) == 1) // True
				{
					// Set Key To False To Never Show The Tutorial Again
					PlayerPrefs.SetInt(key, 0); 
					PlayerPrefs.Save();

					// We are fading out this object so we can not disable the object otherwise the fade will not happen.
					foreach (GameObject fadeObject in fadeObjects)
					{
						m_Animator = fadeObject.GetComponent<Animator>();
						m_Animator.SetBool(fadeInBool, false);										
						m_Animator.SetBool(fadeOutBool, true);
					}
				}
			}
		}
	}

	public void OnMouseDown()
	{
		TutorialAction();
	}
}
