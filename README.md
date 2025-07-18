# 9ParkingControlSystem

## MediatR 註冊

``` csharp

    // RegisterServicesFromAssemblyContaining 為 MediatR v12 的新註冊方式
    // 會替你在 DI 容器裡註冊： Transient<IMediator>, Singleton<ServiceFactory>和 Transient<自定義指令>

    // 可以註冊 繼承 IRequest 介面的物件
    // LoginUserCommand : IRequest<>
    // 會從包含指定型別 T 所在的組件中註冊所有 IRequestHandler<,>、INotificationHandler<> 等相關服務。
    public static void InstallMediatR(this WebApplicationBuilder builder)
    {
       builder.Services.AddMediatR(cfg =>
       {
           cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>();
           cfg.RegisterServicesFromAssemblyContaining<RefreshTokenCommand>();
       });
    }
```

## MediatR 背後執行

``` csharp
    // Mediator.Send 內部會：
    // 先拿 request.GetType() 得到 實際型別 LoginUserCommand
    // 以「Request 型別」當 key，看快取 (ConcurrentDictionary<Type, RequestHandlerWrapper>) 裡有沒有對應的 wrapper
    // 如果沒有就用 反射 動態產生 RequestHandlerWrapperImpl<LoginUserCommand,(string,string)>
    // 這個 RequestHandlerWrapper 會利用注入的 IServiceProvider：
    var result = await _mediator.Send(new LoginUserCommand("user", "pwd"));
    // 解析出對應的 Handler 再依序包上所有 IPipelineBehavior，最後呼叫 Handle() 返回結果。
    var handler = serviceFactory(typeof(IRequestHandler<LoginUserCommand,(string,string)>));


    // Publish（事件廣播）把通知送給所有實作 INotificationHandler<UserLoggedInNotification> 的 handler
    await _mediator.Publish(new UserLoggedInNotification(userId));

    // Stream（v12 新功能）
    await foreach (var item in _mediator.CreateStream(new SearchOrdersQuery(...)))
```

### Controller 基本流程

1. new 一個 _mediator ( DI -> Transient) + 辨認路由
2. mediator.Send(command);  內部實作參考上面
3. new LoginUserCommandHandler && 執行 Handle()

### 
