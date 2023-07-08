﻿using api;
using MongoDB.Bson;
using Raptorious.SharpMt940Lib;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Sports_Accounting
{
    public class XmlAPI
    {
        JsonAPI jsonAPI= new JsonAPI();


        public XmlAPI()
        {
        }

        public async Task<XmlDocument> Get(BsonDocument criteria)
        {
            var BsonDoc = jsonAPI.Get(criteria);

            return XMLConverter(await BsonDoc);
        }

        public async Task<XmlDocument> GetAll()
        {
            var BsonDoc = jsonAPI.GetAll();

            return XMLConverter(await BsonDoc);
        }

        public XmlDocument XMLConverter(List<BsonDocument> BsonDoc) 
        {
            var header = new Raptorious.SharpMt940Lib.Mt940Format.Separator("STARTUMSE");
            var trailer = new Raptorious.SharpMt940Lib.Mt940Format.Separator("-");
            var genericFomat = new Raptorious.SharpMt940Lib.Mt940Format.GenericFormat(header, trailer);

            var statements = new List<ICollection<CustomerStatementMessage>>();

            foreach(var item in BsonDoc)
            {
                var parsed = Raptorious.SharpMt940Lib.Mt940Parser.ParseData(genericFomat, item.GetElement("mt940_content").ToString(), CultureInfo.CurrentCulture);
                statements.Add(parsed);
            }

            var singleStatements = new List<CustomerStatementMessage>();
            
            foreach(var parsedStatement in statements)
            {
                foreach(var statement in parsedStatement)
                {
                    singleStatements.Add(statement);
                }
            }

            //Bank Statement
            XmlDocument xmlStatement = new XmlDocument();
            XmlNode statementsNode = xmlStatement.CreateElement("Statements");
            xmlStatement.AppendChild(statementsNode);
            try
            {
                //to get ID from the mongoDB
                int index = 0;
                
                foreach (var statement in singleStatements)
                {
                    XmlNode statementNode = xmlStatement.CreateElement("Statement");
                    statementsNode.AppendChild(statementNode);
                    //ID
                    string id;
                    if (BsonDoc[index].Contains("_id"))
                    {
                        id = BsonDoc[index].GetValue("_id").ToString();
                    } else
                    {
                        id = string.Empty;
                    }
                    XmlNode statementID = xmlStatement.CreateElement("ID");
                    statementID.InnerText = id;
                    index++;
                    statementNode.AppendChild(statementID);
                    //Account
                    XmlNode accountNode = xmlStatement.CreateElement("Account");
                    if (statement.Account == null)
                    {
                        accountNode.InnerText = string.Empty;
                    }
                    else
                    {
                        accountNode.InnerText = statement.Account.ToString();
                    }
                    statementNode.AppendChild(accountNode);
                    //Closing Available Balance
                    XmlNode closingAvailableBalance = xmlStatement.CreateElement("ClosingAvailableBalance");
                    if (statement.ClosingAvailableBalance == null)
                    {
                        closingAvailableBalance.InnerText = string.Empty;
                    }
                    else
                    {
                        closingAvailableBalance.InnerText = statement.ClosingAvailableBalance.ToString();
                    }
                    statementNode.AppendChild(closingAvailableBalance);
                    //Closing Balance
                    XmlNode closingBalance = xmlStatement.CreateElement("ClosingBalance");
                    statementNode.AppendChild(closingBalance);
                    //Balance
                    XmlNode closingBalanceBalance = xmlStatement.CreateElement("Balance");
                    if (statement.ClosingBalance.Balance == null)
                    {
                        closingBalanceBalance.InnerText = string.Empty;
                    }
                    else
                    {
                        closingBalanceBalance.InnerText = statement.ClosingBalance.Balance.ToString();
                    }
                    closingBalance.AppendChild(closingBalanceBalance);
                    //Currency
                    XmlNode currency = xmlStatement.CreateElement("Currency");
                    if (statement.ClosingBalance.Currency == null)
                    {
                        currency.InnerText = string.Empty;
                    }
                    else
                    {
                        currency.InnerText = statement.ClosingBalance.Currency.Code;
                    }
                    closingBalance.AppendChild(currency);
                    //Debit Credit
                    XmlNode closingBalanceDebitCredit = xmlStatement.CreateElement("DebitCredit");
                    closingBalanceDebitCredit.InnerText = statement.ClosingBalance.DebitCredit.ToString();
                    closingBalance.AppendChild(closingBalanceDebitCredit);
                    //Entry Date
                    XmlNode closingBalanceEntryDate = xmlStatement.CreateElement("EntryDate");
                    if (statement.ClosingBalance.EntryDate == null)
                    {
                        closingBalanceEntryDate.InnerText = string.Empty;
                    }
                    else
                    {
                        closingBalanceEntryDate.InnerText = statement.ClosingBalance.EntryDate.ToString();
                    }
                    closingBalance.AppendChild(closingBalanceEntryDate);
                    //Description
                    XmlNode description = xmlStatement.CreateElement("Description");
                    if (statement.Description == null)
                    {
                        description.InnerText = string.Empty;
                    }
                    else
                    {
                        description.InnerText = statement.Description.ToString();
                    }
                    statementNode.AppendChild(description);
                    //Forward Available Balance
                    XmlNode forwardAvailableBalance = xmlStatement.CreateElement("ForwardAvailableBalance");
                    if (statement.ForwardAvailableBalance == null)
                    {
                        forwardAvailableBalance.InnerText = string.Empty;
                    }
                    else
                    {
                        forwardAvailableBalance.InnerText = statement.ForwardAvailableBalance.ToString();
                    }
                    statementNode.AppendChild(forwardAvailableBalance);
                    //Opening Balance
                    XmlNode openingBalance = xmlStatement.CreateElement("OpeningBalance");
                    statementNode.AppendChild(openingBalance);
                    //Balance
                    XmlNode openingBalanceBalance = xmlStatement.CreateElement("Balance");
                    if (statement.OpeningBalance.Balance == null)
                    {
                        openingBalanceBalance.InnerText = string.Empty;
                    }
                    else
                    {
                        openingBalanceBalance.InnerText = statement.OpeningBalance.Balance.ToString();
                    }
                    openingBalance.AppendChild(openingBalanceBalance);
                    //Currency
                    XmlNode openingBalanceCurrency = xmlStatement.CreateElement("Currency");
                    if (statement.OpeningBalance.Currency == null)
                    {
                        openingBalanceCurrency.InnerText = string.Empty;
                    }
                    else
                    {
                        openingBalanceCurrency.InnerText = statement.OpeningBalance.Currency.Code;
                    }
                    openingBalance.AppendChild(openingBalanceCurrency);
                    //Debit Credit
                    XmlNode openingBalanceDebitCredit = xmlStatement.CreateElement("DebitCredit");
                    openingBalanceDebitCredit.InnerText = statement.OpeningBalance.DebitCredit.ToString();
                    openingBalance.AppendChild(openingBalanceDebitCredit);
                    //Entry Date
                    XmlNode openingBalanceEntryDate = xmlStatement.CreateElement("EntryDate");
                    if (statement.OpeningBalance.EntryDate == null)
                    {
                        openingBalanceEntryDate.InnerText = string.Empty;
                    }
                    else
                    {
                        openingBalanceEntryDate.InnerText = statement.OpeningBalance.EntryDate.ToString();
                    }
                    openingBalance.AppendChild(openingBalanceEntryDate);
                    //Related Message
                    XmlNode relatedMessage = xmlStatement.CreateElement("RelatedMessage");
                    if (statement.RelatedMessage == null)
                    {
                        relatedMessage.InnerText = string.Empty;
                    }
                    else
                    {
                        relatedMessage.InnerText = statement.RelatedMessage.ToString();
                    }
                    statementNode.AppendChild(relatedMessage);
                    //Sequence Number
                    XmlNode sequenceNumber = xmlStatement.CreateElement("SequenceNumber");
                    if (statement.SequenceNumber == 0)
                    {
                        sequenceNumber.InnerText = string.Empty;
                    }
                    else
                    {
                        sequenceNumber.InnerText = statement.SequenceNumber.ToString();
                    }
                    statementNode.AppendChild(sequenceNumber);
                    //Statement Number
                    XmlNode statementNumber = xmlStatement.CreateElement("StatementNumber");
                    if (statement.StatementNumber == 0)
                    {
                        statementNumber.InnerText = string.Empty;
                    }
                    else
                    {
                        statementNumber.InnerText = statement.StatementNumber.ToString();
                    }
                    statementNode.AppendChild(statementNumber);
                    //Transaction Reference
                    XmlNode transactionReference = xmlStatement.CreateElement("TransactionReference");
                    if (statement.TransactionReference == null)
                    {
                        transactionReference.InnerText = string.Empty;
                    }
                    else
                    {
                        transactionReference.InnerText = statement.TransactionReference.ToString();
                    }
                    statementNode.AppendChild(transactionReference);
                    //Transaction Node
                    XmlNode transactionsNode = xmlStatement.CreateElement("Transactions");
                    statementNode.AppendChild(transactionsNode);
                    foreach (var trans in statement.Transactions)
                    {
                        //Transactions
                        XmlNode transaction = xmlStatement.CreateElement("Transaction");
                        transactionsNode.AppendChild(transaction);
                        //Accounting Servicing Reference
                        XmlNode accountServicingReference = xmlStatement.CreateElement("AccountServicingReference");
                        if (trans.AccountServicingReference == null)
                        {
                            accountServicingReference.InnerText = string.Empty;
                        }
                        else
                        {
                            accountServicingReference.InnerText = trans.AccountServicingReference.ToString();
                        }
                        transaction.AppendChild(accountServicingReference);
                        //Amount
                        XmlNode amount = xmlStatement.CreateElement("Amount");
                        if (trans.Amount == null)
                        {
                            amount.InnerText = string.Empty;
                        }
                        else
                        {
                            amount.InnerText = trans.Amount.ToString();
                        }
                        transaction.AppendChild(amount);
                        //Debit Credit
                        XmlNode debitCredit = xmlStatement.CreateElement("DebitCredit");
                        debitCredit.InnerText = trans.DebitCredit.ToString();
                        transaction.AppendChild(debitCredit);
                        //Transaction Description
                        XmlNode transactionDescription = xmlStatement.CreateElement("Description");
                        if (trans.Description == null)
                        {
                            transactionDescription.InnerText = string.Empty;
                        }
                        else
                        {
                            transactionDescription.InnerText = trans.Description.ToString();
                        }
                        transaction.AppendChild(transactionDescription);
                        //Details
                        XmlNode details = xmlStatement.CreateElement("Details");
                        transaction.AppendChild(details);
                        //Account
                        XmlNode account = xmlStatement.CreateElement("Account");
                        if (trans.Details.Account == null)
                        {
                            account.InnerText = string.Empty;
                        }
                        else
                        {
                            account.InnerText = trans.Details.Account.ToString();
                        }
                        transaction.AppendChild(details);
                        //Details Description
                        XmlNode detailsDescription = xmlStatement.CreateElement("Description");
                        if (trans.Details.Description == null)
                        {
                            detailsDescription.InnerText = string.Empty;
                        }
                        else
                        {
                            detailsDescription.InnerText = trans.Details.Description.ToString();
                        }
                        transaction.AppendChild(details);
                        //Name
                        XmlNode name = xmlStatement.CreateElement("Name");
                        if (trans.Details.Name == null)
                        {
                            name.InnerText = string.Empty;
                        }
                        else
                        {
                            name.InnerText = trans.Details.Name.ToString();
                        }
                        transaction.AppendChild(details);
                        //Entry Date
                        XmlNode entryDate = xmlStatement.CreateElement("EntryDate");
                        if (trans.EntryDate == null)
                        {
                            entryDate.InnerText = string.Empty;
                        }
                        else
                        {
                            entryDate.InnerText = trans.EntryDate.ToString();
                        }
                        transaction.AppendChild(entryDate);
                        //Funds Code
                        XmlNode fundsCode = xmlStatement.CreateElement("FundsCode");
                        if (trans.FundsCode == null)
                        {
                            fundsCode.InnerText = string.Empty;
                        }
                        else
                        {
                            fundsCode.InnerText = trans.FundsCode.ToString();
                        }
                        transaction.AppendChild(fundsCode);
                        //Reference
                        XmlNode reference = xmlStatement.CreateElement("Reference");
                        if (trans.Reference == null)
                        {
                            reference.InnerText = string.Empty;
                        }
                        else
                        {
                            reference.InnerText = trans.Reference.ToString();
                        }
                        transaction.AppendChild(reference);
                        //Supplementary Details
                        XmlNode supplementaryDetails = xmlStatement.CreateElement("SupplementaryDetails");
                        if (trans.SupplementaryDetails == null)
                        {
                            supplementaryDetails.InnerText = string.Empty;
                        }
                        else
                        {
                            supplementaryDetails.InnerText = trans.SupplementaryDetails.ToString();
                        }
                        transaction.AppendChild(supplementaryDetails);
                        //Transaction Type
                        XmlNode transactionType = xmlStatement.CreateElement("TransactionType");
                        if (trans.TransactionType == null)
                        {
                            transactionType.InnerText = string.Empty;
                        }
                        else
                        {
                            transactionType.InnerText = trans.TransactionType.ToString();
                        }
                        transaction.AppendChild(transactionType);
                        //Value
                        XmlNode value = xmlStatement.CreateElement("Value");
                        if (trans.Value == null)
                        {
                            value.InnerText = string.Empty;
                        }
                        else
                        {
                            value.InnerText = trans.Value.ToString();
                        }
                        transaction.AppendChild(value);
                        //Value Date
                        XmlNode valueDate = xmlStatement.CreateElement("ValueDate");
                        if (trans.ValueDate == null)
                        {
                            valueDate.InnerText = string.Empty;
                        }
                        else
                        {
                            valueDate.InnerText = trans.ValueDate.ToString();
                        }
                        transaction.AppendChild(valueDate);
                    }

                }
            } catch
            {
                return null;
            }

            //run the xml through the xml validator
            Validator val = new Validator();
            if (val.validateXml(xmlStatement.InnerXml))
            {
                return xmlStatement;
            } else
            {
                return null;
            }
        }
    }
}
