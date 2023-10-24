using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicSmth
{
    public partial class Concerts
    {
        public SolidColorBrush TimeConcert //Свойство возвращает фиолетовый цвет разных оттенков, в зависимости от количества дней до концерта
        {
            get
            {
                DateTime today = DateTime.Now;
                TimeSpan diff = (DateTime)Date - today; 
                if(diff.Days >= 200)
                {
                    return new SolidColorBrush(Color.FromRgb(234, 126, 173));
                }
                else if(diff.Days < 200 && diff.Days>=100)
                {
                    return new SolidColorBrush(Color.FromRgb(234, 86, 151));
                }
                else if (diff.Days < 100)
                {
                    return new SolidColorBrush(Color.FromRgb(214, 33, 112));
                }
                else
                {
                    return Brushes.White;
                }
            }
        }

        public string CheckDisc //Свойство проверяет наличие описания и возвращает заглушку, если его нет
        {
            get
            {
                if(Discription==null)
                {
                    return "Нет описания :(";
                }
                else
                {
                    return Discription;
                }
            }
        }

        public string Place
        {
            get
            {
                return "Концертная площадка "+ Places.Place;
            }
        }
    }
}
