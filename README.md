# Современные платформы программирования (СПП)
## Задача 1
Создать класс на языке C#, который:
- называется `TaskQueue` и реализует логику пула потоков
- создает указанное количество потоков пула в конструкторе
- содержит очередь задач в виде делегатов без параметров `delegate void TaskDelegate()`
- обеспечивает постановку в очередь и последующее выполнение делегатов с помощью метода `void EnqueueTask(TaskDelegate task)`

## Задача 2
Реализовать консольную программу на языке C#, которая: 
- принимает в параметре командной строки путь к исходному и целевому каталогам на диске
- выполняет параллельное копирование всех файлов из исходного каталога в целевой каталог
- выполняет операции копирования параллельно с помощью пула потоков
- дожидается окончания всех операций копирования и выводит в консоль информацию о количестве скопированных файлов

## Задача 3
Создать класс на языке C#, который: 
- называется `Mutex` и реализует двоичный семафор с помощью атомарной операции `Interlocked.CompareExchange` 
- обеспечивает блокировку и разблокировку двоичного семафора с помощью `public`-методов `Lock()` и `Unlock()`

## Задача 4
Создать класс на языке C#, который: 
- называется `OSHandle` и обеспечивает автоматическое или принудительное освобождение заданного дескриптора операционной системы
- содержит свойство `Handle`, позволяющее установить и получить дескриптор операционной системы
- реализует метод `Finalize()` для автоматического освобождения дескриптора
- реализует интерфейс `IDisposable` для принудительного освобождения дескриптора 

## Задача 5
Реализовать консольную программу на языке C#, которая: 
- принимает в параметре командной строки путь к сборке .NET (exe- или dll-файлу)
- загружает указанную сборку в память
- выводит на экран полные имена всех `public`-типов данных этой сборки, упорядоченные по пространству имен (`namespace`) и по имени

## Задача 6
Создать класс `LogBuffer` на языке C#, который: 
- представляет собой журнал строковых сообщений
- предоставляет метод `public void Add(string item)`
- буферизирует добавляемые одиночные сообщения и записывает их пачками в конец текстового файла на диске
- периодически выполняет запись накопленных сообщений, когда их количество достигает заданного предела
- периодически выполняет запись накопленных сообщений по истечение заданного интервала времени (вне зависимости от наполнения буфера)
- выполняет запись накопленных сообщений асинхронно с добавлением сообщений в буфер

## Задача 7
Создать на языке C# статический метод класса `Parallel.WaitAll()`, который: 
- принимает в параметрах массив делегатов
- выполняет все указанные делегаты параллельно с помощью пула потоков
- дожидается окончания выполнения всех делегатов<br />
Реализовать простейший пример использования метода `Parallel.WaitAll()`

## Задача 8
Создать на языке C# пользовательский атрибут с именем `ExportClass`, применимый только к классам, и реализовать консольную программу, которая: 
- принимает в параметре командной строки путь к сборке .NET (exe- или dll-файлу)
- загружает указанную сборку в память
- выводит на экран полные имена всех `public`-типов данных этой сборки, помеченные атрибутом `ExportClass`

## Задача 9
Создать на языке C# обобщенный (`generic`-) класс `DynamicList<T>`, который:
- реализует динамический массив с помощью обычного массива `T[]`
- имеет свойство `Count`, показывающее количество элементов
- имеет свойство `Items` для доступа к элементам по индексу
- имеет методы `Add()`, `Remove()`, `RemoveAt()`, `Clear()` для соответственно добавления, удаления, удаления по индексу и удаления всех элементов
- реализует интерфейс `IEnumerable<T>`<br />
Реализовать простейший пример использования класса `DynamicList<T>` на языке C#
