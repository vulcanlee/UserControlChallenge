﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFUC.Models;

namespace XFUC.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();

        public MyButtonVM LeftButtonVM { get; set; } = new MyButtonVM();
        public MyButtonVM RightButtonVM { get; set; } = new MyButtonVM();

        public MainPageViewModel()
        {
            #region 進行最下方的兩個按鈕VM資料初始化
            LeftButtonVM.ButtonColor = Color.FromHex("90db94");
            LeftButtonVM.TopText = "按鈕上方文字";
            LeftButtonVM.LeftText = "左下方文字";
            LeftButtonVM.LeftTextColor = Color.Red;
            LeftButtonVM.RightText1 = "右下方1";
            LeftButtonVM.RightText1Color = Color.Green;
            LeftButtonVM.RightText1Size = 14;
            LeftButtonVM.RightText2 = "右下方2";
            LeftButtonVM.RightText2Color = Color.Blue;
            LeftButtonVM.RightText2Size = 10;

            RightButtonVM.ButtonColor = Color.FromHex("cc8695");
            RightButtonVM.TopText = "R按鈕上方文字";
            RightButtonVM.LeftText = "R左下方文字";
            RightButtonVM.LeftTextColor = Color.Red;
            RightButtonVM.RightText1 = "R右下方1";
            RightButtonVM.RightText1Color = Color.Green;
            RightButtonVM.RightText1Size = 14;
            RightButtonVM.RightText2 = "R右下方2";
            RightButtonVM.RightText2Color = Color.Blue;
            RightButtonVM.RightText2Size = 10;

            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
