use emarket;
CREATE TABLE users
(
	userID bigint NOT NULL IDENTITY(1,1),
	fName varchar(70) NULL,
	lName varchar(70) NULL,
	mobile varchar(15) NULL,
	email varchar(60) NULL,
	passwordHash varchar(50) NULL,
	isAdmin tinyint NULL,
	isVendor tinyint NULL,
  CONSTRAINT PK_USER PRIMARY KEY CLUSTERED
  (userID) WITH (IGNORE_DUP_KEY = OFF)
)
;

CREATE TABLE product(
	productID bigint NOT NULL IDENTITY(1,1),
	vendorID bigint NOT NULL,
	categoryID bigint NOT NULL,
	price DECIMAL(10,2) NULL,
	availableQTY smallint NULL,
	CanBeBought smallint NULL,
	productInfo varchar(80) NULL,
	sourceOfImage varchar(256) NULL,
  CONSTRAINT PK_PRODUCT PRIMARY KEY CLUSTERED
  (productID ASC) 
  WITH (IGNORE_DUP_KEY = OFF)

);

CREATE TABLE vendors (
	vendorID bigint NOT NULL IDENTITY(1,1),
	userID bigint NOT NULL,
	locationOfStore varchar(80) NULL,
	info text NULL,
  CONSTRAINT PK_VENDORS PRIMARY KEY CLUSTERED
  (
  vendorID ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

);

CREATE TABLE product_category (
	categoryID bigint NOT NULL IDENTITY(1,1),
	categoryName varchar(80) NULL,
  CONSTRAINT PK_PRODUCT_CATEGORY PRIMARY KEY CLUSTERED
  (
  categoryID ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

);

CREATE TABLE orders (
	orderID bigint NOT NULL IDENTITY(1,1),
	userID bigint NOT NULL,
	sessionID varchar(80) NULL,
	orderStatus int NULL,
	subtotal DECIMAL(10,2) NULL,
	tax DECIMAL(10,2),
	shipping DECIMAL(10,2),
	total DECIMAL(10,2) NULL,
	fName varchar(80) NULL,
	lName varchar(80) NULL,
	mobile varchar(15) NULL,
	email varchar(80) NULL,
	address varchar(80) NULL,
	city varchar(80) NULL,
	zipCode varchar(80) NULL,
  CONSTRAINT PK_ORDERS PRIMARY KEY CLUSTERED
  (
  orderID ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

);


CREATE TABLE cart (
    cartID bigint NOT NULL IDENTITY(1,1),
    userID bigint NOT NULL,
    sessionID varchar(80) NULL,
  CONSTRAINT PK_CART PRIMARY KEY CLUSTERED
  (
  cartID ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

);


ALTER TABLE [cart] WITH CHECK ADD CONSTRAINT [cart_fk0] FOREIGN KEY ([userID]) REFERENCES [userS]([userID])
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE [product] WITH CHECK ADD CONSTRAINT [product_fk0] FOREIGN KEY ([vendorID]) REFERENCES [vendors]([vendorID])
ON DELETE CASCADE
ON UPDATE CASCADE
;

ALTER TABLE [product] WITH CHECK ADD CONSTRAINT [product_fk1] FOREIGN KEY ([categoryID]) REFERENCES [product_category]([categoryID])
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE [vendors] WITH CHECK ADD CONSTRAINT [vendors_fk0] FOREIGN KEY ([userID]) REFERENCES [users]([userID])
ON DELETE CASCADE
ON UPDATE CASCADE;


ALTER TABLE [orders] WITH CHECK ADD CONSTRAINT [orders_fk0] FOREIGN KEY ([userID]) REFERENCES [users]([userID])
ON DELETE CASCADE
ON UPDATE CASCADE;

insert into product_category (categoryName) values ('Dairies');

insert into product_category (categoryName) values ('Pasta');

insert into product_category (categoryName) values ('Veggies');

insert into product_category (categoryName) values ('Fruits');

insert into product_category (categoryName) values ('Alcohol drinks');

insert into product_category (categoryName) values ('Snacks');

insert into product_category (categoryName) values ('Cleaning Supplies');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('Admin', 'emarket', '1234567890', 'admin@emarket.com', 'admin', '1', '0');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('Freskada', 'vendor', '1234567890', 'freskada@emarket.com', 'freskada', '0', '1');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('Super Offer', 'vendor', '1234567890', 'superoffer@emarket.com', 'superoffer', '0', '1');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('Food Town', 'vendor', '1234567890', 'ft@emarket.com', 'foodtown', '0', '1');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('Carts', 'vendor', '1234567890', 'carts@emarket.com', 'carts', '0', '1');

insert users (fName, lName, mobile, email, passwordHash, isAdmin, isVendor) values ('SP Market', 'vendor', '1234567890', 'spm@emarket.com', 'spmarket', '0', '1');

insert into vendors (userID, locationOfStore, info) values ('2', 'a', 'Freskada');

insert into vendors (userID, locationOfStore, info) values ('3', 'a', 'Super Offer');

insert into vendors (userID, locationOfStore, info) values ('4', 'a', 'Food Town');

insert into vendors (userID, locationOfStore, info) values ('5', 'a', 'Carts');

insert into vendors (userID, locationOfStore, info) values ('6', 'a', 'SP Market');

/* prod start*/


/* first vendor*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '1.2', '20', '1', 'Milk Olympos', 'https://bit.ly/3gJ0QQ9');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '1.5', '20', '1', 'Milk Delta', 'https://bit.ly/2Sfw203');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '2.3', '20', '1', 'Adoro Gouda', 'https://bit.ly/3iZvfvh');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '2.0', '20', '1', 'Gouda Nounou', 'https://bit.ly/3qhie1N');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '0.8', '20', '1', 'Flora Butter', 'https://bit.ly/35GB8Wn');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '1', '1.1', '20', '1', 'Whipping cream Meggle', 'https://bit.ly/3wLhcNZ');

/* pasta */

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '2', '1.1', '20', '1', 'Spaggeti Melissa No6', 'https://bit.ly/3gHGuHd');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '2', '1.3', '20', '1', 'Spaggeti Barilla No5', 'https://bit.ly/3gPkZDg');


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '2', '2.1', '20', '1', 'Kannelloni Barilla', 'https://bit.ly/2SQQi8E');


/*VEGIES*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '3', '0.2', '20', '1', 'Carrots', 'https://bit.ly/3vQ48p3');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '3', '0.3', '20', '1', 'Tomatoes', 'https://bit.ly/3wLyVVj');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '3', '0.2', '20', '1', 'Lemons', 'https://bit.ly/3zK0a4Q');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '3', '0.4', '20', '1', 'Red Peppers', 'https://bit.ly/3gL5JqU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '3', '0.3', '20', '1', 'Green Peppers', 'https://bit.ly/3j6NkaC');


/*Fruits*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '4', '0.5', '20', '1', 'Bananas', 'https://bit.ly/35GMVUB');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '4', '0.4', '20', '1', 'Oranges', 'https://bit.ly/3d2q6i6');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '4', '0.4', '20', '1', 'Apples', 'https://bit.ly/3vPWo6C');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '4', '0.2', '20', '1', 'Strawberries', 'https://bit.ly/2UnHuYm');




/*Alcohol drinks*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '5', '30', '20', '1', 'Glenfiddich 12 Years Old Whiskey', 'https://bit.ly/2UnIhbM');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '5', '18', '20', '1', 'Rum Havana Club', 'https://bit.ly/3vRLCwU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '5', '16', '20', '1', 'Gin Gordons', 'https://bit.ly/3wLAItv');


/*Snacks*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '6', '1.5', '20', '1', 'Lays Chips', 'https://bit.ly/2UjBZtv');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '6', '1.2', '20', '1', 'Pop Corn', 'https://bit.ly/3iWxfnV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '6', '1.3', '20', '1', 'Ruffles Chips', 'https://bit.ly/3wPwX6o');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '6', '2', '20', '1', 'Tiger Snacks', 'https://bit.ly/2UjCmUV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('1', '6', '2.2', '20', '1', 'Elite Crackers', 'https://bit.ly/3gPKXXh');


/* Second vendor*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '1', '1', '20', '1', 'Milk Olympos', 'https://bit.ly/3gJ0QQ9');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '1', '1.2', '20', '1', 'Milk Delta', 'https://bit.ly/2Sfw203');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '1', '2.2', '20', '1', 'Gouda Nounou', 'https://bit.ly/3qhie1N');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '1', '1', '20', '1', 'Flora Butter', 'https://bit.ly/35GB8Wn');


/* pasta */

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '2', '1.2', '20', '1', 'Spaggeti Melissa No6', 'https://bit.ly/3gHGuHd');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '2', '1.1', '20', '1', 'Spaggeti Barilla No5', 'https://bit.ly/3gPkZDg');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '2', '1.3', '20', '1', 'Rigatoni Barilla', 'https://bit.ly/3gPF6kL');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '2', '1.9', '20', '1', 'Penne Rigate Barrila', 'https://bit.ly/3j2Wwgi');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '2', '2.4', '20', '1', 'Kannelloni Barilla', 'https://bit.ly/2SQQi8E');


