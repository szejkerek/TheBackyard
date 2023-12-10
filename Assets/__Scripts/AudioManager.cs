using UnityEngine;

/// <summary>
/// Manages audio in the game, including global music and sound effects.
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    [Header("AudioSources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [Header("AudioSoundData")]
    [SerializeField] private SFXLib _sfxLib;
    [SerializeField] private MusicLib _musicLib;

    /// <summary>
    /// Gets the SFX library containing sound effect clips.
    /// </summary>
    public SFXLib SFXLib { get => _sfxLib; }

    /// <summary>
    /// Gets the music library containing music clips.
    /// </summary>
    public MusicLib MusicLib { get => _musicLib; }

    /// <summary>
    /// Plays a global music clip with looping.
    /// </summary>
    /// <param name="clip">The music clip to play.</param>
    public void PlayGlobalMusic(AudioClip clip)
    {
        // Stop the currently playing music.
        if (_musicSource.isPlaying)
        {
            _musicSource.Stop();
        }

        // Set the new music clip, set looping, and play.
        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    /// <summary>
    /// Stops the currently playing global music.
    /// </summary>
    public void StopGlobalSound()
    {
        _musicSource.Stop();
    }

    /// <summary>
    /// Plays a global sound effect with optional random pitch.
    /// </summary>
    /// <param name="clip">The sound effect clip to play.</param>
    /// <param name="vol">The volume of the sound effect.</param>
    /// <param name="randomPitch">Whether to use a random pitch for the sound effect.</param>
    public void PlayGlobalSound(AudioClip clip, float vol = 1, bool randomPitch = false)
    {
        // Optionally set a random pitch for the sound effect.
        if (randomPitch)
            _soundSource.pitch = Random.Range(0.8f, 1.2f);

        // Play the sound effect at the specified volume.
        _soundSource.PlayOneShot(clip, vol);

        // Reset the pitch if random pitch was used.
        if (randomPitch)
            _soundSource.pitch = 1;
    }
}