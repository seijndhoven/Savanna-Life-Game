using System.Drawing;

namespace SavannaLifeGame.Data
{
    interface IDrawable
    {
        void DrawTo(Graphics canvas);
    }
}