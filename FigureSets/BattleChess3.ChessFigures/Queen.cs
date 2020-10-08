﻿using System;
using BattleChess3.ChessFigures.Localization;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;

namespace BattleChess3.ChessFigures
{
    public class Queen : IFigureType
    {
        public static readonly Queen Instance = new Queen();
        public string ShownName => CurrentLocalization.Instance["Queen_Name"];
        public string UnitName => $"{nameof(ChessFigureGroup)}.{nameof(Queen)}";
        public string GroupName => nameof(ChessFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Special;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 9;
        public string Description => CurrentLocalization.Instance["Queen_Description"];
        public Position[] AttackPattern => Array.Empty<Position>();
        public bool CanMove(Tile tile, Tile[] board) => false;
        public bool CanAttack(Tile tile, Tile[] board) => false;
    }
}