using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class PlayerSoundEffectsHelper : MonoBehaviour
{
	
	/// <summary>
	/// Singleton
	/// </summary>
	//public static PlayerSoundEffectsHelper Instance;
	
	public AudioClip ShootingSound;
	public AudioClip GettingHitSound;
	public AudioClip DyingSound;
	public AudioClip JumpingSound;
	public AudioClip ChangeGravitySound;
	public AudioClip MissedShotSound;
	
	void Awake()
	{
		// Register the singleton
//		if (Instance != null)
//		{
//			Debug.LogError("Multiple instances of PlayerSoundEffectsHelper!");
//		}
//		Instance = this;
	}
	
	public void MakeShootingSound()
	{
		MakeSound(ShootingSound);
	}

	public void MakeGettingHitSound()
	{
		MakeSound(GettingHitSound);
	}

	public void MakeDyingSound()
	{
		MakeSound(DyingSound);
	}

	public void MakeJumpingSound()
	{
		MakeSound(JumpingSound);
	}

	public void MakeChangeGravitySound()
	{
		MakeSound(ChangeGravitySound);
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
