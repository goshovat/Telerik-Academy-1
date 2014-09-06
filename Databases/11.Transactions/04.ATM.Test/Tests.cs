using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _02.RetrieveingMoney;
using _03.TransactionsHistory;

namespace _04.ATM.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WithdrawShoudNotTrowExcetion()
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 100;
            RetrievingMoney.WithDraw(cardNumber, cardPIN, withdraw);
        }

        [TestMethod]
        public void WithdrawShoudDecreaseUserCash()
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 100;

            var cashBefore = RetrievingMoney.GetUserMoney(cardNumber, cardPIN);

            RetrievingMoney.WithDraw(cardNumber, cardPIN, withdraw);

            var cashAfter = RetrievingMoney.GetUserMoney(cardNumber, cardPIN);

            Assert.AreEqual(cashAfter, cashBefore - withdraw);
        }


        [TestMethod]
        public void WithdrawShoudNotDecreaseUserCash()
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 10000000;

            var cashBefore = RetrievingMoney.GetUserMoney(cardNumber, cardPIN);

            RetrievingMoney.WithDraw(cardNumber, cardPIN, withdraw);

            var cashAfter = RetrievingMoney.GetUserMoney(cardNumber, cardPIN);

            Assert.AreEqual(cashAfter, cashBefore);
        }

        [TestMethod]
        public void WithdrawShoudAddNewHistoryRecord()
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 10;

            var recordsBefore = TransactionsHistory.CountRecords();

            TransactionsHistory.InsertData(cardNumber, cardPIN, withdraw);

            var recordsAfter = TransactionsHistory.CountRecords();

            Assert.AreEqual(recordsBefore + 1, recordsAfter);
        }

        [TestMethod]
        public void WithdrawShoudNotAddNewHistoryRecord()
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 100000000;

            var recordsBefore = TransactionsHistory.CountRecords();

            TransactionsHistory.InsertData(cardNumber, cardPIN, withdraw);

            var recordsAfter = TransactionsHistory.CountRecords();

            Assert.AreEqual(recordsBefore, recordsAfter);
        }
    }
}
