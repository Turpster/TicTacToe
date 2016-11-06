using System.Windows.Media;
using TicTacToe.Images;

namespace TickTackToe.Model
{
    public class Place
    {
        private IconType? type;

        public Place()
        {
            IsEmpty = true;
        }

        public int Id { get; set; }

        public ImageSource Image { get; private set; }

        public bool IsEmpty { get; set; }

        public IconType? Type
        {
            get { return type; }
            set
            {
                type = value;
                if (type == IconType.Circle) Image = Images.circle.ConvertToBitmpImage();
                else if (type == IconType.Cross) Image = Images.cross.ConvertToBitmpImage();
                else Image = null;
            }
        }

    }
}
