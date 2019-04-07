using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCopy
{
    [Serializable()]
    public class MusicCollection : ICloneable
    {
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public List<MusicFile> MusicFiles { get; set; }

        [Obsolete("Thic c'tor  is meant for the XML Serialization library.")]
        public MusicCollection()
        {
            MusicFiles = new List<MusicFile>();
        }

        public MusicCollection(string deviceName, string deviceType) : base() {
            DeviceName = deviceName;
            DeviceType = deviceType;
            MusicFiles = new List<MusicFile>();
        }

        public void AddMusic( MusicFile file)
        {
            MusicFiles.Add(file);
        }

        public object Clone() {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;

          //  return this.MemberwiseClone(); // For Shallow Copy
        }
    }

    [Serializable]
    public class MusicFile
    {
        public string Name { get; set; }
        public General General { get; set; }
        public Description Description { get; set; }

        [Obsolete("Do not use this c'tor")]
        public MusicFile()
        {
            General = new General();
            Description = new Description();
        }

        public MusicFile(string name)
        {
            Name = name;
            General = new General();
            Description = new Description();
        }
    }

    [Serializable]
    public class General
    {
        public string TypeOfFile { get; set; }
        public string OpensWith { get; set; }
        public string Location { get; set; }
        public long Size { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Accessed { get; set; }
        public bool ReadOnly { get; set; }
        public bool Hidden { get; set; }

        [Obsolete("Do not use this c'tor")]
        public General()
        {
        }

        public General(string typeOfFile)
        {
            TypeOfFile = typeOfFile;
        }
    }

    [Serializable]
    public class Description{
        public string FileName { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public short Rating { get; set; }
        public string Comments { get; set; }
        public List<string> ContributingArtists { get; set; }
        public List<string> AlbumArtists { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        [Obsolete("Do not use this c'tor")]
        public Description()
        {
            ContributingArtists = new List<string>();
            AlbumArtists = new List<string>();
        }

        public Description(string fileName)
        {
            FileName = fileName;
            ContributingArtists = new List<string>();
            AlbumArtists = new List<string>();
        }
    }
}
