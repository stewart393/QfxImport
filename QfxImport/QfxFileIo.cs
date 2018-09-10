using System;
using System.IO;
using System.Xml;
using System.Data;
using QFXparser;

namespace QfxImport
{
    public class QfxFileIo
    {
        public QfxFileIo(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileParser parser = new FileParser(filePath);
                var result = parser.BuildStatement();
                

                if (AllTransactionsTable == null)
                {
                    AllTransactionsTable = new DataTable(result.AccountNum.ToString());
                    AllTransactionsTable.Columns.Add("Type", typeof(System.String));
                    AllTransactionsTable.Columns.Add("PostedOn", typeof(System.DateTime));
                    AllTransactionsTable.Columns.Add("Amount", typeof(System.Decimal));
                    AllTransactionsTable.Columns.Add("TransactionId", typeof(System.String));
                    AllTransactionsTable.Columns.Add("RefNumber", typeof(System.String));
                    AllTransactionsTable.Columns.Add("Name", typeof(System.String));
                    AllTransactionsTable.Columns.Add("Memo", typeof(System.String));
                }
                foreach (Transaction t in result.Transactions)
                {
                    DataRow newRow = AllTransactionsTable.NewRow();                    
                    AllTransactionsTable.Rows.Add(newRow);

                    newRow["Type"] = t.Type;
                    newRow["PostedOn"] = t.PostedOn; 
                    newRow["Amount"] = t.Amount;
                    newRow["TransactionId"] = t.TransactionId;
                    newRow["RefNumber"] = t.RefNumber;
                    newRow["Name"] = t.Name;
                    newRow["Memo"] = t.Memo;
                }            
            }
        }
        public XmlNode AllTransactions { get; set; }       
        public DataTable AllTransactionsTable { get; set; }

    }
}
