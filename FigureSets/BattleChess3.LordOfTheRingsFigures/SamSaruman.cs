﻿using System;
using System.Collections.Generic;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class SamSaruman : IFigureType
    {
        public static readonly SamSaruman Instance = new SamSaruman();
        public string ShownName => CurrentLocalization.Instance["SamSaruman_Name"];
        public string Description => CurrentLocalization.Instance["SamSaruman_Description"];
        public string UnitName { get; } = $"{nameof(LordOfTheRingsFigureGroup)}.{nameof(SamSaruman)}";
        public FigureTypes UnitTypes { get; } = FigureTypes.Foot;
        public FigureTypes Bonus { get; } = FigureTypes.Nothing;
        public FigureTypes AntiBonus { get; } = FigureTypes.Nothing;
        public double FullHp { get; } = 100;
        public double Attack { get; } = 100;
        public double Defence { get; } = 0;
        public bool MovingAttack { get; } = true;
        public int Cost { get; } = 3;

        public Dictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>
        {
            {0, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SamSaruman1.png", UriKind.Absolute)},
            {1, new Uri("pack://application:,,,/BattleChess3.LordOfTheRingsFigures;component/Images/SamSaruman2.png", UriKind.Absolute)},
        };

        public void AttackAction(ITile from, ITile to, ITile[] board)
            => to.KillFigure(board);

        public void MoveAction(ITile from, ITile to, ITile[] board)
            => from.MoveToPosition(to.Position, board);

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
        public Position[][] GetMoveChains(Position position) => _moveChain;
        
        
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
        public Position[][] GetAttackChains(Position position) => _attackChain;
    }
}