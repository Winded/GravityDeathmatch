using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class GeneralSoundEffectsHelper : MonoBehaviour
{
	
	/// <summary>
	/// Singleton
	/// </summary>
	public static GeneralSoundEffectsHelper Instance;
	
	public AudioClip NameOfSound;

	
	void Awake()
	{
		// Register the singleton
				if (Instance != null)
				{
					Debug.LogError("Multiple instances of PlayerSoundEffectsHelper!");
				}
				Instance = this;
	}
	
	public void MakeNameOfSound()
	{
		MakeSound(NameOfSound);
	}
	
		
	
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
