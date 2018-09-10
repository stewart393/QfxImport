using System;
using System.Collections.Generic;
using System.Text;

namespace QFXparser
{
    internal enum NodeType
    {
        DownloadOpen,
        DownloadClose,
        StatementOpen,
        StatementClose,
        TransactionOpen,
        TransactionClose,
        StatementProp,
        TransactionProp

    }
}