/*VEGIES*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '3', '0.1', '20', '1', 'Carrots', 'https://bit.ly/3vQ48p3');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '3', '0.2', '20', '1', 'Tomatoes', 'https://bit.ly/3wLyVVj');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '3', '0.1', '20', '1', 'Lemons', 'https://bit.ly/3zK0a4Q');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '3', '0.3', '20', '1', 'Red Peppers', 'https://bit.ly/3gL5JqU');


/*Fruits*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '4', '0.4', '20', '1', 'Bananas', 'https://bit.ly/35GMVUB');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '4', '0.3', '20', '1', 'Oranges', 'https://bit.ly/3d2q6i6');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '4', '0.2', '20', '1', 'Apples', 'https://bit.ly/3vPWo6C');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '4', '0.1', '20', '1', 'Strawberries', 'https://bit.ly/2UnHuYm');


/*Alcohol drinks*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '5', '31', '20', '1', 'Glenfiddich 12 Years Old Whiskey', 'https://bit.ly/2UnIhbM');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '5', '19', '20', '1', 'Rum Havana Club', 'https://bit.ly/3vRLCwU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '5', '15', '20', '1', 'Gin Gordons', 'https://bit.ly/3wLAItv');



/*Snacks*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '6', '1.2', '20', '1', 'Lays Chips', 'https://bit.ly/2UjBZtv');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '6', '1.3', '20', '1', 'Pop Corn', 'https://bit.ly/3iWxfnV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '6', '1.1', '20', '1', 'Ruffles Chips', 'https://bit.ly/3wPwX6o');


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('2', '6', '2.5', '20', '1', 'Elite Crackers', 'https://bit.ly/3gPKXXh');








/* third vendor*/



insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '1', '1.1', '20', '1', 'Milk Delta', 'https://bit.ly/2Sfw203');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '1', '2', '20', '1', 'Adoro Gouda', 'https://bit.ly/3iZvfvh');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '1', '1.5', '20', '1', 'Gouda Nounou', 'https://bit.ly/3qhie1N');


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '1', '1.4', '20', '1', 'Whipping cream Meggle', 'https://bit.ly/3wLhcNZ');


/* pasta */

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '2', '1.5', '20', '1', 'Spaggeti Melissa No6', 'https://bit.ly/3gHGuHd');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '2', '1.2', '20', '1', 'Spaggeti Barilla No5', 'https://bit.ly/3gPkZDg');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '2', '1.1', '20', '1', 'Rigatoni Barilla', 'https://bit.ly/3gPF6kL');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '2', '1.7', '20', '1', 'Kannelloni Barilla', 'https://bit.ly/2SQQi8E');


/*VEGIES*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '3', '0.4', '20', '1', 'Carrots', 'https://bit.ly/3vQ48p3');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '3', '0.5', '20', '1', 'Tomatoes', 'https://bit.ly/3wLyVVj');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '3', '0.4', '20', '1', 'Lemons', 'https://bit.ly/3zK0a4Q');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '3', '0.2', '20', '1', 'Red Peppers', 'https://bit.ly/3gL5JqU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '3', '0.4', '20', '1', 'Green Peppers', 'https://bit.ly/3j6NkaC');

/*Fruits*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '4', '0.5', '20', '1', 'Bananas', 'https://bit.ly/35GMVUB');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '4', '0.4', '20', '1', 'Oranges', 'https://bit.ly/3d2q6i6');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '4', '0.4', '20', '1', 'Apples', 'https://bit.ly/3vPWo6C');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '4', '0.2', '20', '1', 'Strawberries', 'https://bit.ly/2UnHuYm');


/*Alcohol drinks*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '5', '28', '20', '1', 'Glenfiddich 12 Years Old Whiskey', 'https://bit.ly/2UnIhbM');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '5', '20', '20', '1', 'Rum Havana Club', 'https://bit.ly/3vRLCwU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '5', '18', '20', '1', 'Gin Gordons', 'https://bit.ly/3wLAItv');


/*Snacks*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '6', '1.2', '20', '1', 'Lays Chips', 'https://bit.ly/2UjBZtv');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '6', '1.4', '20', '1', 'Pop Corn', 'https://bit.ly/3iWxfnV');


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '6', '1.4', '20', '1', 'Tiger Snacks', 'https://bit.ly/2UjCmUV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('3', '6', '2.1', '20', '1', 'Elite Crackers', 'https://bit.ly/3gPKXXh');











/* forth vendor*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1', '20', '1', 'Milk Olympos', 'https://bit.ly/3gJ0QQ9');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1.9', '20', '1', 'Milk Delta', 'https://bit.ly/2Sfw203');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1.7', '20', '1', 'Adoro Gouda', 'https://bit.ly/3iZvfvh');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1.0', '20', '1', 'Gouda Nounou', 'https://bit.ly/3qhie1N');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1.8', '20', '1', 'Flora Butter', 'https://bit.ly/35GB8Wn');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '1', '1.1', '20', '1', 'Whipping cream Meggle', 'https://bit.ly/3wLhcNZ');

/* pasta */

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '2', '1.3', '20', '1', 'Spaggeti Melissa No6', 'https://bit.ly/3gHGuHd');


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '2', '1.7', '20', '1', 'Penne Rigate Barrila', 'https://bit.ly/3j2Wwgi');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '2', '2.7', '20', '1', 'Kannelloni Barilla', 'https://bit.ly/2SQQi8E');

