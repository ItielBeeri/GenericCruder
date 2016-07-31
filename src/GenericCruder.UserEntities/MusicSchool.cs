using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;

namespace ETL.GenericCruder.UserEntities.MusicSchool
{
    public class MusicSchoolUser : IHasId
    {
        public int MusicSchoolUserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        int IHasId.Id
        {
            get
            {
                return MusicSchoolUserId;
            }
            set
            {
                MusicSchoolUserId = value;
            }
        }
    }

    public class Song : IHasId
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? MusicSchoolUserId { get; set; }
        public virtual ICollection<SongRow> Content { get; set; }

        int IHasId.Id
        {
            get
            {
                return SongId;
            }
            set
            {
                SongId = value;
            }
        }
    }

    public class SongRow : IHasId
    {
        public int SongRowId { get; set; }
        public string Accords { get; set; }
        public string Lyrics { get; set; }
        public int? SongId { get; set; }

        int IHasId.Id
        {
            get
            {
                return SongRowId;
            }
            set
            {
                SongRowId = value;
            }
        }
    }
}