﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BattleChess3.Figures;
using BattleChess3.Game;

namespace BattleChess3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Play.LoadMap("C:\\Users\\danys\\OneDrive\\Documents\\battle-chess-3.0\\BattleChess3\\Maps\\ClassicChess.txt");
            Play.SetBindedBoard();
        }

        /// <summary>
        /// Called when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Play.ClickedAtPosition(figure.Position);
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button) sender;
            var figure = (BaseFigure) button.CommandParameter;
            Play.MouseOn.SelFigure = figure;
            Play.MouseOn.SelPosition = figure.Position;
        }
    }
}
