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
                .Where(t => t.Status == TransactionStatus.Unauthorized)
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

            string sender = "Sender1";

            List<ITransaction> sendersOrdered = transactions.Values
                .OrderByDescending(t => t.Amount)
                .Where(t => t.From == sender)
                .ToList();

            Assert.That(sendersOrdered, Is.EquivalentTo(testChainblock.GetBySenderOrderedByAmountDescending(sender)));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_WhenSenderDoesNotExist()
        {
            CreateBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => testChainblock.GetBySenderOrderedByAmountDescending("Sulio"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsException_WhenReceiverDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetByReceiverOrderedByAmountThenById("Pulio"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            string receiver = "Razvigor";

            List<ITransaction> receiversOrdered = transactions.Values
                .OrderBy(t => t.Amount)
                .ThenBy(t => t.Id)
                .Where(t => t.To == receiver)
                .ToList();

            Assert.That(receiversOrdered, Is.EquivalentTo(testChainblock.GetByReceiverOrderedByAmountThenById(receiver)));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenThereAreNoTransactions()
        {
            TransactionStatus status = TransactionStatus.Successfull;
            double amount = 90;

            Assert.That(testChainblock.GetByTransactionStatusAndMaximumAmount(status, amount), Is.Empty);
        }

        [Test]
        [TestCase(TransactionStatus.Aborted, 90)]
        [TestCase(TransactionStatus.Successfull, 1000)]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenThereAreNoMatches(TransactionStatus status, double amount)
        {
            Transaction tx = new Transaction(1, "Sracimir", "Dimitar", 100);
            tx.Status = TransactionStatus.Aborted;

            Transaction tx1 = new Transaction(2, "Mihail", "Murjo", 450.12);
            tx.Status = TransactionStatus.Failed;

            transactions.Add(tx.Id, tx);
            transactions.Add(tx1.Id, tx1);

            Assert.That(testChainblock.GetByTransactionStatusAndMaximumAmount(status, amount), Is.Empty);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsCorrectly()
        {
            TransactionStatus status = TransactionStatus.Successfull;
            double amount = 215.50;

            List<ITransaction> filtered = transactions.Values
                .Where(t => t.Status == status && t.Amount <= amount)
                .ToList();

            Assert.That(filtered, Is.EquivalentTo(testChainblock.GetByTransactionStatusAndMaximumAmount(status, amount)));
        }

        [Test]
        [TestCase("Sender1", 928.72)]
        [TestCase("Sender900", 10)]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenNoMatches(string sender, double amount)
        {
            CreateBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => testChainblock.GetBySenderAndMinimumAmountDescending(sender, amount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetBySenderAndMinimumAmountDescending("Sender1", 0));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            string sender = "Mitaka";
            double amount = 50.99;

            List<ITransaction> filtered = transactions.Values
                .OrderByDescending(t => t.Amount)
                .Where(t => t.From == sender && t.Amount >= amount)
                .ToList();

            Assert.That(filtered, Is.EquivalentTo(testChainblock.GetBySenderAndMinimumAmountDescending(sender, amount)));
        }

        [Test]
        [TestCase("Pesho",1,230)]
        [TestCase("Razvigor",290,1000.10)]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenThereAreNoMatches(string receiver, double minimum, double maximum)
        {
            CreateBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => testChainblock.GetByReceiverAndAmountRange(receiver, minimum, maximum));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsException_WhenCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => testChainblock.GetByReceiverAndAmountRange("Razvigor", 1, 230));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsCorrectly()
        {
            CreateBulkOfTransactions();

            List<ITransaction> filtered = transactions.Values
                .Where(t => t.To == "Razvigor" && t.Amount >= 100 && t.Amount <= 290)
                .ToList();

            Assert.That(testChainblock.GetByReceiverAndAmountRange("Razvigor", 100, 290), Is.EquivalentTo(filtered));
        }

        [Test]
        public void GetAllInAmountRange_ReturnsEmpty_WhenNoMatches()
        {
            CreateBulkOfTransactions();

            Assert.That(testChainblock.GetAllInAmountRange(300, 350),Is.Empty);
        }

        [Test]
        public void GetAllInAmountRange_ReturnsCorrectly()
        {
            double min = 100;
            double max = 200;

            List<ITransaction> filtered = transactions.Values
                .Where(t => t.Amount >= min && t.Amount <= max)
                .ToList();

            Assert.That(filtered, Is.EquivalentTo(testChainblock.GetAllInAmountRange(min, max)));
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

                if (i % 20 == 0)
                {
                    receiverName = "Razvigor";
                }

                if (i%30==0)
                {
                    senderName = "Mitaka";
                }

                Transaction tx = new Transaction(i, senderName, receiverName, 100 + i);
                tx.Status = status;
                transactions.Add(tx.Id, tx);

                amount += 20;
            }
        }
    }
}
