The construction of this project:
```
.
├── Controllers
│   ├── CustomerController.cs
│   ├── HomeController.cs
│   ├── OrderController.cs
│   ├── ProductController.cs
│   ├── PurchaseController.cs
│   ├── ReviewController.cs
│   └── StaffController.cs
├── Dockerfile
├── Models
│   └── ErrorViewModel.cs
├── Program.cs
├── Properties
│   ├── PublishProfiles
│   │   ├── FolderProfile\ 1.pubxml
│   │   └── FolderProfile.pubxml
│   └── launchSettings.json
├── Services
│   ├── Customer
│   │   ├── CustomerDto.cs
│   │   ├── CustomerService.cs
│   │   ├── Data
│   │   │   └── customerContext.cs
│   │   ├── FakeCustomerService.cs
│   │   └── ICustomerService.cs
│   ├── Order
│   │   ├── FakeOrderService.cs
│   │   ├── IOrderService.cs
│   │   ├── OrderDto.cs
│   │   └── OrderService.cs
│   ├── Product
│   │   ├── FakeProductService.cs
│   │   ├── IProductService.cs
│   │   ├── ProductDto.cs
│   │   ├── ProductHistoryDto.cs
│   │   ├── ProductService.cs
│   │   └── ReviewDto.cs
│   ├── Purchase
│   │   ├── FakePurchaseService.cs
│   │   ├── IPurchaseService.cs
│   │   ├── PurchaseDto.cs
│   │   └── PurchaseService.cs
│   ├── Review
│   │   ├── FakeReviewService.cs
│   │   ├── IReviewService.cs
│   │   ├── ReviewDto.cs
│   │   └── ReviewService.cs
│   └── Staff
│       ├── FakeStaffService.cs
│       ├── IStaffService.cs
│       ├── StaffDto.cs
│       └── StaffService.cs
├── StaffDb
├── Startup.cs
├── ThreeAmigosStaff.csproj
├── Views
│   ├── Customer
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Home
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Order
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Product
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   ├── EditReview.cshtml
│   │   ├── Index.cshtml
│   │   ├── PriceHistory.cshtml
│   │   ├── Resell.cshtml
│   │   ├── Review.cshtml
│   │   ├── Reviews.cshtml
│   │   └── Stock.cshtml
│   ├── Purchase
│   │   ├── Accept.cshtml
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Review
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Shared
│   │   ├── Error.cshtml
│   │   ├── _CookieConsentPartial.cshtml
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Staff
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── appsettings.Development.json
├── appsettings.json
├── bin
│   └── Debug
│       └── netcoreapp2.2
│           ├── Properties
│           │   └── launchSettings.json
│           ├── ThreeAmigosStaff.Views.dll
│           ├── ThreeAmigosStaff.Views.pdb
│           ├── ThreeAmigosStaff.deps.json
│           ├── ThreeAmigosStaff.dll
│           ├── ThreeAmigosStaff.pdb
│           ├── ThreeAmigosStaff.runtimeconfig.dev.json
│           ├── ThreeAmigosStaff.runtimeconfig.json
│           ├── appsettings.Development.json
│           └── appsettings.json
├── docker-compose.yml
├── obj
│   ├── Debug
│   │   └── netcoreapp2.2
│   │       ├── Razor
│   │       │   └── Views
│   │       │       ├── Customer
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Delete.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   └── Index.cshtml.g.cs
│   │       │       ├── Home
│   │       │       │   ├── Index.cshtml.g.cs
│   │       │       │   └── Privacy.cshtml.g.cs
│   │       │       ├── Order
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Delete.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   └── Index.cshtml.g.cs
│   │       │       ├── Product
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   ├── EditReview.cshtml.g.cs
│   │       │       │   ├── Index.cshtml.g.cs
│   │       │       │   ├── PriceHistory.cshtml.g.cs
│   │       │       │   ├── Resell.cshtml.g.cs
│   │       │       │   ├── Review.cshtml.g.cs
│   │       │       │   ├── Reviews.cshtml.g.cs
│   │       │       │   └── Stock.cshtml.g.cs
│   │       │       ├── Purchase
│   │       │       │   ├── Accept.cshtml.g.cs
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Delete.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   └── Index.cshtml.g.cs
│   │       │       ├── Review
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Delete.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   └── Index.cshtml.g.cs
│   │       │       ├── Shared
│   │       │       │   ├── Error.cshtml.g.cs
│   │       │       │   ├── _CookieConsentPartial.cshtml.g.cs
│   │       │       │   ├── _Layout.cshtml.g.cs
│   │       │       │   └── _ValidationScriptsPartial.cshtml.g.cs
│   │       │       ├── Staff
│   │       │       │   ├── Create.cshtml.g.cs
│   │       │       │   ├── Delete.cshtml.g.cs
│   │       │       │   ├── Details.cshtml.g.cs
│   │       │       │   ├── Edit.cshtml.g.cs
│   │       │       │   ├── Index.cshtml.g.cs
│   │       │       │   └── Privacy.cshtml.g.cs
│   │       │       ├── _ViewImports.cshtml.g.cs
│   │       │       └── _ViewStart.cshtml.g.cs
│   │       ├── ThreeAmigosStaff.AssemblyInfo.cs
│   │       ├── ThreeAmigosStaff.AssemblyInfoInputs.cache
│   │       ├── ThreeAmigosStaff.RazorAssemblyInfo.cache
│   │       ├── ThreeAmigosStaff.RazorAssemblyInfo.cs
│   │       ├── ThreeAmigosStaff.RazorCoreGenerate.cache
│   │       ├── ThreeAmigosStaff.RazorTargetAssemblyInfo.cache
│   │       ├── ThreeAmigosStaff.RazorTargetAssemblyInfo.cs
│   │       ├── ThreeAmigosStaff.TagHelpers.input.cache
│   │       ├── ThreeAmigosStaff.TagHelpers.output.cache
│   │       ├── ThreeAmigosStaff.Views.dll
│   │       ├── ThreeAmigosStaff.Views.pdb
│   │       ├── ThreeAmigosStaff.assets.cache
│   │       ├── ThreeAmigosStaff.csproj.CopyComplete
│   │       ├── ThreeAmigosStaff.csproj.FileListAbsolute.txt
│   │       ├── ThreeAmigosStaff.csprojAssemblyReference.cache
│   │       ├── ThreeAmigosStaff.dll
│   │       ├── ThreeAmigosStaff.pdb
│   │       └── project.razor.json
│   ├── ThreeAmigosStaff.csproj.nuget.cache
│   ├── ThreeAmigosStaff.csproj.nuget.dgspec.json
│   ├── ThreeAmigosStaff.csproj.nuget.g.props
│   ├── ThreeAmigosStaff.csproj.nuget.g.targets
│   └── project.assets.json
└── wwwroot
    ├── css
    │   └── site.css
    ├── favicon.ico
    ├── js
    │   └── site.js
    └── lib
        ├── bootstrap
        │   ├── LICENSE
        │   └── dist
        │       ├── css
        │       │   ├── bootstrap-grid.css
        │       │   ├── bootstrap-grid.css.map
        │       │   ├── bootstrap-grid.min.css
        │       │   ├── bootstrap-grid.min.css.map
        │       │   ├── bootstrap-reboot.css
        │       │   ├── bootstrap-reboot.css.map
        │       │   ├── bootstrap-reboot.min.css
        │       │   ├── bootstrap-reboot.min.css.map
        │       │   ├── bootstrap.css
        │       │   ├── bootstrap.css.map
        │       │   ├── bootstrap.min.css
        │       │   └── bootstrap.min.css.map
        │       └── js
        │           ├── bootstrap.bundle.js
        │           ├── bootstrap.bundle.js.map
        │           ├── bootstrap.bundle.min.js
        │           ├── bootstrap.bundle.min.js.map
        │           ├── bootstrap.js
        │           ├── bootstrap.js.map
        │           ├── bootstrap.min.js
        │           └── bootstrap.min.js.map
        ├── jquery
        │   ├── LICENSE.txt
        │   └── dist
        │       ├── jquery.js
        │       ├── jquery.min.js
        │       └── jquery.min.map
        ├── jquery-validation
        │   ├── LICENSE.md
        │   └── dist
        │       ├── additional-methods.js
        │       ├── additional-methods.min.js
        │       ├── jquery.validate.js
        │       └── jquery.validate.min.js
        └── jquery-validation-unobtrusive
            ├── LICENSE.txt
            ├── jquery.validate.unobtrusive.js
            └── jquery.validate.unobtrusive.min.js
```
