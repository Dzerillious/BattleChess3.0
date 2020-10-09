﻿using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class BoardColumnViewModel : ViewModelBase
    {
        private TileViewModel[] _tiles = new TileViewModel[8];
        public TileViewModel[] Tiles
        {
            get => _tiles;
            set => Set(ref _tiles, value);
        }
    }
}