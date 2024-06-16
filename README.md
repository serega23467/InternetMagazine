# Интернет магазин на WPF

![логин](https://github.com/serega23467/InternetMagazine/assets/114952677/9e18fcf5-74bf-4922-a175-8f716f51f758)

окно авторизации

![рег](https://github.com/serega23467/InternetMagazine/assets/114952677/c540d849-ceee-4188-9f43-c341f91895a2)

окно регистрации

![юзер](https://github.com/serega23467/InternetMagazine/assets/114952677/3db5240d-45c1-4ea5-a426-4329adaef536)

окно обычного пользователя

![админ](https://github.com/serega23467/InternetMagazine/assets/114952677/b4c95131-3c52-4060-8a74-12cbddaa39c4)

окно администратора список пользователей

![категроии](https://github.com/serega23467/InternetMagazine/assets/114952677/99a27b49-117d-44b3-b821-9a7174a1b1e4)

окно администратора список категорий

![image](https://github.com/serega23467/InternetMagazine/assets/114952677/97cb8213-a0e0-48f2-9d82-a6f2555f9910)

окно администратора список продуктов

![status](https://github.com/serega23467/InternetMagazine/assets/114952677/0ac6a470-5aea-4f51-acbd-aed9df103e5b)

cписок заказов по статусу

![clients](https://github.com/serega23467/InternetMagazine/assets/114952677/eea2e142-4232-467d-9dfe-670d6f60c9c5)

cписок активных клиентов

![products](https://github.com/serega23467/InternetMagazine/assets/114952677/d4cb2539-e92a-486e-b577-1225ce1a0b01)

cписок популярных продуктов

![income](https://github.com/serega23467/InternetMagazine/assets/114952677/6f070a57-60ed-48ef-8699-2aa729e70f16)

список доходов по месяцам

## Функциональность

1. **Регистрация и авторизация**: Возможность создать аккаунт и зайти в него.
2. **Функциональность админа**: Изменение списка пользователей, задач и продуктов, оформление отчетов.
3. **Функциональность менеджера**: Как у админа, но без возможности добавления и изменения, возможнсть изменять заказы.
4. **Функциональность пользователя**: Возможность видеть список продукты и оформлять заказ.

## Технические детали

- **Разработано на**: WPF
- **База данных**: SQLite с использованием Entity Framework

  ## Создание класса DataBaseContext для связи с БД

``` C#
 public class DatabaseContext : DbContext
 {
     public DbSet<MagazineUser> Users { get; set; } = null!;
     public DbSet<UserStatus> UserStatuses { get; set; } = null!;
     public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
     public DbSet<Product> Products { get; set; } = null!;
     public DbSet<StatusOrder> OrderStatuses { get; set; } = null!;
     public DbSet<Order> Orders { get; set; } = null!;
     private static DatabaseContext instance;
     private DatabaseContext() { }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlite("Data Source=InternetMagazine.db;");
     }
     public static DatabaseContext GetDB()
     {
         if (instance != null)
         {
             return instance;
         }
         else
         {
             instance = new DatabaseContext();
             return instance;
         }
     }
 }

```
  ## Код создания таблиц SQLite 

``` SQLite
CREATE TABLE UserStatuses
(	
	Id INTEGER,
	StatusName TEXT,
	PRIMARY KEY(Id AUTOINCREMENT)
)
CREATE TABLE Users
(
	Id INTEGER,
	UserName TEXT,
	UserLogin TEXT,
	UserPassword TEXT,
	PhoneNumber TEXT,
	UserStatus INTEGER,
	PRIMARY KEY(Id AUTOINCREMENT),
	FOREIGN KEY (UserStatus) REFERENCES UserStatuses(Id)
)
CREATE TABLE ProductCategories
(
	Id INTEGER,
	CategoryName TEXT,
	PRIMARY KEY(Id AUTOINCREMENT)
)
CREATE TABLE Products (
   	Id INTEGER,
	ProductName TEXT,
    ProductDescription TEXT,
    ProductPrice REAL,
    CategoryId INT,
    HasInGarbage INTEGER,
    ProductImage BLOB,
	PRIMARY KEY(Id AUTOINCREMENT),
    FOREIGN KEY (CategoryId) REFERENCES ProductCategories(Id)
)
CREATE TABLE OrderStatuses
(
	    Id INTEGER,
		OrderStatus TEXT,
		PRIMARY KEY(Id AUTOINCREMENT)
)
CREATE TABLE "Orders" (
	"Id"	INTEGER,
	"UserId"	INTEGER,
	"CourierId"	INTEGER,
	"Adress"	TEXT,
	"StatusId"	INTEGER,
	"Comment"	TEXT,
	"OrderDate"	TEXT,
	"ProductId"	INTEGER,
	PRIMARY KEY("Id" AUTOINCREMENT),
	FOREIGN KEY("UserId") REFERENCES "Users"("Id"),
	FOREIGN KEY("ProductId") REFERENCES "Products"("Id"),
	FOREIGN KEY("StatusId") REFERENCES "OrderStatuses"("Id"),
	FOREIGN KEY("CourierId") REFERENCES "Users"("Id")
)
Users - пользователи, UserStatuses - роли пользователей, Products - продукты,
ProductCategories - категории продуктов, Orders - заказы, OrderStatuses - статусы заказа
```


https://github.com/serega23467/InternetMagazine/assets/114952677/20c32732-0b40-4cd5-b4e4-9313d31911fa

демонстрация окна админа


https://github.com/serega23467/InternetMagazine/assets/114952677/25495609-32fb-424e-8107-2352d2c16dd1

демонстрация окна пользователя и оператора


https://github.com/serega23467/InternetMagazine/assets/114952677/212bf930-ad0e-4d9b-8ea2-47274431aeb1

демонстрация окна менеджера

## Автор программы

### Сергей А.
