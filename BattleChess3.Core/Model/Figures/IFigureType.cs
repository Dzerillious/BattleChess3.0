﻿using System;
using System.Collections.Generic;

namespace BattleChess3.Core.Model.Figures
{
    public interface IFigureType
    {
        /// <summary>
        /// Name shown in menus and helps
        /// </summary>
        string ShownName { get; }

        /// <summary>
        /// Gets description of unit
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets name of unit
        /// </summary>
        string UnitName { get; }
        
        /// <summary>
        /// Gets full hp of unit
        /// </summary>
        double FullHp { get; }
        
        /// <summary>
        /// Gets attack
        /// </summary>
        double Attack { get; }

        /// <summary>
        /// Gets defence
        /// </summary>
        double Defence { get; }

        /// <summary>
        /// Gets type of unit
        /// </summary>
        FigureTypes UnitTypes { get; }

        /// <summary>
        /// Gets bonus against type of unit
        /// </summary>
        FigureTypes Bonus { get; }

        /// <summary>
        /// Gets anti-bonus against type of unit
        /// </summary>
        FigureTypes AntiBonus { get; }

        /// <summary>
        /// Gets if move while attacking
        /// </summary>
        bool MovingAttack { get; }

        /// <summary>
        /// Gets cost of unit
        /// </summary>
        int Cost { get; }
        
        /// <summary>
        /// Images of player with id
        /// </summary>
        Dictionary<int, Uri> ImageUris { get; }

        /// <summary>
        /// Attack action
        /// </summary>
        void AttackAction(ITile from, ITile to, ITile[] board);

        /// <summary>
        /// Move action
        /// </summary>
        void MoveAction(ITile from, ITile to, ITile[] board);

        /// <summary>
        /// Chain of positions of move (if can go at first position of chain, check next one)
        /// </summary>
        Position[][] GetMoveChains(Position from);

        /// <summary>
        /// Chain of positions of move (if can attack first position of chain, check next one)
        /// </summary>
        Position[][] GetAttackChains(Position from);
    }
}