using System;
using ClassHierarchy;
using BinaryTree;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Лабораторная_работа_13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public string ChangedData { get; }

        public JournalEntry(string collectionName, string changeType, string changedData)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedData = changedData;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Changed Data: {ChangedData}";
        }
    }

    // Делегат
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; private set; }
        public string ChangeType { get; private set; }
        public object ChangedItem { get; private set; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, Person changedItem)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedItem = changedItem;
        }

        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change Type: {ChangeType}, Changed Item: {ChangedItem}";
        }
    }

    public class MyNewCollection : BinaryTree<Person>
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public string CollectionName { get; set; }

        public MyNewCollection() : base()
        {
            CollectionName = "DefaultCollection";
        }

        public new void Add(Person item)
        {
            base.Add(item);

            // Генерация события
            OnCollectionCountChanged("Add", item);
        }

        public new bool Remove(int index)
        {
            if (index < 0 || index >= Count)
                return false;

            Person removedItem = this[index];

            base.Remove(removedItem);

            // Генерация события
            OnCollectionCountChanged("Remove", removedItem);

            return true;
        }

        // Переопределение индексатора для вызова события CollectionReferenceChanged
        public new Person this[int index]
        {
            get => base[index];
        }

        protected virtual void OnCollectionCountChanged(string action, Person changedItem)
        {
            if (CollectionCountChanged != null)
            {
                CollectionCountChanged.Invoke(this, new CollectionHandlerEventArgs(CollectionName, action, changedItem));

                // Добавляем изменение в журнал
                Journal.Instance.Add(new JournalEntry(CollectionName, action, changedItem.GetType().FullName));
            }
        }


        protected virtual void OnCollectionReferenceChanged(string action, Person changedItem)
        {
            if (CollectionCountChanged != null)
            {
                CollectionCountChanged.Invoke(this, new CollectionHandlerEventArgs(CollectionName, action, changedItem));

                // Добавляем изменение в журнал
                Journal.Instance.Add(new JournalEntry(CollectionName, action, changedItem.GetType().FullName));
            }
        }
    }

    // Класс Journal для хранения журнала изменений коллекции
    public class Journal
    {
        private static Journal instance;

        public static Journal Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Journal();
                }
                return instance;
            }
        }

        private List<JournalEntry> entries;

        private Journal()
        {
            entries = new List<JournalEntry>();
        }

        // Добавление записи в журнал
        public void Add(JournalEntry entry)
        {
            entries.Add(entry);
        }

        // Очистка журнала
        public void Clear()
        {
            entries.Clear();
        }

        // Получение всех записей журнала
        public List<JournalEntry> GetEntries()
        {
            return entries;
        }

        // Метод для обработки события CollectionCountChanged
        public void HandleCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            string entryData = $"Action: {args.ChangeType}, Item: {args.ChangedItem}";

            // Создание нового объекта JournalEntry
            JournalEntry entry = new JournalEntry(args.CollectionName, "CollectionCountChanged", entryData);

            // Добавление записи в журнал
            Add(entry);
        }

        // Метод для обработки события CollectionReferenceChanged
        public void HandleCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            string entryData = $"Action: {args.ChangeType}, Item: {args.ChangedItem}";

            // Создание нового объекта JournalEntry
            JournalEntry entry = new JournalEntry(args.CollectionName, "CollectionReferenceChanged", entryData);

            // Добавление записи в журнал
            Add(entry);
        }
    }
}
