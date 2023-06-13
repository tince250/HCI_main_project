INSERT into Addresses (City, PostalCode, Street, StreetNumber) values ("Belgrade", 21000, "Kneginje Ljubice", 18);
INSERT into Addresses (City, PostalCode, Street, StreetNumber) values ("Belgrade", 21000, "Jevrejska", 22);
INSERT into Addresses (City, PostalCode, Street, StreetNumber) values ("Belgrade", 21000, "Vladimira Popovica", 6);
INSERT into Addresses (City, PostalCode, Street, StreetNumber) values ("Belgrade", 21000, "Dobropoljska", 65);
INSERT into Addresses (City, PostalCode, Street, StreetNumber) values ("Belgrade", 21000, "Carigradska", 3);

insert into Users (FirstName, LastName, Email, Password, "Role") values ("Agent", "Agentovic", "agent@gmail.com", "12345678", 1);
insert into Users (FirstName, LastName, Email, Password, "Role") values ("User", "Userovic", "user@gmail.com", "12345678", 0);

insert into Restaurants (Name, Image, AddressId, Latitude, Longitude) values ("Sushi bar", "sushi.jpg", 1, 44.821500, 20.463789);
insert into Attractions (Name, Image, AddressId, Latitude, Longitude) values ("Fortress", "fortress.jpg", 2, 44.827242, 20.457272);
insert into Attractions (Name, Image, AddressId, Latitude, Longitude) values ("Belgrade zoo", "zoo.jpg", 3, 44.810401, 20.437032);
insert into Accommodations (Name, Image, AddressId, Latitude, Longitude, Type) values ("Hotel Moscow", "moscow.jpg", 4, 44.792210, 20.462648, 0);
insert into Accommodations (Name, Image, AddressId, Latitude, Longitude, Type) values ("Hayat", "hayat.jpg", 5, 44.817952, 20.472783, 0);
