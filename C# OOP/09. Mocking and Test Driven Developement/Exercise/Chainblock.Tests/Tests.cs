using Chainblock.Contracts;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    class Tests
    {
        private Chainblock testChainblock;
        private Dictionary<int, ITransaction> transactions;
        [SetUp]
        public void SetUp()
        {
            transactions = new Dictionary<int, ITransaction>();
            testChainblock = new Chainblock(transactions);
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionAlreadyExists()
        {
            Transaction first = CreateSimpleTransaction();
            Transaction second = CreateSimpleTransaction();

            testChainblock.Add(first);
            Assert.Throws<InvalidOperationException>(() => testChainblock.Add(second));
        }

        [Test]
        public void Add_TransactionsExist()
        {
            Transaction current = CreateSimpleTransaction();
            testChainblock.Add(current);

            int predicted = 1;

            Assert.AreEqual(transactions.Count, predicted);
        }

        [Test]
        public void Contains_DoesNotContainTransaction()
        {
            Assert.That(testChainblock.Contains(CreateSimpleTransaction()), Is.False);
        }

        [Test]
        public void Contains_DoesContainTransaction()
        {
            Transaction tx = CreateSimpleTransaction();
            transactions.Add(tx.Id, tx);

            Assert.That(testChainblock.Contains(tx), Is.True);
        }

        [Test]
        public void ContainsID_DoesNotContainID()
        {
            Transaction tx = CreateSimpleTransaction();

            Assert.That(testChainblock.Contains(tx.Id), Is.False);
        }

        [Test]
        public void ContainsID_DoesContainID()
        {
            Transaction tx = CreateSimpleTransaction();
            transactions.Add(tx.Id, tx);

            Assert.That(testChainblock.Contains(tx.Id));
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsArgumentException_WhenDoesNotExist()
        {
            int ID = 1;

            Assert.Throws<ArgumentException>(() => testChainblock.ChangeTransactionStatus(ID, TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatus_ChangesStatusCorrectly()
        {
            Transaction tx = CreateSimpleTransaction();
            tx.Status = TransactionStatus.Failed;

            transactions.Add(tx.Id, tx);

            testChainblock.ChangeTransactionStatus(tx.Id, TransactionStatus.Successfull);

            Assert.That(tx.Status, Is.EqualTo(TransactionStatus.Successfull));
        }

        [Test]
        public void RemoveTransactionById_ThrowsException_WhenTransactionDoesNotExist()
        {
            int ID = 1;

            Assert.Throws<InvalidOperationException>(() => testChainblock.RemoveTransactionById(ID));
        }

        [Test]
        public void RemoveTransactionById_RemovesTransactionSuccessfully()
        {
            Transaction tx = CreateSimpleTransaction();
            transactions.Add(tx.Id, tx);

            Transaction tx1 = new Transaction(2, "Stoyan", "Petar", 100);
            transactions.Add(tx1.Id, tx);

            testChainblock.RemoveTransactionById(tx.Id);
            int predicted = 1;

            Assert.AreEqual(predicted, testChainblock.Count);
        }

        [Test]
        public void GetById_ThrowsException_WhenIdDoesNotExist()
        {
            int ID = 1;

            Assert.Throws<InvalidOperationException>(() => testChainblock.GetById(ID));
        }

        [Test]
        public void GetById_GetsCorrectly()
        {
            Transaction tx = CreateSimpleTransaction();
            transactions.Add(tx.Id, tx);

            ITransaction chainblockTx = testChainblock.GetById(tx.Id);

            Assert.AreEqual(tx, chainblockTx);
        }

        [Test]
        public void GetByTransactionStatus_ThrowsException_WhenEmpty()
        {
            TransactionStatus status = TransactionStatus.Aborted;
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetByTransactionStatus(status));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsCollectionCorrectly()
        {
            CreateBulkOfTransactions();
            List<ITransaction> transactionsByStatus = transactions.Values
                .OrderByDescending(t => t.Amount)
                .Where(t => t.Status == TransactionStatus.Failed)
                .ToList();

            Assert.That(transactionsByStatus, Is.EquivalentTo(testChainblock.GetByTransactionStatus(TransactionStatus.Failed)));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsException_WhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            List<string> senders = transactions.Values
                .OrderBy(t => t.Amount)
                .Where(t=>t.Status==TransactionStatus.Unauthorized)
                .Select(t => t.From)
                .ToList();

            Assert.That(senders, Is.EquivalentTo(testChainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized)));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsException_WhenNoMatches()
        {
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            List<string> receivers = transactions.Values
                .OrderBy(t => t.Amount)
                .Where(t => t.Status == TransactionStatus.Unauthorized)
                .Select(t => t.To)
                .ToList();

            Assert.That(receivers, Is.EquivalentTo(testChainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized)));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            List<ITransaction> orderedTransactions = transactions.Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            Assert.That(orderedTransactions, Is.EquivalentTo(testChainblock.GetAllOrderedByAmountDescendingThenById()));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            string sender = "Sender0";

            List<ITransaction> sendersOrdered = transactions.Values
                .OrderByDescending(t => t.Amount)
                .Where(t=>t.From==sender)
                .ToList();

            Assert.That(sendersOrdered, Is.EquivalentTo(testChainblock.GetBySenderOrderedByAmountDescending(sender)));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_WhenSenderDoesNotExist()
        {
            CreateBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => testChainblock.GetBySenderOrderedByAmountDescending("Sulio"));
        }

        private Transaction CreateSimpleTransaction()
        {
            return new Transaction(1, "Peycho", "Ivan", 90);
        }

        private void CreateBulkOfTransactions()
        {
            double amount = 200;

            for (int i = 0; i < 100; i++)
            {
                string senderName = $"Sender{i}";
                string receiverName = $"Receiver{i}";
                TransactionStatus status = TransactionStatus.Successfull;

                if (i % 2 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }
                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Aborted;
                }
                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Failed;
                }

                if (i % 10 == 0)
                {
                    amount = 200;
                }

                Transaction tx = new Transaction(i, senderName, receiverName, 100 + i);
                tx.Status = status;
                transactions.Add(tx.Id, tx);

                amount += 20;
            }
        }
    }
}
