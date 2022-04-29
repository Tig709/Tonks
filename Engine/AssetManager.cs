using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

public class AssetManager
{
    float masterVolume;
    float soundPanning;
    float volumePan;
    public float mainVolume;

    protected ContentManager contentManager;

    public AssetManager(ContentManager content)
    {
        contentManager = content;
    }

    public Texture2D GetSprite(string assetName)
    {
        if (assetName == "")
        { 
            return null;
        }
        return contentManager.Load<Texture2D>(assetName);
    }

    void PlaySound(string assetName, float volume, float pitch, float pan)
    {
        SoundEffect snd = contentManager.Load<SoundEffect>(assetName);
        snd.Play(volume, pitch, pan);
    }

    public void PlayMusic(string assetName, bool repeat = true)
    {
        string songFileName = @"Content/" + assetName + ".ogg";
        var uri = new Uri(songFileName, UriKind.Relative);
        var song = Song.FromUri(assetName, uri);
        Microsoft.Xna.Framework.Media.MediaPlayer.IsRepeating = repeat;
        Microsoft.Xna.Framework.Media.MediaPlayer.Play(song);//.Load<Song>(assetName));
    }

    public ContentManager Content
    {
        get { return contentManager; }
    }

    public void generateSound(string assetName, float volume, float pitch, float positionX, bool stereoPanning)
    {
        if (stereoPanning)
        {
            soundPanning = (positionX - GameEnvironment.Screen.X) / (GameEnvironment.Screen.X);
            volumePan = 1 - (float)Math.Sqrt(Math.Pow(soundPanning, 2));
            PlaySound(assetName, mainVolume * volume * volumePan, pitch, 1.0f);
            PlaySound(assetName, mainVolume * volume * (1 - volumePan), pitch, -1.0f);
        }
        else
        {
            PlaySound(assetName, mainVolume * volume, pitch, 0.0f);
        }
    }
}