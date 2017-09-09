﻿using BattleChess3.Figures;
using BattleChess3.Properties;

namespace BattleChess3.Game
{
    /// <summary>
    /// Partial class of Session for highlighting tiles
    /// </summary>
    public static partial class Session
    {
        /// <summary>
        /// Recalculates Highlighting and sets figure properties Highlight
        /// </summary>
        public static void HighlightTiles()
        {
            if (Selected.SelPosition == null)
            {
                for (var i = 0; i < 64; i++)
                {
                    Board[i / 8][i % 8].Highlighted = StaticResources.NotHighlighted;
                }
            }
            else
            {
                for (var i = 0; i < 64; i++)
                {
                    var position = new Position(i / 8, i % 8);
                    var figure = GetFigureAtPosition(position);
                    figure.Highlighted = SelectedStyle.ApplicationStyle.ChessTile;
                    if (Selected.SelFigure.Color == WhooseTurn)
                    {
                        HighlightDangered(figure);
                        HighlightCanGo(figure);
                    }
                }
                HighlightSelected();
                HighlightMouseOn();
            }
        }

        public static void HighlightDangered(BaseFigure figure)
        {
            if (figure.Color != Selected.SelFigure.Color && Selected.SelFigure.CanAttack(figure))
            {
                figure.Highlighted = SelectedStyle.ApplicationStyle.DangeredChessTile;
            }
        }

        public static void HighlightCanGo(BaseFigure figure)
        {
            if (Selected.SelFigure.CanMove(figure))
            {
                figure.Highlighted = SelectedStyle.ApplicationStyle.CanGoChessTile;
            }
        }

        public static void HighlightSelected()
        {
            Selected.SelFigure.Highlighted = SelectedStyle.ApplicationStyle.SelectedChessTile;
        }

        public static void HighlightMouseOn()
        {
            MouseOn.SelFigure.Highlighted = SelectedStyle.ApplicationStyle.SelectedChessTile;
        }
    }
}