using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSelfDisable : MonoBehaviour 
{
	public string		fadeOutBool 		= "FadeOut";
	public string		fadeOutState 		= "TutorialMainLevelFadeOut";
	public string		key					= "";

	private Animator 			m_Animator;
	private AnimatorStateInfo 	stateInfo;

	void Update()
	{
		if (PlayerPrefs.HasKey(key))
		{
			if (PlayerPrefs.GetInt(key) == 0) // False
			{
				m_Animator = gameObject.GetComponent<Animator>();
				stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);

				if ( !m_Animator.IsInTransition(0) && stateInfo.IsName(fadeOutState) )
					gameObject.SetActive(false);
			}
		}
	}
}
