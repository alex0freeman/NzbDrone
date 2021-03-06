﻿using System;
using Marr.Data;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.MediaFiles;
using NzbDrone.Common;


namespace NzbDrone.Core.Tv
{
    public class Episode : ModelBase
    {
        public const string AIR_DATE_FORMAT = "yyyy-MM-dd";

        public int TvDbEpisodeId { get; set; }
        public int SeriesId { get; set; }
        public int EpisodeFileId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string AirDate { get; set; }
        public DateTime? AirDateUtc { get; set; }

        public string Overview { get; set; }
        public Boolean Monitored { get; set; }
        public Nullable<Int32> AbsoluteEpisodeNumber { get; set; }
        public int SceneSeasonNumber { get; set; }
        public int SceneEpisodeNumber { get; set; }

        public String SeriesTitle { get; private set; }

        public LazyLoaded<EpisodeFile> EpisodeFile { get; set; }

        public Series Series { get; set; }

        public Boolean HasFile
        {
            get { return EpisodeFileId > 0; }
        }

        public override string ToString()
        {
            return string.Format("[{0}]{1}", TvDbEpisodeId, Title.NullSafe());
        }
    }
}