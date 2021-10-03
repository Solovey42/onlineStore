# Дипломный проект 
## Веб-приложение: интернет магазин по продаже металлических изделий
Данное веб пиложение поддерживает авторизацию как клиентов, так и сотрудников(администраторов). Клиенты могут просматривать каталоги, составлять корзину, оформлять заказы. Администратор системы имеет доступ ко всем зарегистрированным клиентам, их заказам, а также к продаваемой продукции размещенной на сайте. Админисратор может менять данные в случае необходимости.

### При разработке были использованы следующие технологии:
+ C#
+ EntityFramework
+ ASP.NET Core MVC
+ Асинхронные методы для доступа к базе данных
+ PostgreSQL/SqlLite (для более быстрого развертывания)
+ Bootstrap

### Запуск:
+ Скачайте проект и запустите onlineStore.sln в Visual Studio.
+ Либо скачайте опубликованную версию, запустите WebUI.exe и введите в браузере адрес указанный в запущенном консольном приложении.
+ Логины и пароли пользователей для тестирования указаны в файле /Domain/InitialData, можно также регистрировать новых пользователей.

### Структура базы данных:
![Alt text](https://github.com/Solovey42/onlineStore/blob/master/readme_assets/database.png?raw=true "Title")

### Скриншоты приложения:
![Alt text](https://github.com/Solovey42/onlineStore/blob/master/readme_assets/main.png?raw=true "Title")
![Alt text](https://github.com/Solovey42/onlineStore/blob/master/readme_assets/order.png?raw=true "Title")
![Alt text](https://github.com/Solovey42/onlineStore/blob/master/readme_assets/admin.png?raw=true "Title")
