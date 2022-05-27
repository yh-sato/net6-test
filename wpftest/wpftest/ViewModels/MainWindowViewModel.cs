using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using efcoretest.Models;
using Reactive.Bindings;

namespace Wpftest.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged, IMainWindowViewModel
{
    // Viewにバインドされるコマンド
    public AsyncReactiveCommand LoadedCommand { get; } = new();

    private HttpClient client;

    // DataGridバインド用プロパティ
    public ReactiveCollection<Customer> Customers {get; private set;} = new ReactiveCollection<Customer>();

    public MainWindowViewModel(HttpClient client)
    {
        this.client = client;
        LoadedCommand.WithSubscribe(async () =>
        {
            // ここにロード時の処理を記載            
            var result =  await client.GetAsync("http://localhost:5051/api/customers");
            if (result.StatusCode == HttpStatusCode.OK) {
                var json = await result.Content.ReadAsStringAsync();
                // 本来はnull対策とか考える必要がある
                foreach(var customer in JsonSerializer.Deserialize<IEnumerable<Customer>>(json)){
                    Customers.AddOnScheduler(customer);
                }
            }
        });

        // バインド確認用
        // Customers.Add(new Customer{ID=1,Address="hoge",CompanyName = "fuga", Phone ="00-99"});
    }

    public event PropertyChangedEventHandler PropertyChanged;
}