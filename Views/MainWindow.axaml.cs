using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;

namespace ProjectAvaloniaTest.Views;

public partial class MainWindow : Window
{
    private DispatcherTimer _timer;
    private TimeSpan timeRemaining;
    private bool isRunning;

    public MainWindow()
    {
        InitializeComponent();
        timeRemaining = TimeSpan.FromMinutes(25);
        UpdateTExt();

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += Timer_Tick;
    }

    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        if (isRunning)
        {
            _timer.Stop();
            isRunning = false;
            StartButton.Content = "Iniciar";
        }
        else
        {
            _timer.Start();
            isRunning = true;
            StartButton.Content = "Pausar";
        }
    }

    private void ResetButton_Click(object? sender, RoutedEventArgs e)
    {
        _timer.Stop();
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
            _timer.Stop();
            isRunning = false;
            TimerText.Text = "Descanso!";
        }
    }

    private void UpdateTExt()
    {
        TimerText.Text = timeRemaining.ToString(@"mm\:ss");
    }
}
