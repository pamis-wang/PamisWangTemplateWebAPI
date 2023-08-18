# API Template ASP.NET Core 6

目前還是練習用的專案，請不要真的用於生產環境！！
[對應至此部落格文章文章](https://pamiswang.github.io/posts/2023-08-15-asp-dot-net-core-6-web-api-template)

基於 ASP.NET Core 6 為基礎開發的 Web API 範本。

建立一個適用於大多數開發場景的共通性功能，
例如常見的資料庫、身分驗證、郵件寄送、報表產出。

目的是希望降低重覆的架構與功能設計，
使工程師更能夠專注於業務邏輯的開發。


## 專案建置

專案複製下來後需要進行以下建置工作

### 複製專案設定檔

由於 `appsettings.{environmentName}.json` 皆被加入版控忽略清單

因此需要根據目前適用的開發環境複製設定檔

- 開發環境 => `appsettings.Development.json`
- 正式環境 => `appsettings.Production.json`
- 測試環境 => `appsettings.Staging.json`

## 目錄結構

### Properties

Properties 資料夾包含一個 launchSettings.json 文件，
其中包含啟動應用程式偵錯的設定、 IIS 設置、應用程式 URL、身份驗證、SSL 等設定。

### Dependencies

包含本專案使用的框架與 NuGet 套件。

### Controllers

負責處理所有傳入的請求。

### ViewModels

用於顯示或是資料庫複雜查詢的資料模型，不會與資料庫直接溝通。

### EntityModels

由於本專案以 Entity Framework Core 與 Code First 開發，
此目錄會放置與資料庫相互映射的實體資料模型。

## 相依套件

### Swashbuckle.AspNetCore

使用 Swagger 套件來產生 API 文件，包含以下相依套件。

- Microsoft.Extensions.ApiDescription.Server
- Swashbuckle.AspNetCore.Swagger
- Swashbuckle.AspNetCore.SwaggerGen
- Swashbuckle.AspNetCore.SwaggerUI

### Swashbuckle.AspNetCore.Annotations

提供更多客製屬性標籤，讓 API 文件更加清晰豐富

### Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer

加入 API 版本控制功能，並生效於 Swagger 文件上加入 API 版本控制

### Microsoft.EntityFrameworkCore

Entity Framework Core 為微軟的 ORM (Object Relational Mapping) 框架，以 ADO.NET 為底層用於連線資料庫

[官方列出的資料庫提供者列表](https://learn.microsoft.com/zh-tw/ef/core/providers/?tabs=dotnet-core-cli)

| NuGet 封裝                              | 支援的資料庫引擎                        |
| --------------------------------------- | --------------------------------------- |
| Microsoft.EntityFrameworkCore.SqlServer | Azure SQL 和 SQL Server 2012 及更新版本 |
| Microsoft.EntityFrameworkCore.Sqlite    | SQLite 3.7 及更新版本                   |
| Npgsql.EntityFrameworkCore.PostgreSQL   | PostgreSQL                              |
| Pomelo.EntityFrameworkCore.MySql        | MySQL、MariaDB                          |
| Oracle.EntityFrameworkCore              | Oracle DB 11.2 與更新版本               |

### Dapper

.Net 平台的 ORM 套件，
可根據專案需求切換使用 Entity Framework Core 或 Dapper。

### MailKit

由於微軟官方的 `SmtpClient 類別` 已經過時，

[根據該 MSDN 的詳細說明](https://learn.microsoft.com/zh-tw/dotnet/api/system.net.mail.smtpclient?view=net-7.0)

官方建議 MailKit 作為信件寄發的解決方案。

### System.DirectoryServices

以下套件用於開發 LDAP 驗證的套件

- System.DirectoryServices
- System.DirectoryServices.Protocols
- System.DirectoryServices.AccountManagement

### Newtonsoft.Json

比微軟官方 `System.Text.Json` 還要方便好用的 JSON 套件。

### Newtonsoft.Json.Schema

可用於驗證 JSON 格式的資料。

### Newtonsoft.Json.Bson

用於解析 `Binary JSON` ，主要被用作MongoDB資料庫中的資料儲存和網路傳輸格式。

### RestSharp

比微軟官方 `System.Net.Http.HttpClient` 還要方便好用的 JSON 套件

### Razor.Templating.Core

將 .cshtml 文件渲染為字串，可用於報表產出或是電子郵件套版。