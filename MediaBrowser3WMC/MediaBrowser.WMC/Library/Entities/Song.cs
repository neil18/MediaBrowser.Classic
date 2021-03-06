﻿using System;
using MediaBrowser.Model.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaBrowser.Library.Entities
{
    /// <summary>
    /// Class Audio
    /// </summary>
    public class Song : Media, IShow, IGroupInIndex
    {
        
        /// <summary>
        /// The unknown album
        /// </summary>
        private static readonly MusicAlbum UnknownAlbum = new MusicAlbum {Name = "<Unknown>"};

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>The artist.</value>
        public string Artist { get; set; }
        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        /// <value>The album.</value>
        public string Album { get; set; }
        /// <summary>
        /// Gets or sets the album artist.
        /// </summary>
        /// <value>The album artist.</value>
        public string AlbumArtist { get; set; }

        public IContainer MainContainer { get { return (Parent as MusicAlbum) ?? RetrieveAlbum() ?? UnknownAlbum; } }
        public List<Actor> Actors { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Genres { get; set; }
        public float? ImdbRating { get; set; }
        public string MpaaRating { get; set; }
        public int? RunningTime { get; set; }
        public List<string> Studios { get; set; }
        public string AspectRatio { get; set; }
        public int? ProductionYear { get; set; }

        protected MusicAlbum RetrieveAlbum()
        {
            return !string.IsNullOrEmpty(ApiParentId) ? Kernel.Instance.MB3ApiRepository.RetrieveItem(new Guid(ApiParentId)) as MusicAlbum : null;
        }

        public override IEnumerable<string> Files
        {
            get { return new[] {Path}; }
        }
    }
}
