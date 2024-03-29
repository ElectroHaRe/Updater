﻿using System;
using Updater.Base;
using Updater.Selector;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Updater
{
    //Класс элемента управления, представляющий собой главный контроллер меню (объединяет все менюшки просто системой)
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
            UpdateNodes();
            ActivateMenu(Menu.selection);
            selectionMenu.LeftButtonIsActive = false;
        }
                
        private List<NodeCheckerBox> checkedBoxes = new List<NodeCheckerBox>();

        //перечисление возможных меню
        private enum Menu : byte { selection, config, update }

        //стандартный путь конфига
        private readonly string ConfigFilePath = @".\Config.xml";

        private List<IPathNode> nodes = new List<IPathNode>();

        //Перезагружает конфиг
        private void UpdateNodes()
        {
            nodes = PathNodeSerializer.Load(ConfigFilePath);
            selectionMenu.LeftButtonIsActive = false;
            checkedBoxes.Clear();
        }

        //Активирует выбранное меню
        private void ActivateMenu(Menu menu)
        {
            switch (menu)
            {
                case Menu.selection:
                    selectionMenu.SetPathNodeList(nodes);
                    selectionMenu.Show();
                    configMenu.Hide();
                    updateMenu.Hide();
                    break;
                case Menu.config:
                    selectionMenu.Hide();
                    configMenu.SetPathNodeList(nodes);
                    configMenu.Show();
                    updateMenu.Hide();
                    break;
                case Menu.update:
                    selectionMenu.Hide();
                    configMenu.Hide();
                    updateMenu.SetPathNodeList(selectionMenu.GetCheckedNodes());
                    updateMenu.Show();
                    updateMenu.Start();
                    break;
            }
        }

        //Обработчик Нажатия кнопки Update
        private void OnUpdateClick(object sender, EventArgs e)
        {
            updateMenu.Clear();
            ActivateMenu(Menu.update);
        }

        //Обработчик события нажатия кнопки Config
        private void OnConfigClick(object sender, EventArgs e)
        {
            ActivateMenu(Menu.config);
        }

        //Обработчик события нажатия кнопки Back
        private void OnBackClick(object sender, EventArgs e)
        {
            UpdateNodes();
            ActivateMenu(Menu.selection);
        }

        //Обработчик события нажатия кнопки Save
        private void OnSaveClick(object sender, EventArgs e)
        {
            PathNodeSerializer.Save(configMenu.GetPathNodeList(), ConfigFilePath);
            OnBackClick(null, null);
        }

        //Обработчик события нажатия кнопки Exit
        private void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Обработчик события изменения размеров элемента управления
        private void OnSizeChanged(object sender, EventArgs e)
        {
            updateMenu.Width = Width;
        }

        private void OnCheckerChanged(object sender, EventArgs e)
        {
            var temp = sender as NodeCheckerBox;

            if (temp.Checked)
                checkedBoxes.Add(temp);
            else
                checkedBoxes.Remove(temp);

            selectionMenu.LeftButtonIsActive = checkedBoxes.Count > 0 ? true : false;
        }
    }
}
