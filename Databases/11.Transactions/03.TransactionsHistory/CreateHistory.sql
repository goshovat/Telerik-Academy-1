IF OBJECT_ID('[TransactionsHistory]') IS NOT NULL
BEGIN
	DROP TABLE [TransactionsHistory]
END
GO

CREATE TABLE [dbo].[TransactionsHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](10) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Ammount] [money] NOT NULL,
 CONSTRAINT [PK_TransactionsHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

