using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFUC.Models;
using XFUC.Repositories;

namespace XFUC.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();
        public MyTaskItem MyTaskItemSelected { get; set; }

        public MyButtonVM LeftButtonVM { get; set; } = new MyButtonVM();
        public MyButtonVM RightButtonVM { get; set; } = new MyButtonVM();


        public DelegateCommand<object> Main2ButtonCommand { get; set; }

        public DelegateCommand MyTaskItemTappedCommand { get; set; }



        public readonly IPageDialogService _dialogService;

        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            MyTaskItemTappedCommand = new DelegateCommand(async () =>
            {
                await _dialogService.DisplayAlertAsync("ListView", $"你選擇的紀錄是： {MyTaskItemSelected.MyTaskName}", "OK");
                MyTaskItemSelected = null;
            });

            #region 進行最下方的兩個按鈕VM資料初始化
            //LeftButtonVM.ButtonColor = Color.FromHex("90db94");
            LeftButtonVM.TopText = "按鈕上方文字";
            LeftButtonVM.LeftText = "左下方文字";
            LeftButtonVM.LeftTextColor = Color.Red;
            LeftButtonVM.RightText1 = "右下方1";
            LeftButtonVM.RightText1Color = Color.Green;
            LeftButtonVM.RightText1Size = 14;
            LeftButtonVM.RightText2 = "右下方2";
            LeftButtonVM.RightText2Color = Color.Blue;
            LeftButtonVM.RightText2Size = 10;
            LeftButtonVM.TopTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"上方區域 / {x.ToString()}", "OK");
            });
            LeftButtonVM.LeftTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"左下方區域 / {x.ToString()}", "OK");
            });
            LeftButtonVM.RightTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"右下方區域 / {x.ToString()}", "OK");
            });

            //RightButtonVM.ButtonColor = Color.FromHex("cc8695");
            RightButtonVM.TopText = "R按鈕上方文字";
            RightButtonVM.LeftText = "R左下方文字";
            RightButtonVM.LeftTextColor = Color.Red;
            RightButtonVM.RightText1 = "R右下方1";
            RightButtonVM.RightText1Color = Color.Green;
            RightButtonVM.RightText1Size = 14;
            RightButtonVM.RightText2 = "R右下方2";
            RightButtonVM.RightText2Color = Color.Blue;
            RightButtonVM.RightText2Size = 10;
            RightButtonVM.TopTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"上方區域 / {x.ToString()}", "OK");
            });
            RightButtonVM.LeftTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"左下方區域 / {x.ToString()}", "OK");
            });
            RightButtonVM.RightTapCommand = new DelegateCommand<object>(async x =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"右下方區域 / {x.ToString()}", "OK");
            });

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
            MyTaskItemList.Clear();
            var fooCollection = MyTaskRepository.GetMyTask();
            int fooIdx = 0;
            foreach (var item in fooCollection)
            {
                #region 進行集合清單內的每筆紀錄資料初始化
                var NewMyTaskItem = new MyTaskItem();
                NewMyTaskItem.MyTaskName = item.MyTaskName;
                NewMyTaskItem.MyTaskStatus = item.MyTaskStatus;
                NewMyTaskItem.MyTaskDate = item.MyTaskDate;
                NewMyTaskItem.ButtonBackgroundColor = Color.FromHex("#adadab");
                NewMyTaskItem.EmbedButtonVM.ButtonColor = Color.FromHex("#adadab");
                NewMyTaskItem.EmbedButtonVM.TopText = item.MyTaskName;
                NewMyTaskItem.EmbedButtonVM.LeftText = item.MyTaskStatus;
                NewMyTaskItem.EmbedButtonVM.LeftTextColor = Color.Red;
                NewMyTaskItem.EmbedButtonVM.RightText1 = "R右下方1";
                NewMyTaskItem.EmbedButtonVM.RightText1Color = Color.Green;
                NewMyTaskItem.EmbedButtonVM.RightText1Size = 14;
                NewMyTaskItem.EmbedButtonVM.RightText2 = item.MyTaskDate.ToString("yyyy-MM-dd");
                NewMyTaskItem.EmbedButtonVM.RightText2Color = Color.Blue;
                NewMyTaskItem.EmbedButtonVM.RightText2Size = 10;
                NewMyTaskItem.EmbedButtonVM.TopTapCommand = new DelegateCommand<object>(async x =>
                {
                    var fooObj = x as MyTaskItem;
                    await _dialogService.DisplayAlertAsync("ListView 的項目點擊", $"上方區域 / {fooObj.MyTaskName}", "OK");
                });
                NewMyTaskItem.EmbedButtonVM.LeftTapCommand = new DelegateCommand<object>(async x =>
                {
                    var fooObj = x as MyTaskItem;
                    await _dialogService.DisplayAlertAsync("ListView 的項目點擊", $"左下方區域 / {fooObj.MyTaskName}", "OK");
                });
                NewMyTaskItem.EmbedButtonVM.RightTapCommand = new DelegateCommand<object>(async x =>
                {
                    var fooObj = x as MyTaskItem;
                    await _dialogService.DisplayAlertAsync("ListView 的項目點擊", $"右下方區域 / {fooObj.MyTaskName}", "OK");
                });
                #endregion

                #region 依據記錄狀態，調整按鈕狀態
                if (fooIdx % 7 == 0)
                {
                    NewMyTaskItem.EmbedButtonVM.ButtonColor = Color.FromHex("#cddb53");
                }
                else if (fooIdx % 3 == 0)
                {
                    NewMyTaskItem.EmbedButtonVM.ButtonColor = Color.FromHex("#a7e27c");
                }


                if (fooIdx % 3 == 0)
                {
                    NewMyTaskItem.EmbedButtonVM.LeftTextColor = Color.FromHex("#8c5ca5");
                }
                #endregion

                MyTaskItemList.Add(NewMyTaskItem);
                fooIdx++;
            }
        }
    }
}
