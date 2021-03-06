﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFUC.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyButtonProp : ContentView
    {
        #region ButtonBackgroundColor 可綁定屬性 BindableProperty
        //在這裡加入一個按鈕背景顏色可綁定屬性定義，這樣，開發者就可以在 XAML 中，指定這個按鈕所需要的背景顏色
        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create("ButtonBackgroundColor", // 屬性名稱 
                typeof(Color), // 回傳類型 
                typeof(MyButton), // 宣告類型 
                Color.White, // 預設值 
                propertyChanged: OnButtonBackgroundColorChanged  // 屬性值異動時，要執行的事件委派方法
            );

        public Color ButtonBackgroundColor
        {
            set
            {
                SetValue(ButtonBackgroundColorProperty, value);
            }
            get
            {
                return (Color)GetValue(ButtonBackgroundColorProperty);
            }
        }

        private static void OnButtonBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEle = bindable as MyButtonProp;
            if (fooEle != null)
            {
                if (newValue != null)
                {
                    var fooObj = (Color)newValue;
                    fooEle.ButtonBackgroundBoxView.Color = fooObj;
                }
            }
        }

        #endregion

        #region ButtonContent 可綁定屬性 BindableProperty
        //這個可綁定屬性，用於儲存在 XAML 所綁定的當時物件
        public static readonly BindableProperty ButtonContentProperty =
            BindableProperty.Create("ButtonContent", // 屬性名稱 
                typeof(object), // 回傳類型 
                typeof(MyButton), // 宣告類型 
                null, // 預設值 
                propertyChanged: OnButtonContentChanged  // 屬性值異動時，要執行的事件委派方法
            );

        public object ButtonContent
        {
            set
            {
                SetValue(ButtonContentProperty, value);
            }
            get
            {
                return (object)GetValue(ButtonContentProperty);
            }
        }

        private static void OnButtonContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEle = bindable as MyButtonProp;
            if(fooEle!=null)
            {
                fooEle.CurrentContent = newValue;
            }
        }

        #endregion

        public object CurrentContent { get; set; }

        public MyButtonProp()
        {
            InitializeComponent();

        }
    }
}