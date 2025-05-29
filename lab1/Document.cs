using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public abstract class Document : IPrintable
    {
        protected DateTime _date;
        protected string _documentNumber;
        protected List<WarehouseItem> _items;

        public DateTime Date => _date;
        public string DocumentNumber => _documentNumber;
        public IReadOnlyList<WarehouseItem> Items => _items.AsReadOnly();

        protected Document(string documentNumber)
        {
            _documentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
            _date = DateTime.Now;
            _items = new List<WarehouseItem>();
        }

        public void AddItem(WarehouseItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        public abstract void PrintInfo();

        protected void PrintCommonInfo(string documentType)
        {
            Console.WriteLine($"\n=== {documentType} ===");
            Console.WriteLine($"Номер документа: {_documentNumber}");
            Console.WriteLine($"Дата: {_date:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Кількість позицій: {_items.Count}");
        }
    }

}
