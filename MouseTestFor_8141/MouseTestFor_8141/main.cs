using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace MouseTestFor_8141
{
    /// <summary>
    /// Класс основной формы приложения
    /// </summary>
    public partial class main : Form
    {
        /// <summary>
        /// Цвет заднего фона
        /// </summary>
        private Color bgColor;
        /// <summary>
        /// Флаг запуска писка
        /// </summary>
        private bool sound;
        /// <summary>
        /// Плеер для писка
        /// </summary>
        private SoundPlayer player;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public main()
        {
            //Инициаизируем компоненты
            InitializeComponent();
            //Инициализируем класс
            init();
        }

        /// <summary>
        /// Инициализируем класс
        /// </summary>
        private void init()
        {
            //Указываем цвет заднего фона
            bgColor = Color.Black;
            //Указываем, что звук не нужен
            sound = false;
            //Инициализируем плеер звуком
            player = new SoundPlayer(Properties.Resources.Windows_Default);


            //Добавляем обработчик события нажатия кнопки мыши
            this.MouseDown += Main_MouseDown;
            //Добавляем обработчик события отпускания кнопки мыши
            this.MouseUp += Main_MouseUp;
            //Добавляем обработчик нажатия кнопки на клавиатуре
            this.KeyDown += Main_KeyDown;
        }

        /// <summary>
        /// Обработчик нажатия кнопки на клавиатуре
        /// </summary>
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //Если нажат ескейп
            if (e.KeyCode == Keys.Escape)
                //Закрываем форму
                this.Close();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки мыши
        /// </summary>
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            //Выбираем значение по нажатой кнопке
            switch(e.Button)
            {
                //Левая кнопка мыши
                case MouseButtons.Left:
                    {
                        bgColor = Color.Red;
                        break;
                    }
                //Правая кнопка мыши
                case MouseButtons.Right:
                    {
                        bgColor = Color.Green;
                        break;
                    }
                //Центральная кнопка мыши
                case MouseButtons.Middle:
                    {
                        bgColor = Color.Blue;
                        break;
                    }
            }
            //Указываем, что есть нажатая кнопка
            sound = true;
            //Обновляем цвет заднего фона и текста подсказки
            updateBg();
            //Обновляем издавание звука
            updateSound();
        }

        /// <summary>
        /// Обработчик события отпускания кнопки мыши
        /// </summary>
        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            //Ставим дефолтный цвет
            bgColor = Color.Black;
            //Указываем, что кнопка была отпущена
            sound = false;
            //Обновляем цвет заднего фона и текста подсказки
            updateBg();
            //Обновляем издавание звука
            updateSound();
        }

        /// <summary>
        /// Обновляем цвет заднего фона и текста подсказки
        /// </summary>
        private void updateBg()
        {
            //Ставим цвет заднего фона
            this.BackColor = bgColor;
            //Ставим в подсказку инверсный цвет
            infoLabel.ForeColor = Color.FromArgb(255 - bgColor.R, 255 - bgColor.G, 255 - bgColor.B);
        }

        /// <summary>
        /// Обновляем издавание звука
        /// </summary>
        private void updateSound()
        {
            //Если звук должен идти
            if (sound)
                //Продолжаем проигрывание
                player.PlayLooping();
            //В противном случае
            else
                //Стопаем его
                player.Stop();
        }
    }
}
