﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Updater.Selector
{
    //Элемент управления, представляющий собой меню пользовательского выбора нужных IPathNode
    public partial class SelectionMenu : UserControl
    {
        public SelectionMenu()
        {
            InitializeComponent();
        }

        public string LeftButtonText 
        {
            get => LeftButton.Text;
            set => LeftButton.Text = value;
        }

        public string MiddleButtonText
        {
            get => MiddleButton.Text;
            set => MiddleButton.Text = value;
        }

        public string RightButtonText
        {
            get => RightButton.Text;
            set => RightButton.Text = value;
        }

        public event EventHandler OnLeftButtonClick
        {
            add => LeftButton.Click += value;
            remove => LeftButton.Click -= value;
        }

        public event EventHandler MiddleButtonClick
        {
            add => MiddleButton.Click += value;
            remove => MiddleButton.Click -= value;
        }

        public event EventHandler RightButtonClick
        {
            add => RightButton.Click += value;
            remove => RightButton.Click -= value;
        }

        public void SetPathNodeList<T>(List<T> nodes) where T : Base.IPathNode
        {
            nodeCheckerCollection.Clear();
            nodeCheckerCollection.AddPathNodeList(nodes);
        }

        public void SetPathNodeList<T>(ReadOnlyCollection<T> nodes) where T : Base.IPathNode
        {
            nodeCheckerCollection.Clear();
            nodeCheckerCollection.AddPathNodeList(nodes);
        }

        public ReadOnlyCollection<Base.IPathNode> GetCheckedNodes() 
        {
            return nodeCheckerCollection.GetCheckedNodes();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            nodeCheckerCollection.Left = nodeCheckerCollection.Margin.Left;
            nodeCheckerCollection.Top = nodeCheckerCollection.Margin.Top;
            nodeCheckerCollection.Width = Width - nodeCheckerCollection.Left - nodeCheckerCollection.Margin.Right;
            nodeCheckerCollection.Height = Height - MiddleButton.Margin.Bottom - MiddleButton.Height - MiddleButton.Margin.Top -
                nodeCheckerCollection.Margin.Bottom - nodeCheckerCollection.Top;

            LeftButton.Top = MiddleButton.Top = RightButton.Top = nodeCheckerCollection.Bottom + nodeCheckerCollection.Margin.Bottom + MiddleButton.Margin.Top;
            LeftButton.Left = nodeCheckerCollection.Left;
            RightButton.Left = nodeCheckerCollection.Right - RightButton.Width;
            MiddleButton.Left = Width / 2 - MiddleButton.Width / 2;
        }
    }
}
