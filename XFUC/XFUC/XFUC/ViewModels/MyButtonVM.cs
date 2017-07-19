using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFUC.ViewModels
{
    public class MyButtonVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // 該按鈕的背景顏色
        public Color ButtonColor { get; set; }

        // 第1Row 的最上方文字
        public string TopText { get; set; }

        // Row=1 Column=0 的左下方格子的資料
        public string LeftText { get; set; }
        public Color LeftTextColor { get; set; }

        // Row=1 Column=1 的右下方格子的資料
        public string RightText1 { get; set; }
        public Color RightText1Color { get; set; }
        public double RightText1Size { get; set; }
        public string RightText2 { get; set; }
        public Color RightText2Color { get; set; }
        public double RightText2Size { get; set; }


        public DelegateCommand<object> TopTapCommand { get; set; }
        public DelegateCommand<object> LeftTapCommand { get; set; }
        public DelegateCommand<object> RightTapCommand { get; set; }

    }
}
