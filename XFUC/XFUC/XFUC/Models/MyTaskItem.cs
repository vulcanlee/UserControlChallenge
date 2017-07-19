using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFUC.ViewModels;

namespace XFUC.Models
{
    public class MyTaskItem :INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;
        //工作名稱
        public string MyTaskName { get; set; }
        //狀態
        public string MyTaskStatus { get; set; }
        //指派日期
        public DateTime MyTaskDate { get; set; }

        /// <summary>
        /// 每筆紀錄中，要綁定於自訂按鈕所需要的該按鈕 VM
        /// </summary>
        public MyButtonVM EmbedButtonVM { get; set; } = new MyButtonVM();
        public Color ButtonBackgroundColor { get; set; }

    }
}
