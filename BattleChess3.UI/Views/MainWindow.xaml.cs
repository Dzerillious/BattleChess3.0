﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BattleChess3.UI.Game;
using BattleChess3.UI.Properties;
using BattleChess3.UI.ViewModel;
using FontFamily = System.Windows.Media.FontFamily;

namespace BattleChess3.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static MapsHolder MapsHolder = new MapsHolder();

        /// <summary>
        /// Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MapsHolder.Maps = MapsHolder.GetMaps();
            TextElement.FontFamilyProperty.OverrideMetadata(
                typeof(TextElement),
                new FrameworkPropertyMetadata(
                    new FontFamily("Britannic Bold")));

            TextBlock.FontFamilyProperty.OverrideMetadata(
                typeof(TextBlock),
                new FrameworkPropertyMetadata(
                    new FontFamily("Britannic Bold")));
        }

        /// <summary>
        /// Called when new game is clicked
        /// </summary>
        private void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            PlayButtonSound();
            if (Session.SelectedMap.Figure != null)
            {
                GameTab.IsEnabled = true;
                Session.LoadMap();
                Session.SetBindedBoard();
                GameTab.IsSelected = true;
            }
        }

        private void OnOptionsClick(object sender, RoutedEventArgs e)
        {
            PlayButtonSound();
            OptionsTab.IsSelected = true;
        }

        private void OnDeleteMapClick(object sender, RoutedEventArgs e)
        {
            PlayButtonSound();
            if (Session.SelectedMap.Name != null)
            {
                File.Delete(Session.SelectedMap.Name);
            }
            MapsHolder.Maps = MapsHolder.GetMaps();
        }

        private void OnQuitApplicationClick(object sender, RoutedEventArgs e)
        {
            PlayButtonSound();
            Close();
        }

        private bool _played = false;

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (_played)
                PlayButtonSound();
            _played = true;
        }

        private void OnSaveMapClick(object sender, RoutedEventArgs e)
        {
            PlayButtonSound();
            if (Session.Board.All(column => column != null))
            {
                var rnd = new Random();
                var randomName = rnd.Next(0, int.MaxValue).ToString();
                SaveMap(randomName);
                SetMapToMapsHolder(randomName);
            }
        }

        /// <summary>
        /// Saves map to MapsHolder. It can be immediately played and it is actualized in view
        /// </summary>
        /// <param name="randomName">Previously generated randomName</param>
        private static void SetMapToMapsHolder(string randomName)
        {
            var newMap = new Map();
            newMap.Name = Directory.GetCurrentDirectory() + $"\\Maps\\{randomName}.txt";
            var tiles = new string[8][];
            for (var i = 0; i < 8; i++)
            {
                tiles[i] = new string[8];
            }
            var lines = File.ReadAllLines(newMap.Name);
            for (var i = 0; i < 8; i++)
            {
                var tile = lines[7 - i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    tiles[i][j] = tile[j];
                }
            }
            newMap.Figure = tiles;
            newMap.StartingPlayer = Session.WhooseTurn;
            newMap.PreviewPath = Directory.GetCurrentDirectory() + $"\\MapsPreviews\\{randomName}.png";
            MapsHolder.Maps.FindAll(x => x.Name == newMap.Name).FirstOrDefault().StartingPlayer = newMap.StartingPlayer;
            MapsHolder.Maps = MapsHolder.GetMaps();
        }

        /// <summary>
        /// Saves map for future map loading with picture preview
        /// </summary>
        /// <param name="randomName">Previously generated randomName</param>
        private void SaveMap(string randomName)
        {
            SaveToPng(BoardControl, $"MapsPreviews\\{randomName}.png");
            var boardStrings = new string[10];
            for (var i = 0; i < 8; i++)
            {
                boardStrings[i] = "";
                for (var j = 0; j < 8; j++)
                {
                    var figure = Session.BoardColumns[j].ColumnFigures[7 - i];
                    if (figure.PlayerNumber == 0)
                    {
                        boardStrings[i] += figure.FigureType.UnitName + " ";
                    }
                    else
                    {
                        boardStrings[i] += figure.PlayerNumber + figure.FigureType.UnitName + " ";
                    }
                }
            }
            boardStrings[8] = $"MapsPreviews\\{randomName}.png";
            boardStrings[9] = Session.WhooseTurn.ToString();
            using (var outputFile = new StreamWriter(Directory.GetCurrentDirectory() + $"\\Maps\\{randomName}.txt"))
            {
                foreach (var line in boardStrings)
                {
                    outputFile.WriteLine(line);
                }
            }
            MapsHolder.Maps = MapsHolder.GetMaps();
        }

        public void PlayButtonSound()
        {
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer("Resources/Sounds/ButtonSound.wav");
            snd.Play();
        }

        private void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, encoder);
        }

        private void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }
    }
}