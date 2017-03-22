use inventory

CREATE TABLE DBO.ITEMS (
	itemNum INT IDENTITY NOT NULL,
	itemDescription VARCHAR(500) NOT NULL,
	pricePerItem SMALLMONEY NOT NULL DEFAULT 0,
	quantityOnHand INT NOT NULL DEFAULT 0,
	ourCostPerItem SMALLMONEY NOT NULL DEFAULT 0,
	valueOfItem AS (pricePerItem * quantityOnHand),
	CONSTRAINT PK_ITEMS_ITEMNUM PRIMARY KEY CLUSTERED (itemNum)
)

insert into items(itemDescription,pricePerItem,quantityOnHand,ourCostPerItem) values ('purple flower pots',2,3,1)
insert into items(itemDescription,pricePerItem,quantityOnHand,ourCostPerItem) values ('red flower pots',8,5,2)
insert into items(itemDescription,pricePerItem,quantityOnHand,ourCostPerItem) values ('green flower pots',4,1,1)

select * from items