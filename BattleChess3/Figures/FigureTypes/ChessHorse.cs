﻿using System;
using BattleChess3.Figures.AttackingTypes;
using BattleChess3.Properties;

namespace BattleChess3.Figures.FigureTypes
{
    public class ChessHorse : SimpleAttackFigure, IFigure
    {
        public string UnitName => Resource.ChessHorse;
        public string UnitType => Resource.Mount;
        public string Bonus => Resource.Nothing;
        public string AntiBonus => Resource.Nothing;
        public int Attack => 100;
        public int Defence => 0;
        public bool MovingWhileAttacking => true;
        public bool LongRanged => false;
        public int Cost => 1;
        public string Description => "Chess horse is very movable unit which can easily suprise enemy.";

        public string PictureBlackPath => "ChessHorseBlack.png";
        public string PictureWhitePath => "ChessHorseWhite.png";
        public string PictureNeutralPath => "";

        private readonly Position[] _avaibleMoves =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
        };

        private readonly Position[] _avaibleAttacks =
        {
            new Position(1, 2),
            new Position(2, 1),
            new Position(-1, 2),
            new Position(-2, 1),
            new Position(1, -2),
            new Position(2, -1),
            new Position(-1, -2),
            new Position(-2, -1),
        };

        public Position[] AttackPattern => new []
        {
            new Position(0, 0),
        };

        public Func<BaseFigure, BaseFigure, bool> CanMove => (figure, moveToFigure) =>
            CanMoveSimple(figure, moveToFigure, _avaibleMoves);
        public Func<BaseFigure, BaseFigure, bool> CanAttack => (figure, attackFigure) =>
            CanAttackSimple(figure, attackFigure, _avaibleAttacks);
    }
}