﻿using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Abstract
{
    public interface IAlbumService : IGenericService<Album>
    {
        public List<Album> TGetAlbumsWithSinger();

        public List<Album> TGetAlbumsByArtist(int id);
    }
}
