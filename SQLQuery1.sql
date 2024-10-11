create database BikeRentalManagement;

create Table BikesData(
BikeId nvarchar(20) not null,
Brand nvarchar(20),
Model nvarchar(20),
RentalPrice decimal(10,2)
Primary Key (BikeId)
);

insert into BikesData(Brand,Model,RentalPrice) values('BIKE_001 ','Honda','CB-shine',5.00);