/*VEGIES*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '3', '0.2', '20', '1', 'Carrots', 'https://bit.ly/3vQ48p3');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '3', '0.3', '20', '1', 'Lemons', 'https://bit.ly/3zK0a4Q');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '3', '0.2', '20', '1', 'Red Peppers', 'https://bit.ly/3gL5JqU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '3', '0.3', '20', '1', 'Green Peppers', 'https://bit.ly/3j6NkaC');



/*Fruits*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '4', '0.5', '20', '1', 'Bananas', 'https://bit.ly/35GMVUB');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '4', '0.4', '20', '1', 'Oranges', 'https://bit.ly/3d2q6i6');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '4', '0.4', '20', '1', 'Apples', 'https://bit.ly/3vPWo6C');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '4', '0.2', '20', '1', 'Strawberries', 'https://bit.ly/2UnHuYm');


/*Alcohol drinks*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '5', '30', '20', '1', 'Glenfiddich 12 Years Old Whiskey', 'https://bit.ly/2UnIhbM');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '5', '18', '20', '1', 'Rum Havana Club', 'https://bit.ly/3vRLCwU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '5', '16', '20', '1', 'Gin Gordons', 'https://bit.ly/3wLAItv');




/*Snacks*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '6', '1.5', '20', '1', 'Lays Chips', 'https://bit.ly/2UjBZtv');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '6', '1.2', '20', '1', 'Pop Corn', 'https://bit.ly/3iWxfnV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '6', '1.3', '20', '1', 'Ruffles Chips', 'https://bit.ly/3wPwX6o');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '6', '2', '20', '1', 'Tiger Snacks', 'https://bit.ly/2UjCmUV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('4', '6', '2.2', '20', '1', 'Elite Crackers', 'https://bit.ly/3gPKXXh');









/* fifth vendor*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '1', '1.1', '20', '1', 'Milk Olympos', 'https://bit.ly/3gJ0QQ9');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '1', '2.7', '20', '1', 'Adoro Gouda', 'https://bit.ly/3iZvfvh');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '1', '1.5', '20', '1', 'Gouda Nounou', 'https://bit.ly/3qhie1N');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '1', '1.2', '20', '1', 'Flora Butter', 'https://bit.ly/35GB8Wn');

/* pasta */

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '2', '1.2', '20', '1', 'Spaggeti Melissa No6', 'https://bit.ly/3gHGuHd');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '2', '1.1', '20', '1', 'Spaggeti Barilla No5', 'https://bit.ly/3gPkZDg');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '2', '1.3', '20', '1', 'Rigatoni Barilla', 'https://bit.ly/3gPF6kL');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '2', '1.9', '20', '1', 'Penne Rigate Barrila', 'https://bit.ly/3j2Wwgi');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '2', '2.4', '20', '1', 'Kannelloni Barilla', 'https://bit.ly/2SQQi8E');

/*VEGIES*/

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '3', '0.1', '20', '1', 'Carrots', 'https://bit.ly/3vQ48p3');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '3', '0.2', '20', '1', 'Tomatoes', 'https://bit.ly/3wLyVVj');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '3', '0.3', '20', '1', 'Lemons', 'https://bit.ly/3zK0a4Q');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '3', '0.5', '20', '1', 'Red Peppers', 'https://bit.ly/3gL5JqU');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '3', '0.3', '20', '1', 'Green Peppers', 'https://bit.ly/3j6NkaC');







/*Fruits*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '4', '0.7', '20', '1', 'Bananas', 'https://bit.ly/35GMVUB');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '4', '0.5', '20', '1', 'Oranges', 'https://bit.ly/3d2q6i6');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '4', '0.6', '20', '1', 'Apples', 'https://bit.ly/3vPWo6C');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '4', '0.4', '20', '1', 'Strawberries', 'https://bit.ly/2UnHuYm');



/*Snacks*/


insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '6', '1.1', '20', '1', 'Ruffles Chips', 'https://bit.ly/3wPwX6o');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '6', '2.5', '20', '1', 'Tiger Snacks', 'https://bit.ly/2UjCmUV');

insert into product (vendorID, categoryID, price, availableQTY, CanBeBought, productInfo, sourceOfImage)
values ('5', '6', '1.2', '20', '1', 'Elite Crackers', 'https://bit.ly/3gPKXXh');
