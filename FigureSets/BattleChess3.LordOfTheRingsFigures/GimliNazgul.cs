﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class GimliNazgul : IFigureType
    {
        public static readonly GimliNazgul Instance = new GimliNazgul();
        public string ShownName => CurrentLocalization.Instance["GimliNazgul_Name"];
        public string UnitName => $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(GimliNazgul)}";
        public string GroupName => nameof(LordOfTheRingsFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => CurrentLocalization.Instance["GimliNazgul_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/GimliNazgul1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/GimliNazgul2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
            new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
            new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
            new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
        };
        public Position[][] MoveChain(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (7, 0)}, 
            new Position[] {(0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7)},
            new Position[] {(-1, 0), (-2, 0), (-3, 0), (-4, 0), (-5, 0), (-6, 0), (-7, 0)},
            new Position[] {(0, -1), (0, -2), (0, -3), (0, -4), (0, -5), (0, -6), (0, -7)}
        };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}