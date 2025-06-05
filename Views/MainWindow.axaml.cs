using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;

namespace ProjectAvaloniaTest.Views;

// Doc Util
// https://learn.microsoft.com/en-us/dotnet/api/system.timespan.tostring?view=net-7.0#System_TimeSpan_ToString_System_String_
// https://api-docs.avaloniaui.net/docs/T_Avalonia_Threading_DispatcherTimer
// https://api-docs.avaloniaui.net/docs/T_Avalonia_Interactivity_RoutedEventArgs

public partial class MainWindow : Window
{
    private DispatcherTimer timer;
    private TimeSpan timeRemaining;
    private bool isRunning;

    public MainWindow()
    {
        InitializeComponent();
        timeRemaining = TimeSpan.FromMinutes(25);
        UpdateTExt();

        timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        timer.Tick += Timer_Tick;
    }

    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        if (isRunning)
        {
            timer.Stop();
            isRunning = false;
            StartButton.Content = "Iniciar";
        }
        else
        {
            timer.Start();
            isRunning = true;
            StartButton.Content = "Pausar";
        }
    }

    private void ResetButton_Click(object? sender, RoutedEventArgs e)
    {
        timer.Stop();
        timeRemaining = TimeSpan.FromMinutes(25);
        isRunning = false;
        UpdateTExt();
        StartButton.Content = "Iniciar";
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (timeRemaining.TotalSeconds > 0)
        {
            timeRemaining = timeRemaining.Subtract(TimeSpan.FromSeconds(1));
            UpdateTExt();
        }
        else
        {
            timer.Stop();
            isRunning = false;
            TimerText.Text = "Descanso!";
        }
    }

    private void UpdateTExt()
    {
        TimerText.Text = timeRemaining.ToString(@"mm\:ss");
    }
}
