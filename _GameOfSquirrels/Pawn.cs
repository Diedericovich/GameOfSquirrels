using System.ComponentModel;
using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public class Pawn : IPawn
    {
        private int _locationX;
        public int LastRoll { get; set; }
        public bool GoingUp { get; set; }
        public bool GoingRight { get; set; }
        public bool IsReversed { get; set; }
        public bool IsSkippingNextTurn { get; set; }
        public int TurnsToSkip { get; set; }

        public int LocationX
        {
            get { return _locationX; }
            set
            {
                _locationX = value;
                if (_locationX > 7)
                {
                    _locationX = 6;
                }
                if (_locationX < 0)
                {
                    _locationX = 0;
                }
                OnPropertyChanged("LocationX");
            }
        }

        private int _locationY;

        public int LocationY
        {
            get { return _locationY; }
            set
            {
                _locationY = value;
                if (_locationY > 7)
                {
                    _locationY = 6;
                }
                if (_locationY < 0)
                {
                    _locationY = 0;
                }
                OnPropertyChanged("LocationY");
            }
        }
        public string Image { get; set; }
        public double Size { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Pawn(int locationX, int locationY)
        {
            GoingRight = true;
            IsReversed = false;
            IsSkippingNextTurn = false;
            TurnsToSkip = 0;
            LocationX = locationX;
            LocationY = locationY;
            Size = 55;
            Image = "https://i.ibb.co/YtMBPrm/squirrelblue.png";
        }

        public void Move(int x, int y)
        {
            LocationX += x;
            LocationY += y;
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}