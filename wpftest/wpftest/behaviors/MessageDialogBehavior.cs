using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Wpftest.behaviors;

internal class MessageDialogBehavior
{
    private static readonly string PropertyName = "ShowMessage";

    public static readonly DependencyProperty ShowMessageProperty = DependencyProperty.RegisterAttached(
        PropertyName,
        typeof(bool),
        typeof(MessageDialogBehavior),
        // PropertyMetadataは他の種類のコンストラクタもある
        new PropertyMetadata(false, OnShowMessage)
    );

    public static bool GetShowMessage(DependencyObject target)
        => (bool)target.GetValue(ShowMessageProperty);

    public static void SetShowMessage(DependencyObject target, bool value)
        => target.SetValue(ShowMessageProperty, value);

    /// <summary>
    /// 値変更時のCallbackメソッド
    /// DependencyPropertyのPropertyMetadataで設定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void OnShowMessage(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var element = sender as UIElement;
        if (element == null)
        {
            return;
        }

        if ((bool)e.NewValue)
        {
            element.MouseRightButtonDown += ShowMessage;
        }
        else
        {
            element.MouseRightButtonDown -= ShowMessage;
        }
    }

    private static void ShowMessage(object sender, MouseButtonEventArgs e)
        => MessageBox.Show("Behavior Sample");
}