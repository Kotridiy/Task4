Задача №4. Отслеживать изменения в папке, и как только туда попадают csv-файлы, прочитать содержимое и сохранить в БД.

+ConsoleApplication. Содержит код инициализации в среде консольного приложения, чтения файла конфигурации и настройки FileSystemWatcher.

+ServiceApplication. Тоже самое, что и консольное приложение, что запускает в среде Windows Service.

+BusinessLogic. Содержит код по чтению и парсу, общается с уровнем DAL через UnitOfWork.

~FileLogic. Отлавливает новые файлы, создаёт поток для парса файла и работает с записями о файлах в БД.

~FileHash. Генерирует хеш-код по информации о файле.

~CsvParser. Построчно читает файл, заполняет CsvParser и отправляет в уровень DAL, для добавления записи. Так же позволяет выполнить ролл-бэк.

~CsvRecord. Класс, содержащий всю информацию о записи.

+FileWatcherModel. Содержит интерфейс записи о файле в БД

+FileWatcherData. Уровень DAL, для общения с БД, в которой храняться записи о прочитанных файлах.

~FileWatcherContext. DBContext, для прямой связи с БД.

~FileWatcherRepository. Имеет обёртку над контекстом, содержащая только необходимые атомарные функции.

~WatcherUnitOfWork. Обёртка над репозиторием, предоставляющая интерфейс следующему уровню архитектуры.

~WatcherBuilder. Класс билдера, собирающий готовый к работе UnitOfWork.

+DataModel. Содержит необходимые интерфейсы для работы с записями о продажах.

+DataAccessLayer. Такой же как и FileWatcherData, только более широкий и содержит соответсвующие классы.
