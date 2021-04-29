using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tic_Tac_Toe1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        Grid grid = new Grid();
        Button[,] buttons = new Button[3, 3];
        int playerTurn = 1;
        private string scoreT;
        public string ScoreT
        {
            get { return scoreT; }
            set
            {
                scoreT = value;
                OnPropertyChanged(nameof(ScoreT));
            }
        }
        public Game()
        {
            InitializeComponent();
            BindingContext = this;

            ScoreT = $"{Score.x}     { Score.n}";
        }
        private void Bt_SizeF(object sender, EventArgs e) => Addingbtn(4);
        private void Bt_SizeTh(object sender, EventArgs e) => Addingbtn(3);
        public void Addingbtn(int size)
        {
            grid.Children.Clear();
            buttons = new Button[size, size];
            Forbuttons.Children.Clear();
            for (int i = 0; i < buttons.GetLength(1); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    
                    buttons[i, j].FontSize = 20;
                    buttons[i, j].Clicked += CheckSt;

                    grid.Children.Add(buttons[i, j], i, j);
                }
            }
            Forbuttons.Children.Add(grid);
            playerTurn = 1;
        }
        private void CheckSt(object sender, EventArgs e)
        {
            Button button = (Button)sender;
                button.Text = playerTurn %2== 0 ? "O" : "x";
            playerTurn = playerTurn == 1 ? 2 : 1;
            button.IsEnabled = false;
            Wincheck(buttons.GetLength(1));
        }
        public void  Wincheck(int size)
        {
            switch (size)
            {
                case 3:
                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text){
                            if(WhoW(buttons[i, 0], 3))
                                return;
                        }
                        if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text){
                            if(WhoW(buttons[0, i], 3))
                                return;
                        }
                    }
                    if (buttons[0, 0].Text == buttons[1, 1].Text&& buttons[1, 1].Text== buttons[2, 2].Text){
                        if(WhoW(buttons[0, 0], 3))
                            return;
                    }
                    if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text)
                    {
                        if(WhoW(buttons[0, 2], 3))
                            return;
                    }
                    break;
                case 4:
                    for (int i = 0; i < size; i++)
                    {
                        if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text&& buttons[i, 2].Text== buttons[i, 3].Text){
                            if (WhoW(buttons[i, 0], 4))
                                return;
                        }
                        if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text&& buttons[2, i].Text== buttons[3, i].Text){
                            if (WhoW(buttons[0, i], 4))
                                return;
                        }
                    }
                    if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text&& buttons[2, 2].Text== buttons[3, 3].Text)
                    {
                        if(WhoW(buttons[0, 0], 4))
                            return;
                    }
                    if (buttons[0, 3].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[3, 0].Text)
                    {
                        if (WhoW(buttons[0, 3], 4))
                            return;
                    }
                    break;
            }
            IsTie();
        }

        private void Refresh_sc(object sender, EventArgs e)
        {
            Score.n = 0;
            Score.x = 0;
            ScoreT = $"{Score.x}     { Score.n}";
        }
        public async void IsTie()
        {
            for (int i = 0; i < buttons.GetLength(1); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i,j].IsEnabled!=false)
                        return;
                }
            }
                await DisplayAlert("Сообщение", "Ничья", "ОK");
        }
        public bool WhoW(Button button, int size)
        {
            if (button.Text == "x")
            {
                DisplayAlert("Сообщение", "Победили крестики", "ОK");
                Score.x++;
                ScoreT = $"{Score.x}     { Score.n}";
                Addingbtn(size);
                return true;
            }
            else if (button.Text == "O")
            {
                DisplayAlert("Сообщение", "Победили нолики", "ОK");
                Score.n++;
                ScoreT = $"{Score.x}     { Score.n}";
                Addingbtn(size);
                return true;
            }
            return false;
        }
    }
}