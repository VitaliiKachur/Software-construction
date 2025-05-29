using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Reporting
    {
        private Warehouse _warehouse;
        private List<Document> _documents;

        public Reporting(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
            _documents = new List<Document>();
        }

        public IncomeDocument CreateIncomeDocument(string documentNumber)
        {
            var document = new IncomeDocument(documentNumber);
            _documents.Add(document);
            return document;
        }

        public OutcomeDocument CreateOutcomeDocument(string documentNumber)
        {
            var document = new OutcomeDocument(documentNumber);
            _documents.Add(document);
            return document;
        }

        public void ProcessIncomeDocument(IncomeDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            foreach (var item in document.Items)
            {
                _warehouse.AddItem(item);
            }

            Console.WriteLine($"Прибуткова накладна {document.DocumentNumber} оброблена успішно");
        }

        public void ProcessOutcomeDocument(OutcomeDocument document)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));

            foreach (var item in document.Items)
            {
                _warehouse.RemoveQuantity(item.Product.Name, item.Quantity);
            }

            Console.WriteLine($"Видаткова накладна {document.DocumentNumber} оброблена успішно");
        }

        public void PrintAllDocuments()
        {
            Console.WriteLine("\n=== ВСІ ДОКУМЕНТИ ===");
            foreach (var document in _documents.OrderBy(d => d.Date))
            {
                document.PrintInfo();
                Console.WriteLine();
            }
        }

        public void PrintInventoryReport()
        {
            _warehouse.PrintInventory();
        }
    }
}
