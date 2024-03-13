﻿using BetterGenshinImpact.ViewModel.Windows;
using System;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace BetterGenshinImpact.View.Windows;

public partial class AutoPickMonoDialog : FluentWindow
{
    public AutoPickMonoViewModel ViewModel { get; }

    public AutoPickMonoDialog(string path)
    {
        DataContext = ViewModel = new(path);
        InitializeComponent();

        // Manual MVVM binding
        JsonCodeBox.TextChanged += (_, _) => ViewModel.JsonText = JsonCodeBox.Text;
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        TryApplySystemBackdrop();
    }

    private void TryApplySystemBackdrop()
    {
        if (WindowBackdrop.IsSupported(WindowBackdropType.Mica))
        {
            Background = new SolidColorBrush(Colors.Transparent);
            WindowBackdrop.ApplyBackdrop(this, WindowBackdropType.Mica);
            return;
        }

        if (WindowBackdrop.IsSupported(WindowBackdropType.Tabbed))
        {
            Background = new SolidColorBrush(Colors.Transparent);
            WindowBackdrop.ApplyBackdrop(this, WindowBackdropType.Tabbed);
        }
    }
}