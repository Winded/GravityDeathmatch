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
	
	public AudioClip MissedShotSound;

	
	void Awake()
	{
		// Register the singleton
				if (Instance != null)
				{

				}
				Instance = this;
	}
	
	public void MakeMissedShotSound()
	{
		MakeSound(MissedShotSound);
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
