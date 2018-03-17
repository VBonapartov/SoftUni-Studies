using _04._OnlineRadioDatabase.Exceptions;

public class Song
{
    private const int ArtistMinLength = 3;
    private const int ArtistMaxLength = 20;
    private const int NameMinLength = 3;
    private const int NameMaxLength = 30;
    private const int MinutesMin = 0;
    private const int MinutesMax = 14;
    private const int SecondsMin = 0;
    private const int SecondsMax = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get
        {
            return this.artistName;
        }

        private set
        {
            if (value.Length < ArtistMinLength || value.Length > ArtistMaxLength)
            {
                //throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                throw new InvalidArtistNameException(ArtistMinLength, ArtistMaxLength);
            }

            this.artistName = value;
        }
    }

    public string SongName
    {
        get
        {
            return this.songName;
        }

        private set
        {
            if (value.Length < NameMinLength || value.Length > NameMaxLength)
            {
                //throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                throw new InvalidSongNameException(NameMinLength, NameMaxLength);
            }

            this.songName = value;
        }
    }

    public int Minutes
    {
        get
        {
            return this.minutes;
        }

        private set
        {
            if (value < MinutesMin || value > MinutesMax)
            {
                //throw new ArgumentException("Song minutes should be between 0 and 14.");
                throw new InvalidSongMinutesException(MinutesMin, MinutesMax);
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get
        {
            return this.seconds;
        }

        private set
        {
            if (value < SecondsMin || value > SecondsMax)
            {
                //throw new ArgumentException("Song seconds should be between 0 and 59.");
                throw new InvalidSongSecondsException(SecondsMin, SecondsMax);
            }

            this.seconds = value;
        }
    }

    public int CalculateSongLength()
    {
        int totalSeconds = (this.Minutes * 60) + this.Seconds;
        return totalSeconds;
    }
}