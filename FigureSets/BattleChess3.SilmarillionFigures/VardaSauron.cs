﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures
{
    public class VardaSauron : IFigureType
    {
        public static readonly VardaSauron Instance = new VardaSauron();
        public string ShownName => CurrentLocalization.Instance["VardaSauron_Name"];
        public string UnitName => $"{nameof(SilmarillionFigureGroup)}.{nameof(VardaSauron)}";
        public string GroupName => nameof(SilmarillionFigureGroup);
        public FigureTypes UnitTypes => FigureTypes.Foot;
        public FigureTypes Bonus => FigureTypes.Nothing;
        public FigureTypes AntiBonus => FigureTypes.Nothing;
        public double Attack => 100;
        public double Defence => 0;
        public bool MovingAttack => true;
        public int Cost => 5;
        public string Description => CurrentLocalization.Instance["VardaSauron_Description"];

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {1, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/VardaSauron1.png", UriKind.Absolute)},
            {2, new Uri("pack://application:,,,/BattleChess3.SilmarillionFigures;component/Images/VardaSauron2.png", UriKind.Absolute)},
        };

        public void AttackAction(Position from, Position to, Tile[] board)
            => board[to].KillFigure(board);

        private readonly Position[][] _moveChain = 
        {
            new Position[] {(-2, 1)},
            new Position[] {(-2, -1)},
            new Position[] {(2, 1)},
            new Position[] {(2, -1)},
            new Position[] {(-1, -2)},
            new Position[] {(1, -2)},
            new Position[] {(-1, 2)},
            new Position[] {(1, 2)},
        };
        public Position[][] MoveChain(Position position) => _moveChain;
        
        
        private readonly Position[][] _attackChain = 
        {
            new Position[] {(-2, 1)},
            new Position[] {(-2, -1)},
            new Position[] {(2, 1)},
            new Position[] {(2, -1)},
            new Position[] {(-1, -2)},
            new Position[] {(1, -2)},
            new Position[] {(-1, 2)},
            new Position[] {(1, 2)},
        };
        public Position[][] AttackChain(Position position) => _attackChain;
    }
}