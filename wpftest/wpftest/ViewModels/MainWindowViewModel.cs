using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using efcoretest.Models;
using Reactive.Bindings;

namespace Wpftest.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged, IMainWindowViewModel
{
    // Viewにバインドされるコマンド
    public ReactiveCommand LoadedCommand { get; } = new();

    private HttpClient client;

    // DataGridバインド用プロパティ
    public List<Customer> Customers {get;} = new List<Customer>();

    public MainWindowViewModel(HttpClient client)
    {
        this.client = client;
        LoadedCommand.Subscribe(() =>
        {
            // ここにロード時の処理を記載
            System.Console.WriteLine("Loaded !!");
        });

        // バインド確認用
        // Customers.Add(new Customer{ID=1,Address="hoge",CompanyName = "fuga", Phone ="00-99"});
    }

    public event PropertyChangedEventHandler PropertyChanged;
}