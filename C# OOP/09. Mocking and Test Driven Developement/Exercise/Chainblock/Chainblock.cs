using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public Chainblock(Dictionary<int, ITransaction> transactions)
        {
            this.transactions = transactions;
        }

        public int Count => transactions.Count();

        public void Add(ITransaction tx)
        {
            if (transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException("Transaction with this ID already exists!");
            }

            transactions[tx.Id] = tx;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException("Such transaction does not exist!");
            }

            ITransaction tx = transactions[id];
            tx.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (!Contains(tx.Id))
            {
                return false;
            }

            ITransaction current = transactions[tx.Id];

            return current.Status == tx.Status &&
                   current.To == tx.To &&
                   current.From == tx.From &&
                   current.Amount == current.Amount;
        }

        public bool Contains(int id)
        {
            return transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            List<ITransaction> orderedTransactions = transactions.Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            return orderedTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> receivers = transactions.Values
                .OrderBy(t => t.Amount)
                .Where(t => t.Status == TransactionStatus.Unauthorized)
                .Select(t => t.To)
                .ToList();

            if (receivers.Count == 0)
            {
                throw new InvalidOperationException($"No senders with {status} status!");
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> senders = transactions.Values
                .OrderBy(t => t.Amount)
                .Where(t => t.Status == TransactionStatus.Unauthorized)
                .Select(t => t.From)
                .ToList();

            if (senders.Count==0)
            {
                throw new InvalidOperationException($"No senders with {status} status!");
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException("Invalid ID!");
            }

            ITransaction tx = transactions[id];

            return tx;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> sendersOrdered = transactions.Values
                .OrderByDescending(t => t.Amount)
                .Where(t => t.From == sender)
                .ToList();

            if (sendersOrdered.Count==0)
            {
                throw new InvalidOperationException("Sender Does Not Exist!");
            }

            return sendersOrdered;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactionsByStatus=transactions.Values
                .OrderByDescending(t=>t.Amount)
                .Where(t=>t.Status==status)
                .ToList();

            if (transactionsByStatus.Count==0)
            {
                throw new InvalidOperationException($"No transactions with {status} status!");
            }

            return transactionsByStatus;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException("Invalid ID!");
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
